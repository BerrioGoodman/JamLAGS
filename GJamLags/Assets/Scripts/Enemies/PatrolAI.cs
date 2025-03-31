using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class PatrolAI : MonoBehaviour
{
    [Header("Instancias")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private Rigidbody2D rbEnemy;
    
    [Header("Parametros")]
    [SerializeField] private float patrolSpeed;
    [SerializeField] private float minDistance;
    [SerializeField] private float waitTime;
    
    [Header("Control")]
    private bool isWaiting;
    private int currentWaypoint = 0;
    
    
    private void Start()
    {
        rbEnemy = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        
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
}
