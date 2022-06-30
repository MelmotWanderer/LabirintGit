using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : State
{

    private List<Vector3> _path;
    private Vector3 _oldestPositionPlayer;
    private PlayerMover _playerMover;
    private AIMover _mover;
    private Navigation _navigation;
   
    private EnemyCustomization _enemyCustomization;
    private FieldView _fieldView;
    private MusicSwitcher _musicSwitcher;
    private bool isMoving = false;
    
   
    public FollowPlayer(AIMover mover, Navigation navigation, PlayerMover playerMover, EnemyCustomization enemyCustomization = null, FieldView fieldView = null, MusicSwitcher musicSwitcher = null)
    {
        _playerMover = playerMover;
        _navigation = navigation;
        _mover = mover;
        _enemyCustomization = enemyCustomization;
        _fieldView = fieldView;
        _musicSwitcher = musicSwitcher;
    }

    public override void StartState()
    {
        _musicSwitcher?.EnableMusicPlayerDetected();
        _fieldView?.gameObject.SetActive(false);
        _enemyCustomization?.SwitchColorFollowingPlayer();
        _oldestPositionPlayer = _playerMover._currentNode;
       
        _path = _navigation.FindPathToTarget(_mover._level.MazeData, _mover._currentNode, _oldestPositionPlayer);
    }
    public override void Run()
    {
        
        if (_playerMover._currentNode != _oldestPositionPlayer)
        {
            _oldestPositionPlayer = _playerMover._currentNode;
            _path = _navigation.FindPathToTarget(_mover._level.MazeData, _mover._currentNode, _oldestPositionPlayer);
            isMoving = false;
          
           
            

        }
        if (!isMoving)
        {
            isMoving = true;
         
            _mover.Move(_path);
        }

    }
}
