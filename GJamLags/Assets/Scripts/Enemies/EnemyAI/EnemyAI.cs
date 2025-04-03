using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAI : MonoBehaviour
{
    //Estamos definiendo los posibles estados del enemigo
    public enum enemyState 
    {
        Patrol,
        Chase
    }

    #region variables
    [Header("Patrol settings")]
    [SerializeField] private Transform[] waypoints;
    [SerializeField] private float patrolSpeed = 3;
    private int currentWaypoint = 0;

    [Header("Chase settings")]
    [SerializeField] private float chaseSpeed = 4;
    [SerializeField] private float chaseDistance = 4;

    [Header("Referencias")]
    [SerializeField] private EnemyVision EnemyVision;

    //Inicializamos el estado inicial en patrullaje
    private enemyState currentState = enemyState.Patrol;
    #endregion
    void Update()
    {
        //Evaluamos en cada frame el estado en el que se puede encontrar el enemigo
        switch (currentState) 
        {
            case enemyState.Patrol:
                Patrol();
                checkForPlayer();
                break;
            case enemyState.Chase:
                Chase();
                checkIfPlayerLost();
                break;
        }
    }


    //Patrullaje del enemigo
    private void Patrol() 
    {
        if (waypoints.Length == 0) return;//si no hay waypoint, entonces no camina

        Transform target = waypoints[currentWaypoint];//waypoint objetivo
        transform.position = Vector2.MoveTowards(transform.position,target.position,patrolSpeed * Time.deltaTime);//movimiento hacia el waypoint

        //Rotacion del patrullaje
        bool isMovingLeft = target.position.x < transform.position.x;
        transform.rotation = Quaternion.Euler(0, isMovingLeft ? 180 : 0,0);

        //actualizamos la posicion del waypoint
        if (Vector2.Distance(transform.position, target.position) < 0.1f) 
        {
            currentWaypoint = currentWaypoint + 1;
        }

        if (currentWaypoint == waypoints.Length) 
        {
            currentWaypoint = 0;
        }
    }


    //persecucion enemigo
    private void Chase() 
    {
        if (EnemyVision.Player == null) return;//Si no detecta ningun enemigo no lo persigue

        //movimiento hacia el jugador
        transform.position = Vector2.MoveTowards(transform.position, EnemyVision.Player.position, chaseSpeed * Time.deltaTime);

        //Rotacion durante la persecucion
        Vector2 direction = EnemyVision.Player.position - transform.position;
        //direction.Normalize();
        transform.rotation = Quaternion.Euler(0, direction.x < 0 ? 180 : 0, 0);
    }

    private void checkForPlayer() 
    {
        if (EnemyVision.PlayerDetected && EnemyVision.Player != null) 
        {
            currentState = enemyState.Chase;
        }
    }

    private void checkIfPlayerLost() 
    {
        if (!EnemyVision.PlayerDetected || EnemyVision.Player == null) 
        {
            currentState = enemyState.Patrol;
        }
    }
}
