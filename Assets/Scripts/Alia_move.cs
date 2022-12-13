using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ALIA_Move : MonoBehaviour
{
    public LineRenderer lineRenderer;
    public SpriteRenderer alia;
    public List<Vector3> alia_positions;
    //private List<Vector3> target;
    private float speed = 3f;
    public PathFinding pathFind;
    public int clickCount = 0;

    void Start()
    {
        alia.enabled = false;
        //target.Add(transform.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.Find("Random Connection Button"))
        {
        }
        else
        {
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit.collider && Input.GetMouseButtonDown(0) && hit.collider.gameObject.tag == "site" && pathFind.conmod.counter % 2 != 0)
            {
                clickCount++;
                if (clickCount == 1)
                {
                    pathFind.positions.Clear();
                    pathFind.clicked.Clear();
                    pathFind.clicked.Add(hit.collider.gameObject.GetComponent<PathNode>());
                }
                if (clickCount == 2)
                {
                    pathFind.clicked.Add(hit.collider.gameObject.GetComponent<PathNode>());
                    pathFind.path = pathFind.FindPath();
                    if (pathFind.path != null)
                    {
                        //target=pathFind.path;
                        //target.z = transform.position.z;

                        alia.enabled = true;
                        alia_positions.Clear();
                        StopAllCoroutines();
                        StartCoroutine(Move());
                    }
                    else
                    {
                        alia.enabled = false;
                        pathFind.positions.Clear();
                        pathFind.clicked.Clear();
                        lineRenderer.positionCount = 0;
                        pathFind.text.CrossFadeAlpha(881.0f, 1.00f, false);
                        pathFind.text.CrossFadeAlpha(0.0f, 2.0f, false);
                    }
                    clickCount = 0;
                }
            }
            if (pathFind.conmod.counter % 2 == 0) alia.enabled = false;
        }
    }
    IEnumerator Move()
    {
        transform.position = pathFind.path[0].position;
        for (int i = 1; i < pathFind.path.Count; i++)
        {
            Vector3 diff = pathFind.path[i].position - transform.position;
            diff.Normalize();
            float rot_z = Mathf.Atan2(diff.y, diff.x) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0f, 0f, rot_z - 90);
            while (transform.position != pathFind.path[i].position)
            {
                transform.position = Vector3.MoveTowards(transform.position, pathFind.path[i].position, speed * Time.deltaTime);
                alia_positions.Add(transform.position);
                lineRenderer.positionCount = alia_positions.Count;
                lineRenderer.SetPositions(alia_positions.ToArray());
                yield return new WaitForSeconds(.00001f);
            }

            //lineRenderer.positionCount = pathFind.path.Count;
            //for (int i = 0; i < pathFind.path.Count; i++) pathFind.positions.Add(pathFind.path[i].position);
            //lineRenderer.SetPositions(pathFind.positions.ToArray());
        }
    }

    public void RandomPath()
    {
        pathFind.positions.Clear();
        pathFind.clicked.Clear();
        int k = 0;
        while (k == 0)
        {
            pathFind.clicked.Add(pathFind.sites[Random.Range(0, pathFind.sites.Count)].GetComponent<PathNode>());
            pathFind.clicked.Add(pathFind.sites[Random.Range(0, pathFind.sites.Count)].GetComponent<PathNode>());
            pathFind.path = pathFind.FindPath();
            if (pathFind.path != null&&pathFind.clicked[0]!=pathFind.clicked[1])
            {
                //Debug.Log(pathFind.clicked[0]);
                //Debug.Log(pathFind.clicked[1]);
                alia.enabled = true;
                alia_positions.Clear();
                StopAllCoroutines();
                StartCoroutine(Move());
                k++;
            }
            else pathFind.clicked.Clear();
        }
    }
}
