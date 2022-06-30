using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeMeshGenerator : MonoBehaviour
{

    private GameObject _floorPrefab;
    private GameObject _wallPrefab;
    private GameObject _finalFloorPrefab;
    

    public MazeMeshGenerator(GameObject floorPrefab, GameObject wallPrefab, GameObject finalFloorPrefab)
    {
        _floorPrefab = floorPrefab;
        _wallPrefab = wallPrefab;
        _finalFloorPrefab = finalFloorPrefab;
    }



    public GameObject[,] Generate(int[,] mazeData)
    {
        
         
        int rMax = mazeData.GetUpperBound(0);
        int cMax = mazeData.GetUpperBound(1);
        GameObject[,] mazeMesh = new GameObject[rMax+1, cMax+1];

        for (int i = 0; i <= rMax; i++)
        {
            for(int j = 0; j <= cMax; j++)
            {

                if (mazeData[i, j] == 2)
                {
                    mazeMesh[i, j] = Instantiate(_finalFloorPrefab, new Vector3(_finalFloorPrefab.transform.localScale.x * i, 0, _finalFloorPrefab.transform.localScale.x * j), Quaternion.identity);
                    break;
                }
                if (mazeData[i, j] == 1)
                {
                    mazeMesh[i, j] = Instantiate(_wallPrefab, new Vector3(_wallPrefab.transform.localScale.x * i, 0, _wallPrefab.transform.localScale.z * j), Quaternion.identity);
                }
                else if(mazeData[i, j] == 0)
                {
                    mazeMesh[i, j] = Instantiate(_floorPrefab, new Vector3(_floorPrefab.transform.localScale.x * i, 0, _wallPrefab.transform.localScale.x * j), Quaternion.identity);
                }
                

            }
        }
        return mazeMesh;
    }
}
