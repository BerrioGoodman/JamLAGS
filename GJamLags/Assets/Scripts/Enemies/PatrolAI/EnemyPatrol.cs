using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPatrol : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float enemySpeed = 3f;
    [SerializeField] EnemyVision EnemyVision;
    private int currentWaypoint = 0;
    

    private void Update()
    {
        if(waypoints.Length == 0) return; 

        Transform target = waypoints[currentWaypoint];
        transform.position = Vector2.MoveTowards(transform.position, target.position, enemySpeed * Time.deltaTime);

        //la posicion del waypoint en X es menor a la posicion del enemigo en X
        bool isMovingLeft = target.position.x < transform.position.x;
        RotateEnemy(isMovingLeft);

        if (Vector2.Distance(transform.position, target.position) < 0.1f) 
        {
            currentWaypoint = currentWaypoint + 1;
        }

        if (currentWaypoint == waypoints.Length) 
        {
            currentWaypoint = 0;
        }  
    }

    private void RotateEnemy(bool faceLeft) 
    {
        //Rota al enemigo en el eje Y si se mueve a la izquierda
        transform.rotation = Quaternion.Euler(0, faceLeft ? 180 : 0, 0);
    }
}
