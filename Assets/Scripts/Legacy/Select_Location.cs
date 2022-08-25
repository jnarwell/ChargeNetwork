using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Select_Location : MonoBehaviour
{
    public GameObject location;

    public GameObject connection0;
    public GameObject connection1;
    public GameObject connection2;

    public bool locationSelected = false;

    void Start()
    {
        
    }

    void Update()
    {
        if (locationSelected)
        {
            ShowConnections();
        }

        if (!locationSelected)
        {
            HideConnections();
        }
    }

    private void OnMouseDown()
    {
        if (locationSelected)
        {
            locationSelected = false;
        }

        if (!locationSelected)
        {
            locationSelected = true;
        }
    }

    private void ShowConnections()
    {
        connection0.transform.position = new Vector3(connection0.transform.position.x, connection0.transform.position.y, -1f);
        connection1.transform.position = new Vector3(connection1.transform.position.x, connection1.transform.position.y, -1f);
        connection2.transform.position = new Vector3(connection2.transform.position.x, connection2.transform.position.y, -1f);
    }

    private void HideConnections()
    {
        connection0.transform.position = new Vector3(connection0.transform.position.x, connection0.transform.position.y, +5f);
        connection1.transform.position = new Vector3(connection1.transform.position.x, connection1.transform.position.y, +5f);
        connection2.transform.position = new Vector3(connection2.transform.position.x, connection2.transform.position.y, +5f);
    }
}
