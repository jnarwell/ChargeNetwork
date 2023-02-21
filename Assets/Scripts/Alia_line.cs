//using System.Collections;
//using System.Collections.Generic;
//using UnityEngine;

//public class Alia_line : MonoBehaviour
//{
//    private List<PathNode> openList;
//    private List<PathNode> closedList;

//    public List<GameObject> sites;

//    public LineRenderer lineRenderer;

//    public List<Vector3> positions;
//    public Connection_Mode_Change conmod;

//    public List<PathNode> path;

//    void Start()
//    {
        
//    }

//    void Update()
//    {
        
//    }

//    private List<PathNode> ChoosePath()
//    {
//        return null;
//    }

//    public List<PathNode> FindPath()
//    {

//        PathNode startNode = clicked[0];
//        PathNode endNode = clicked[1];

//        openList = new List<PathNode> { startNode };
//        closedList = new List<PathNode>();

//        for (int i = 0; i < sites.Count; i++)
//        {
//            PathNode pathNode = sites[i].GetComponent<PathNode>();
//            pathNode.gCost = int.MaxValue;
//            pathNode.CalculateFCost();
//            pathNode.cameFromNode = null;
//        }

//        startNode.gCost = 0;
//        startNode.hCost = CalculateDistanceCost(startNode, endNode);
//        startNode.CalculateFCost();

//        while (openList.Count > 0)
//        {
//            PathNode currentNode = GetLowestFCostNode(openList);
//            if (currentNode == endNode)
//            {
//                 reached final node
//                return CalculatePath(endNode);
//            }

//            openList.Remove(currentNode);
//            closedList.Add(currentNode);

//            foreach (PathNode neighborNode in GetNeighborList(currentNode))
//            {
//                if (closedList.Contains(neighborNode)) continue;

//                float tentativeGCost = currentNode.gCost + CalculateDistanceCost(currentNode, neighborNode);
//                if (tentativeGCost < neighborNode.gCost)
//                {
//                    neighborNode.cameFromNode = currentNode;
//                    neighborNode.gCost = tentativeGCost;
//                    neighborNode.hCost = CalculateDistanceCost(neighborNode, endNode);
//                    neighborNode.CalculateFCost();

//                    if (!openList.Contains(neighborNode)) openList.Add(neighborNode);
//                }
//            }
//        }

//         Out of nodes on openList
//        return null;
//    }

//    private List<PathNode> GetNeighborList(PathNode pathNode)
//    {
//        List<PathNode> neighborList = new List<PathNode>();

//        for (int i = 0; i < sites.Count; i++)
//        {
//            if (CalculateDistanceCost(pathNode, sites[i].GetComponent<PathNode>()) < 1.58995) neighborList.Add(sites[i].GetComponent<PathNode>());
//        }

//        return neighborList;
//    }

//    private List<PathNode> CalculatePath(PathNode endNode)
//    {
//        List<PathNode> path = new List<PathNode>();
//        path.Add(endNode);
//        PathNode currentNode = endNode;
//        while (currentNode.cameFromNode != null)
//        {
//            path.Add(currentNode.cameFromNode);
//            currentNode = currentNode.cameFromNode;
//        }
//        path.Reverse();
//        return path;
//    }

//    public float CalculateDistanceCost(PathNode a, PathNode b)
//    {
//        float xDistance = Mathf.Abs(a.x - b.x);
//        float yDistance = Mathf.Abs(a.y - b.y);

//        return Mathf.Sqrt(Mathf.Pow(xDistance, 2) + Mathf.Pow(yDistance, 2));
//    }

//    private PathNode GetLowestFCostNode(List<PathNode> pathNodeList)
//    {
//        PathNode lowestFCostNode = pathNodeList[0];
//        for (int i = 1; i < pathNodeList.Count; i++)
//        {
//            if (pathNodeList[i].fCost < lowestFCostNode.fCost)
//            {
//                lowestFCostNode = pathNodeList[i];
//            }
//        }
//        return lowestFCostNode;
//    }
//}
