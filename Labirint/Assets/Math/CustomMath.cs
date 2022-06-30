using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class CustomMath
{
   public static float GetHeuristicEstimateBetweenPointsLenght(Vector3 from, Vector3 to)
    {
       
        return Mathf.Abs(from.x - to.x) + Mathf.Abs(from.z - to.z);
    }
}
