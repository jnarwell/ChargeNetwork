using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PathNode : MonoBehaviour
{
    public Vector3 position;

    public float x;
    public float y;

    public float gCost;
    public float hCost;
    public float fCost;

    public PathNode cameFromNode;

    public void CalculateFCost()
    {
        fCost = gCost + hCost;
    }

    private void Start()
    {
        x = GetComponent<Transform>().position.x;
        y = GetComponent<Transform>().position.y;

        position = GetComponent<Transform>().position;
    }
}
