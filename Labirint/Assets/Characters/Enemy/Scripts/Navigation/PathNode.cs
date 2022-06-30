using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class PathNode 
{
    public Vector3 Point { get; set; }
  
    public float PathLenghtFromStart { get; set; }
 
    public float HeuristicEstimatePathLenght { get; set; }
   
    public float EstimateFullPathLenght
    {
        get; private set;
    }
    public PathNode CameFrom;
  
    public PathNode(Vector3 point, float pathLenghtFromStart, float heuristicEstimatePathLenght, PathNode fromNode = null)
    {
       Point = point;
       PathLenghtFromStart = pathLenghtFromStart;
       HeuristicEstimatePathLenght = heuristicEstimatePathLenght;
       CameFrom = fromNode;
        EstimateFullPathLenght = pathLenghtFromStart + HeuristicEstimatePathLenght;
    }
   
   
}
