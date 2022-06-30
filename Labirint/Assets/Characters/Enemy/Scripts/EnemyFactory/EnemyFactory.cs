using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyFactory : CharacterFactory
{
    
    [SerializeField] private GameObject _enemy;
    [SerializeField] private Color _colorPatrol;
    [SerializeField] private Color _colorFollowPlayer;
    [SerializeField] [Tooltip("The desired distance between the patrol points.")] private int _distanceBetweenPoint;
    [SerializeField] [Tooltip("The number of attempts to obtain the desired distance between patrol points.")] private int _attempsForGettingDisatnceBetweenPoint;
    [SerializeField] private int _countWayPoints;

    [SerializeField] private MusicSwitcher _musicSwitcher;
    public override CharacterMover Create(Vector3 position, Level level)
    {
        var enemy = Instantiate(_enemy, position, Quaternion.identity).GetComponent<AIMover>();

        enemy.InitLevel(level);
        enemy.GetComponent<AIMover>().Init(GenerateWay(enemy.transform.position, level), _musicSwitcher);
        enemy.GetComponent<EnemyCustomization>().SetColors(_colorPatrol, _colorFollowPlayer);
        enemy.SetDefaultState<Patrol>();
        return enemy;
        
    }


    private List<Vector3> GenerateWay(Vector3 currentNode, Level level)
    {
        List<Vector3> wayPoints = new List<Vector3>();
        wayPoints.Add(currentNode);
        
        for (int i = 0; i < _countWayPoints; i++)
        {

            var newPoint = level.MazeData.GetPositionRandomEmptyCell();
            for (int j = 0; j < _attempsForGettingDisatnceBetweenPoint; j++)
                if (Vector3.Distance(newPoint, wayPoints[wayPoints.Count - 1]) < _distanceBetweenPoint)
                {
                    newPoint = level.MazeData.GetPositionRandomEmptyCell();

                }
            wayPoints.Add(newPoint);
        }
    
            
           
            
        
        return wayPoints;
    }
}
