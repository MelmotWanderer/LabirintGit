using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[RequireComponent(typeof(CharacterController))]
public class Rotator : MonoBehaviour
{
    [SerializeField] private float _speed;
    public void Rotate(Vector3 direction)
    {
        StopAllCoroutines();
        StartCoroutine(RotateCoroutine(direction));
    }


    private IEnumerator RotateCoroutine(Vector3 direction)
    {
        Quaternion quaternionDirection = Quaternion.LookRotation(direction);
        while (transform.rotation != quaternionDirection)
        {
            yield return new WaitForEndOfFrame();

            transform.rotation = Quaternion.RotateTowards(transform.rotation, quaternionDirection, _speed * Time.deltaTime);

        }

        yield break;
    }
}
