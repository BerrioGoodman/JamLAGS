using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatrolAI : MonoBehaviour
{
    [Header("Instancias")]
    [SerializeField] private Transform[] waypoints;
    
    [Header("Parametros")]
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float minDistance;
    [SerializeField] private float waitTime;
    
    [Header("Control")]
    private bool isWaiting;
    private int currentWaypoint = 0;
    

    private void Update()
    {

        bool isMovingleft = waypoints[currentWaypoint].position.x < transform.position.x;
        RotateEnemy(isMovingleft);
        
        if (transform.position != waypoints[currentWaypoint].position)
        {
            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypoint].position, patrolSpeed * Time.deltaTime);
            
        }else if (!isWaiting)
        {
            StartCoroutine(Wait()); 
        }
    }

    IEnumerator Wait()
    {
        isWaiting = true;
        yield return new WaitForSeconds(waitTime);
        currentWaypoint++;
        if (currentWaypoint == waypoints.Length)
        {
            currentWaypoint = 0;
        }
        isWaiting = false;
    }

    private void RotateEnemy(bool faceLeft)
    {
        //Rota al enemigo en el eje Y si se mueve a la izquierda
        transform.rotation = Quaternion.Euler(0, faceLeft ? 180 : 0, 0);
    }
}
