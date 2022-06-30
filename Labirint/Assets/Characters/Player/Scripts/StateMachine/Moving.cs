using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving : State
{
    Mover _mover;
    PlayerMover _playerMover;
    NoiseIndicator _noiseIndicator;
    public Moving(PlayerMover playerMover, Mover mover, NoiseIndicator noiseIndicator)
    {
        _noiseIndicator = noiseIndicator;
        _playerMover = playerMover;
        _mover = mover;
    }

    public override void StartState()
    {
        _mover.Move(_playerMover._currentTarget);
        _noiseIndicator.AddNoise();
    }
    public override void Run()
    {
        if (_playerMover.transform.position == _playerMover._currentTarget)
        {
            
            _playerMover.Wait();
            _playerMover.SwitchMoveState<Idle>();
        }
    }
}
