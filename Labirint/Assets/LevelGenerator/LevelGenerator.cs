using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] private Level _level;
    [SerializeField] private MazeGenerator _mazeGenerator;
    [SerializeField] private PlayerFactory _playerFactory;
    [SerializeField] private EnemyFactory _enemyFactory;
    [SerializeField] private int _countEnemy;
    [SerializeField] private int _desiredDistanceBetweenEnemysAndPlayer;
    [SerializeField] private int _countAttempsGetDesiredDistanceBetweenEnemysAndPlayer;
   


    public void GenerateLevel()
    {
        if(_level.MazeData != null)
        {
            ClearLevel();
        }
        var maze = CreateMaze();


           var player = SetPlayer(maze.MazeMesh[0, 0].transform.position);
           _level.Init(maze, player.GetComponent<PlayerMover>(), player.GetComponent<NoiseIndicator>());
           var enemys = SetEnemys(_level);
           _level.SetEnemys(enemys);



    }
    public void ClearLevel()
    {
        foreach(GameObject prefab in _level.MazeData.MazeMesh)
        {
            Destroy(prefab);
        }
        foreach(AIMover enemy in _level._enemys)
        {
            Destroy(enemy.gameObject);
        }
        Destroy(_level.Player.gameObject);
       
    }
    private MazeData CreateMaze()
    {
        MazeData maze = _mazeGenerator.GenerateMaze();
        SetParentForMaze(maze);
        return maze;
    }
   
    private void SetParentForMaze(MazeData maze)
    {
        foreach (GameObject prefab in maze.MazeMesh)
        {
            SetParent(prefab);
        }
    }
    private void SetParent(GameObject children)
    {
        children.transform.parent = _level.transform;
    }

    private CharacterMover SetPlayer(Vector3 positionPlayer)
    {
        var player = _playerFactory.Create(positionPlayer, _level);
        SetParent(player.gameObject);
        return player;
    }
    private List<AIMover> SetEnemys(Level levelData)
    {
        List<AIMover> enemys = new List<AIMover>();
        for (int i = 0; i < _countEnemy; i++)
        {
            
            Vector3 position = levelData.MazeData.GetPositionRandomEmptyCell();

            while (true) 
            { 
           
                
                if (CustomMath.GetHeuristicEstimateBetweenPointsLenght(position, _level.Player.transform.position) >= _desiredDistanceBetweenEnemysAndPlayer)
                {
                    break;
                }
                
                position = levelData.MazeData.GetPositionRandomEmptyCell();
            }
            
           
            var enemy = _enemyFactory.Create(position, levelData).GetComponent<AIMover>();
            SetParent(enemy.gameObject);
            enemys.Add(enemy);
             
        }
        
        return enemys;
        }

   


}
