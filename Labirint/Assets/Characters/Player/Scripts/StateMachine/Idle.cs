using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Idle : State
{
  
    private NoiseIndicator _noiseIndicator;
    private PlayerMover _playerMover;

    public Idle(PlayerMover playerMover, NoiseIndicator noiseIndicator)
    {
        _playerMover = playerMover;
        _noiseIndicator = noiseIndicator;
    }
    public override void StartState()
    {

        _noiseIndicator.ReductionNoise();
        
        _playerMover.TryFinish();
    }
    public override void Run()
    {
        
    }

   
    
}
