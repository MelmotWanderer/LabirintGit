using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mover : MonoBehaviour
{

    [SerializeField] private float _time;
    
  
   
    public void Move(Vector3 target)
    {
       
        StartCoroutine(Moving(target));
        
    }
    
    private IEnumerator Moving(Vector3 target)
    {
    
        while(transform.position != target)
        {
            yield return new WaitForEndOfFrame();
            transform.position = Vector3.MoveTowards(transform.position, target, Time.deltaTime * _time);

        }
        
        yield break;
    }

    
}
