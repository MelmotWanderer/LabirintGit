using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Navigation 
{
    
    public List<Vector3> FindPathToTarget(MazeData maze, Vector3 beginPoint, Vector3 targetPoint)
    {

        
        List<PathNode> openNodes = new List<PathNode>();
        List<PathNode> closedNodes = new List<PathNode>();
        
        PathNode startNode = new PathNode(beginPoint, 0, CustomMath.GetHeuristicEstimateBetweenPointsLenght(beginPoint, targetPoint));

        closedNodes.Add(startNode);
        openNodes.AddRange(GetNeighbors(startNode, targetPoint, maze));
        int maxNodes = 1000;

        while (openNodes.Count > 0)
        {
            
            PathNode node = openNodes[GetMinEstimate(openNodes)];
           
            if(node.Point == targetPoint)
            {
                return GetPathToTarget(node);
                
            }

        
            if (maze.MazeMap[(int)node.Point.x, (int)node.Point.z] == 1)
            {
                openNodes.Remove(node);
                closedNodes.Add(node);
            }
            else
            {
                openNodes.Remove(node);
                if (!closedNodes.Contains(node))
                {
                    closedNodes.Add(node);
                    openNodes.AddRange(GetNeighbors(node, targetPoint, maze));
                }
            }

            if(openNodes.Count > maxNodes || closedNodes.Count > maxNodes)
            {
                return GetPathToTarget(node);
            }

        }

        return null;
    }
   
    private List<Vector3> GetPathToTarget(PathNode node)
    {
        var path = new List<Vector3>();
        PathNode currentNode = node;
        while(currentNode.CameFrom != null)
        {
            path.Add(currentNode.Point);
        
            currentNode = currentNode.CameFrom;
           
        }

        path.Reverse();
        return path;
    }
   


    private List<PathNode> GetNeighbors(PathNode node, Vector3 targetPoint, MazeData maze)
    {
        var neighbours = new List<PathNode>();
       
        if (node.Point.x - 1 >= 0)
        {
          
            neighbours.Add(new PathNode(new Vector3(node.Point.x - 1, node.Point.y, node.Point.z), node.PathLenghtFromStart + 1, CustomMath.GetHeuristicEstimateBetweenPointsLenght(node.Point, targetPoint), node));
        }
   
        if (node.Point.x + 1 <= maze.MazeMap.GetUpperBound(0))
        {
            
            neighbours.Add(new PathNode(new Vector3(node.Point.x + 1, node.Point.y, node.Point.z), node.PathLenghtFromStart + 1, CustomMath.GetHeuristicEstimateBetweenPointsLenght(node.Point, targetPoint), node));
        }
        
        if (node.Point.z - 1 >= 0)
        {

            neighbours.Add(new PathNode(new Vector3(node.Point.x, node.Point.y, node.Point.z - 1), node.PathLenghtFromStart + 1, CustomMath.GetHeuristicEstimateBetweenPointsLenght(node.Point, targetPoint), node));
        }
        if (node.Point.z + 1 <= maze.MazeMap.GetUpperBound(1))
        { 
            

            neighbours.Add(new PathNode(new Vector3(node.Point.x, node.Point.y, node.Point.z + 1), node.PathLenghtFromStart + 1, CustomMath.GetHeuristicEstimateBetweenPointsLenght(node.Point, targetPoint), node));
        }
       
        
      
        return neighbours;
    }
    private int GetMinEstimate(List<PathNode> points)
    {
        int min = 0;
        for (int i = 0; i < points.Count; i++)
        {
            if (points[i].EstimateFullPathLenght < points[min].EstimateFullPathLenght)
                min = i;
        }
       
        return min;
    }
}
