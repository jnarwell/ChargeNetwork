using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using System.Linq;
using TMPro;

public class PathFinding : MonoBehaviour
{

    private List<PathNode> openList;
    private List<PathNode> closedList;

    public List<GameObject> sites;

    public int clickCount = 0;
    public List<PathNode> clicked;

    public LineRenderer lineRenderer;

    public List<Vector3> positions;

    public List<PathNode> path;

    public TMP_Text text;

    public Airport_Trigger last_hit;
    public Connection_data con_data;

    public bool singleClick;
    private float doubleClickTimeLimit = 0.25f;
    private RaycastHit2D hit;

    private float timeLeft;
    public Color targetColor;

    private void Start()
    {
        sites.AddRange(GameObject.FindGameObjectsWithTag("site"));
        //lineRenderer = GetComponent<LineRenderer>();
        text.CrossFadeAlpha(0.0f, 0.0f, false);
        StartCoroutine(InputListener());

        con_data = GameObject.Find("Connection Data").GetComponent<Connection_data>();
        con_data.gameObject.SetActive(false);
    }

    private void Pulse()
    {
       clicked[0].gameObject.GetComponent<Airport_Trigger>().image_child.color = Color.Lerp(Color.white, Color.black, Mathf.PingPong(Time.time, 1));
    }
    private void Update()
    {
        if (clickCount == 1)
        {
            Pulse();
        }
    }
    // Update is called once per frame
    private IEnumerator InputListener()
    {
        while (enabled)
        { //Run as long as this is activ

            if (Input.GetMouseButtonDown(0))
            {
                singleClick = false;
                yield return ClickEvent();
            }

            yield return null;
        }
    }

    private IEnumerator ClickEvent()
    {
        //pause a frame so you don't pick up the same mouse down event.
        yield return new WaitForEndOfFrame();

        float count = 0f;
        while (count < doubleClickTimeLimit)
        {
            if (Input.GetMouseButtonDown(0))
            {
                DoubleClick();
                yield break;
            }
            count += Time.deltaTime;// increment counter by change in time between frames
            yield return null; // wait for the next frame
        }
        SingleClick();
    }


    private void SingleClick()
    {
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.Log("Single Click");
        singleClick = true;
        if (hit.collider && hit.collider.gameObject.tag == "site")
        {
            Airport_Trigger this_hit = hit.collider.gameObject.GetComponent<Airport_Trigger>();
            if (last_hit == null)
            {
                this_hit.userToggle(this_hit.onoff);
                this_hit.onoff.isOn = true;
            }
            else if (this_hit == last_hit)
            {
                this_hit.userToggle(this_hit.onoff);
                this_hit.onoff.isOn = false;
            }
            else
            {
                if (last_hit.text_child.transform.localPosition == new Vector3(3.04999995f, 1, last_hit.text_child.transform.localPosition.z) || last_hit.text_child.transform.localPosition == new Vector3(-3.04999995f, 1, last_hit.text_child.transform.localPosition.z))
                {
                    last_hit.userToggle(hit.collider.gameObject.GetComponent<Airport_Trigger>().onoff);
                    last_hit.onoff.isOn = false;
                    this_hit.userToggle(hit.collider.gameObject.GetComponent<Airport_Trigger>().onoff);
                    this_hit.onoff.isOn = true;
                }
                else
                {
                    this_hit.userToggle(hit.collider.gameObject.GetComponent<Airport_Trigger>().onoff);
                    this_hit.onoff.isOn = true;
                }
            }
            last_hit = this_hit;
            
        }

    }

    private void DoubleClick()
    {
        singleClick = false;
        hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
        Debug.Log("Double Click");
        if (hit.collider && hit.collider.gameObject.tag == "site")
        {
            if (GameObject.Find("ALIA")) Debug.Log("ALIA Exists");
            else
            {
                clickCount++;
            }
            if (clickCount == 1)
            {
                positions.Clear();
                clicked.Clear();
                clicked.Add(hit.collider.gameObject.GetComponent<PathNode>());
                lineRenderer.positionCount = 0;
                con_data.gameObject.SetActive(false);
            }
            if (clickCount == 2)
            {
                clicked[0].gameObject.GetComponent<Airport_Trigger>().image_child.color = Color.white;
                clicked.Add(hit.collider.gameObject.GetComponent<PathNode>());
                path = FindPath();
                if (path != null)
                {
                    lineRenderer.positionCount = path.Count;
                    for (int i = 0; i < path.Count; i++) positions.Add(path[i].position);
                    lineRenderer.SetPositions(positions.ToArray());
                    con_data.gameObject.SetActive(true);
                }
                else
                {
                    positions.Clear();
                    clicked.Clear();
                    lineRenderer.positionCount = 0;
                    text.CrossFadeAlpha(881.0f, 1.00f, false);
                    text.CrossFadeAlpha(0.0f, 2.0f, false);
                    con_data.gameObject.SetActive(false);
                }
                clickCount = 0;
            }
        }
    }

    public void close()
    {
        positions.Clear();
        clicked.Clear();
        lineRenderer.positionCount = 0;
        con_data.gameObject.SetActive(false);
    }

    public List<PathNode> FindPath()
    {

        PathNode startNode = clicked[0];
        PathNode endNode = clicked[1];

        openList = new List<PathNode> { startNode };
        closedList = new List<PathNode>();

        for (int i = 0; i<sites.Count; i++)
        {
            PathNode pathNode = sites[i].GetComponent<PathNode>();
            pathNode.gCost = int.MaxValue;
            pathNode.CalculateFCost();
            pathNode.cameFromNode = null;
        }

        startNode.gCost = 0;
        startNode.hCost = CalculateDistanceCost(startNode, endNode);
        startNode.CalculateFCost();

        while (openList.Count > 0)
        {
            PathNode currentNode = GetLowestFCostNode(openList);
            if (currentNode == endNode)
            {
                // reached final node
                return CalculatePath(endNode);
            }

            openList.Remove(currentNode);
            closedList.Add(currentNode);

            foreach (PathNode neighborNode in GetNeighborList(currentNode))
            {
                if (closedList.Contains(neighborNode)) continue;

                float tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighborNode);
                if (tentativeGCost < neighborNode.gCost)
                {
                    neighborNode.cameFromNode = currentNode;
                    neighborNode.gCost = tentativeGCost;
                    neighborNode.hCost = CalculateDistanceCost(neighborNode, endNode);
                    neighborNode.CalculateFCost();

                    if (!openList.Contains(neighborNode)) openList.Add(neighborNode);
                }
            }
        }

        // Out of nodes on openList
        return null;
    }

    private List<PathNode> GetNeighborList (PathNode pathNode)
    {
        List<PathNode> neighborList = new List<PathNode>();

        //current distance conversion 1 unit = 0.00651 miles

        for (int i = 0; i < sites.Count; i++)
        {
            if (CalculateDistanceCost(pathNode, sites[i].GetComponent<PathNode>()) < 0.00651*375) neighborList.Add(sites[i].GetComponent<PathNode>());
        }

        return neighborList;
    }

    private List<PathNode> CalculatePath(PathNode endNode)
    {
        List<PathNode> path = new List<PathNode>();
        path.Add(endNode);
        PathNode currentNode = endNode;
        while (currentNode.cameFromNode != null)
        {
            path.Add(currentNode.cameFromNode);
            currentNode = currentNode.cameFromNode;
        }
        path.Reverse();
        return path;
    }

    public float CalculateDistanceCost(PathNode a, PathNode b)
    {
        float xDistance = Mathf.Abs(a.x - b.x);
        float yDistance = Mathf.Abs(a.y - b.y);

        return Mathf.Sqrt(Mathf.Pow(xDistance, 2) + Mathf.Pow(yDistance, 2));
    }

    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
    {
        PathNode lowestFCostNode = pathNodeList[0];
        for (int i = 1; i<pathNodeList.Count; i++)
        {
            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
            {
                lowestFCostNode = pathNodeList[i];
            }
        }
        return lowestFCostNode;
    }

}
