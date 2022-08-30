using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Linq;

//157.23748:1 map scale
//1.58995 = max distance

public class Connection_Draw : MonoBehaviour
{
    public Connection_Mode_Change conmod;
    public int counter;

    public LineRenderer lineRenderer;
    public Vector3[] clickPositions = new Vector3[2];
    public List<GameObject> bestPath;

    public GameObject[] sites;
    public Camera gameCamera;

    private void Start()
    {
        sites = GameObject.FindGameObjectsWithTag("site");
        counter = 0;
        lineRenderer = GetComponent<LineRenderer>();
        bestPath = new List<GameObject>(new GameObject[0]);
        //Debug.Log(sites[0]);
        //Debug.Log(sites[1]);
        //Debug.Log(Math.Abs(sites[0].transform.position.x - sites[1].transform.position.x));
        //Debug.Log(Math.Abs(sites[0].transform.position.y - sites[1].transform.position.y));
        //Debug.Log(Math.Sqrt(Math.Pow(Math.Abs(sites[0].transform.position.y - sites[1].transform.position.y),2)+Math.Pow(Math.Abs(sites[0].transform.position.x - sites[1].transform.position.x),2)));
    }

    private void Update()
    {
        RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

        if (hit.collider&&Input.GetMouseButtonDown(0) && conmod.counter % 2 != 0)
        {
            Debug.DrawRay(gameCamera.transform.position, hit.point, Color.red);

            counter++;

            if (counter == 1)
            {
                clickPositions[0] = hit.collider.gameObject.transform.position;
            }

            if (counter == 2)
            {
                clickPositions[1] = hit.collider.gameObject.transform.position;
                if (Math.Sqrt(Math.Pow(Math.Abs(clickPositions[0].y - clickPositions[1].y), 2) + Math.Pow(Math.Abs(clickPositions[0].x - clickPositions[1].x), 2))<= 1.58995)
                {
                    lineRenderer.positionCount = 2;
                    lineRenderer.SetPositions(clickPositions);
                }

                else
                {
                    for (int j = 0; j < sites.Length; j++)
                    {
                        if (Math.Sqrt(Math.Pow(Math.Abs(clickPositions[0].y - sites[j].transform.position.y), 2) + Math.Pow(Math.Abs(clickPositions[0].x - sites[j].transform.position.x), 2)) <= 1.58995&& Math.Sqrt(Math.Pow(Math.Abs(clickPositions[0].y - sites[j].transform.position.y), 2) + Math.Pow(Math.Abs(clickPositions[0].x - sites[j].transform.position.x), 2)) != 0)
                        {
                            bestPath.Add(sites[j]);
                            Debug.Log(bestPath.Last());
                        }
                    }
                }

                counter = 0;
            }
            
        }
        if (conmod.counter % 2 == 0)
        {
            lineRenderer.positionCount = 0;
            counter = 0;
        }

    }

    void checkPath()
    {
        for (int j = 0; j < bestPath.Count; j++)
        {
            if (Math.Sqrt(Math.Pow(Math.Abs(clickPositions[1].y - bestPath[j].transform.position.y), 2) + Math.Pow(Math.Abs(clickPositions[1].x - bestPath[j].transform.position.x), 2)) <= 1.58995)
            {

            }
        }
    }

}