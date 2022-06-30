using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrol : State
{
    private AIMover _mover;
    private Level _level;
    private List<Vector3> _path;
    private List<Vector3> _wayPoints;
    private Navigation _navigation;    
    private FieldView _fieldView;
    private EnemyCustomization _enemyCustomization;
    private int _currentWayPointIndex;
    private MusicSwitcher _musicSwitcher;
    private bool isMoving =false;
    
    public Patrol(AIMover mover, Navigation navigation, Level level, List<Vector3> wayPoints, EnemyCustomization enemyCustomization = null, FieldView fieldView = null, MusicSwitcher musicSwitcher = null)
    {
        _wayPoints = wayPoints;
        _navigation = navigation;
        _level = level;
        _mover = mover;
        _enemyCustomization = enemyCustomization;
        _fieldView = fieldView;
        _musicSwitcher = musicSwitcher;
    }

    public override void StartState()
    {
        _musicSwitcher?.EnableMusicPlayerNotDetected();
        _enemyCustomization?.SwitchColorPatrol();
        _fieldView?.gameObject.SetActive(true);
        _currentWayPointIndex = 0;
        _path = _navigation.FindPathToTarget(_level.MazeData, _mover._currentNode, _wayPoints[_currentWayPointIndex + 1]);
       
    }
    public override void Run()
    {
       if(_path != null)
        {
            if (!isMoving)
            {
                _mover.Move(_path);
                _currentWayPointIndex += 1;
                isMoving = true;
            }
            else
            {

                if (_path[_path.Count - 1] == _mover.transform.position)
                {
                    isMoving = false;

                    _currentWayPointIndex = 0;

                    _path?.Reverse();

                }
            }
        }
       
       
        
       
      
    }
}
