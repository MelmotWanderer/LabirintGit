using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(Mover))]
public abstract class CharacterMover : MonoBehaviour
{
    public Vector3 _currentTarget { get; protected set; }
    public Vector3 _currentNode { get; protected set; }

    [SerializeField] protected Mover _mover;
    [SerializeField] private float _speed;
    protected State _currentState;
    protected List<State> _states;
    protected bool isMoving;
    public Level _level { get; private set; }
    
    public void InitLevel(Level level)
    {
        _level = level;
    }
    public void SetCurrentTarget(Vector3 currentTarget)
    {
        _currentTarget = currentTarget;
    }
    public void SwitchMoveState<T>() where T : State
    {
        var state = _states.Find(s => s is T);
        _currentState.Stop();
        _currentState = state;
        _currentState.StartState();
    }

    public void SetDefaultState<T>() where T : State
    {
        var state = _states.Find(s => s is T);
        state.StartState();
        _currentState = state;
    }

    public void Wait()
    {
       
        StartCoroutine(WaitCoroutine());
    }
    protected IEnumerator WaitCoroutine()
    {
        yield return new WaitForSeconds(_speed);
        isMoving = false;
        yield break;
    }
    

    
}
