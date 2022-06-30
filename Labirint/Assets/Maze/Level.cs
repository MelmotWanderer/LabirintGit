using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class Level : MonoBehaviour
{
    public MazeData MazeData { get; private set; }
    public PlayerMover Player { get; private set; }

    public List<AIMover> _enemys { get; private set; }
    private NoiseIndicator _noiseIndicator;

   
    [SerializeField] private IndicatorNoiseUI _indicatorNoiseUI;
  

    [HideInInspector] public UnityEvent<string> OnEndGame;
    

    public void Init(MazeData mazeData, PlayerMover player, NoiseIndicator noiseIndicator)
    { 
        MazeData = mazeData;
        Player = player;
        _noiseIndicator = noiseIndicator;
        _noiseIndicator.OnPlayerDetected.AddListener(FollowToPlayerAllEnemys);
        _indicatorNoiseUI.Init(noiseIndicator.GetMaxNoise(),noiseIndicator);
        _indicatorNoiseUI.SetActiveIndicator(true);


    }
    public void SetEnemys(List<AIMover> enemys)
    {
        _enemys = enemys;
      
        
    }

    public void Victory()
    {
        OnEndGame?.Invoke("YOU WIN!");
        _indicatorNoiseUI.SetActiveIndicator(false);
        DisablePlayer();
        DisableAllEnemys();
    }

    public void Defeat()
    {
        OnEndGame?.Invoke("YOU DEFEAT!");
        _indicatorNoiseUI.SetActiveIndicator(false);
        DisablePlayer();
        EnablePatrolModeInAllEnemys();


    }
    
    private void DisableAllEnemys()
    {
        foreach (AIMover enemy in _enemys)
        {
            enemy.gameObject.SetActive(false);
        }
    }

    private void DisablePlayer()
    {
        Player.gameObject.SetActive(false);
    }
    public void FollowToPlayerAllEnemys()
    {
      
        foreach (AIMover enemy in _enemys)
        {
            enemy.FollowPlayer();
        }
    }
    public void EnablePatrolModeInAllEnemys()
    {

        foreach (AIMover enemy in _enemys)
        {
            enemy.Patrol();
        }
    }
}
