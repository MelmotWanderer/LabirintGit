using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
[RequireComponent(typeof(Canvas))]
public class EndGameUI: MonoBehaviour
{
    
    [SerializeField] private Text _endGameText;
    [SerializeField] private Button _restartButton;
    [SerializeField] private Level _level;
    [SerializeField] private LevelGenerator _levelGenerator;
    [SerializeField] private Animator _animator;
    private Canvas _canvas;
    private void Awake()
    {
        _canvas = GetComponent<Canvas>();
    }


    private void Start()
     {
        _animator.SetTrigger("Disable");
        _canvas.enabled = false;
        _level.OnEndGame.AddListener(EndGame);
    }


    public void EndGame(string text)
    {
        _endGameText.text = text;
        _animator.SetTrigger("Enable");
        _canvas.enabled = true;
       
    }
     

    public void Restart()
    {
        _animator.SetTrigger("Disable");
      //  _canvas.enabled = false;
        _levelGenerator.GenerateLevel();
    }



  
}
