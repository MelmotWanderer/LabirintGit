using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class FieldView : MonoBehaviour
{
    [SerializeField] private float distance;
    [SerializeField] private float angle;
    [SerializeField] private float height;
    [SerializeField] private AIMover _enemy;
    [SerializeField] private MeshFilter meshFilter;
    
    
    private Transform _player;
    private FieldOfVievMeshGenerator _fieldOfVievMeshGenerator;

    private void Start()
    { 

        _fieldOfVievMeshGenerator = new FieldOfVievMeshGenerator();
        _player = _enemy._level.Player.transform;

        meshFilter.mesh = _fieldOfVievMeshGenerator.CreateFieldofVievMesh(distance, angle, height);
        
    }
    private void Update()
    {
        CheckPlayer();
    }
    private void CheckPlayer()
    {
        Vector3 dir = (_player.position - _enemy.transform.position).normalized;

        if (Vector3.Angle(dir, _enemy.transform.forward) < angle && Vector3.Distance(_player.position, transform.position) < distance)
        {
            RaycastHit hit;
            if (Physics.Raycast(transform.position, dir, out hit)) {

                if (hit.collider.gameObject == _player.gameObject)
                { 
                    _enemy.FollowPlayer();
                  
                    
                }
                

            }
            
            
        }
    }
   

   
}
