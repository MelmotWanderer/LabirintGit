using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Canvas))]
public class MainMenuUI : MonoBehaviour
{
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private Button startButton;
    [SerializeField] private Animator _animator;
    
    

  


    public void StartGame()
    {
        _animator.SetTrigger("Disable");
        
        _levelGenerator.GenerateLevel();

    }
 }
