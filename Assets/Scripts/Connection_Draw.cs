using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Connection_Draw : MonoBehaviour
{
    public Connection_Mode_Change conmod;
    public int counter;

    public LineRenderer lineRenderer;
    public Vector3[] sitePositions = new Vector3[2];

    public Camera gameCamera;

    private void Start()
    {
        counter = 0;
        lineRenderer = GetComponent<LineRenderer>();
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
                sitePositions[0] = hit.collider.gameObject.transform.position;
            }

            if (counter == 2)
            {
                sitePositions[1] = hit.collider.gameObject.transform.position;
                lineRenderer.positionCount = 2;
                lineRenderer.SetPositions(sitePositions);

                counter = 0;
            }
            
        }
        if (conmod.counter % 2 == 0)
        {
            lineRenderer.positionCount = 0;
            counter = 0;
        }

    }

}