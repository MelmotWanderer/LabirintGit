using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeData
{
    public int[,] MazeMap { get; private set; }
    public GameObject[,] MazeMesh { get; private set; }
    


   public MazeData(int[,] mazeMap, GameObject[,] mazeMesh)
    {
        MazeMap = mazeMap;
        MazeMesh = mazeMesh;
    }

  public Vector3 GetPositionRandomEmptyCell()
    {
        while (true)
        {
            int i = Random.Range(0, MazeMap.GetUpperBound(0));
            int j = Random.Range(0, MazeMap.GetUpperBound(1));
            var cell = MazeMap[i, j];
            if (cell == 0)
            {
               
                return MazeMesh[i, j].transform.position;
            }
        }
       

      
    }
}
