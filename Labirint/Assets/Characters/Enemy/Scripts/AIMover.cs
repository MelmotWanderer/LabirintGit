using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AIMover : CharacterMover, IInteractablePlayer
{
    [SerializeField] private FieldView _fieldView;
    [SerializeField] private Rotator _rotator;

   
    private List<Vector3> _wayPoints;
    private Navigation _navigation;
    private MusicSwitcher _musicSwitcher;
    [HideInInspector] public UnityEvent OnPlayerDetected;
    

    public void Init(List<Vector3> wayPoints, MusicSwitcher musicSwitcher = null)
    {
        _navigation = new Navigation();
        _musicSwitcher = musicSwitcher;
        _wayPoints = wayPoints;
        var customization = GetComponent<EnemyCustomization>();
       
        _states = new List<State>()
        {
            new Patrol(this, _navigation, _level, _wayPoints, customization, _fieldView, _musicSwitcher),
            new FollowPlayer(this, _navigation, _level.Player, customization, _fieldView, _musicSwitcher)
        };

        
        _currentNode = transform.position;
       

    }

    private void Update()
    {
        _currentState?.Run();
    }


    private void OnCollisionEnter(Collision collision)
    {
       
        if (collision.gameObject.GetComponent<PlayerMover>())
        {

            Interact();
        }
    }
    public void Move(List<Vector3> movePath)
    {
        StopAllCoroutines();
        StartCoroutine(Moving(movePath));

    }
    public void Interact()
    {
        _level.Defeat();
        
    }
    public void FollowPlayer()
    {
        StopAllCoroutines();
        OnPlayerDetected?.Invoke();
        SwitchMoveState<FollowPlayer>();
    }

    public void Patrol()
    {
        StopAllCoroutines();
       
        SwitchMoveState<Patrol>();
    }
    private IEnumerator Moving(List<Vector3> movePath)
    {
       
        int i = 0;
      

        while (movePath?.Count > 0)
        {
            yield return new WaitForSeconds(1f);
            _currentNode = _level.MazeData.MazeMesh[(int)movePath[i].x, (int)movePath[i].z].transform.position;
           
            _mover.Move(_level.MazeData.MazeMesh[(int)movePath[i].x, (int)movePath[i].z].transform.position);
            Vector3 direction = (transform.position - _level.MazeData.MazeMesh[(int)movePath[i].x, (int)movePath[i].z].transform.position).normalized * -1;


            _rotator?.Rotate(direction);

            i++;
        }

        yield break;
    }
  


}


