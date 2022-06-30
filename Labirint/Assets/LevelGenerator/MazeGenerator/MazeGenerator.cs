using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    public int[,] MazeMap { get; private set; }
   
    [SerializeField] private int _widthMaze;
    [SerializeField] private int _lengthMaze;
    [SerializeField] private float _placementThreshold;
    [SerializeField] private GameObject _floorPrefab;
    [SerializeField] private GameObject _wallPrefab;
    [SerializeField] private GameObject _finalFloorPrefab;
    private MazeGeneratorMap _mazeGeneratorData;
    private MazeMeshGenerator _mazeMeshGenerator;
    private GameObject[,] _mazeMesh;


    private void Awake()
    {
        
        _mazeGeneratorData = new MazeGeneratorMap(_placementThreshold);
        _mazeMeshGenerator = new MazeMeshGenerator(_floorPrefab, _wallPrefab, _finalFloorPrefab);
      
       
    }

   
    public MazeData GenerateMaze()
    {
        
        MazeMap = _mazeGeneratorData.Generate(_widthMaze, _lengthMaze);
      _mazeMesh = _mazeMeshGenerator.Generate(MazeMap);
      MazeData maze = new MazeData(MazeMap, _mazeMesh);
       
        return maze;
       

    }
    public void ClearMaze()
    {
      
        foreach(GameObject cell in _mazeMesh)
        {
            Destroy(cell);
        }
        _mazeMesh = null;
    }
  
}
