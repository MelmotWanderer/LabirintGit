using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class PlayerMover : CharacterMover
{

    [SerializeField] private Rotator _rotator;
    [SerializeField] private NoiseIndicator _noiseIndicator;
    

    private void Start()
    {
        _currentNode = transform.position;
        _states = new List<State>()
        {
            new Idle(this, _noiseIndicator),
            new Moving(this, _mover, _noiseIndicator)
        };

      SetDefaultState<Idle>();

    }

    private void Update()
    {
        _currentState?.Run();
        Move();
        
    }

   
    public void TryFinish()
    {
   
        if(_level.MazeData.MazeMap[(int)_currentNode.x, (int)_currentNode.z] == 2)
        {
            _level.Victory();
            
        }
    }
    
    private void Move()
    {
        
        if (!isMoving)
        {
            if (Input.GetAxis("Horizontal") == 1 || Input.GetAxis("Horizontal") == -1)
            {
               
                if ((int)_currentNode.x + (int)Input.GetAxis("Horizontal") < 0 || (int)_currentNode.x + (int)Input.GetAxis("Horizontal") > _level.MazeData.MazeMap.GetUpperBound(0)
                    ||  _level.MazeData.MazeMap[(int)_currentNode.x + (int)Input.GetAxis("Horizontal"), (int)_currentNode.z] == 1)
                {
                    return;
                }
              
               
                isMoving = true;
                _currentTarget = _level.MazeData.MazeMesh[(int)_currentNode.x + (int)Input.GetAxis("Horizontal"), (int)_currentNode.z].transform.position;
                 _currentNode = new Vector3(_currentNode.x + (int)Input.GetAxis("Horizontal"), _currentNode.y, _currentNode.z);
                Vector3 direction = (transform.position - _currentTarget).normalized * -1;
                _rotator?.Rotate(direction);
                SwitchMoveState<Moving>();

               

            }
            else if (Input.GetAxis("Vertical") == 1 || Input.GetAxis("Vertical") == -1)
            { 
                if ((int)_currentNode.z + (int)Input.GetAxis("Vertical") < 0 || (int)_currentNode.z + (int)Input.GetAxis("Vertical") > _level.MazeData.MazeMap.GetUpperBound(1)
                    || _level.MazeData.MazeMap[(int)_currentNode.x, (int)_currentNode.z + (int)Input.GetAxis("Vertical")] == 1)
                {
                    return;
                }

             
               

                isMoving = true;
                _currentTarget = _level.MazeData.MazeMesh[(int)_currentNode.x, (int)_currentNode.z + (int)Input.GetAxis("Vertical")].transform.position;
                _currentNode = new Vector3(_currentNode.x, _currentNode.y, _currentNode.z + (int)Input.GetAxis("Vertical"));
                Vector3 direction = (transform.position - _currentTarget).normalized * -1;
                _rotator?.Rotate(direction);
                SwitchMoveState<Moving>();
                
               

            }
           
        }
           
        }
  


    

     
}
