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

    [Header("Attack settings")]
    [SerializeField] private float attackRange = 1.5f;
    [SerializeField] private int attackDamage = 10;
    [SerializeField] private float attackCooldown = 2f;
    [SerializeField] private LayerMask playerLayer;
    [SerializeField] private BoxCollider2D attackHitbox;
    private float _lastAttackTime;

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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
                checkIfPlayerLost();
                break;
=======
                CheckAttackConditions(); // Nueva verificación
=======
<<<<<<< Updated upstream
                CheckAttackConditions(); // Nueva verificación
=======
                checkAttackConditions();
                break;
            case enemyState.Attack:
                Attack();
                checkIfPlayerOutOfRange();
>>>>>>> Stashed changes
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
                break;
            case enemyState.Attack:
                Attack(); // Nuevo estado
                CheckIfPlayerOutOfRange();
                break;

<<<<<<< HEAD
>>>>>>> parent of d9bef5e (changes)
=======
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
=======
                checkIfPlayerLost();
                break;
>>>>>>> parent of f679069 (state machine meele enemies)
        }
    }

<<<<<<< Updated upstream

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    //Patrullaje del enemigo
    private void Patrol() 
=======
    #region attack
    private void Attack()
    {
        Debug.Log("Estado: ATAQUE - Iniciando ataque");

        // Detener movimiento durante el ataque
        transform.position = transform.position;

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            StartCoroutine(PerformAttack());
            lastAttackTime = Time.time;
        }
    }

    private IEnumerator PerformAttack()
    {
        Debug.Log("ATAQUE - Activando hitbox de daño");
        attackHitbox.enabled = true;

        yield return new WaitForSeconds(0.2f);

        Debug.Log("ATAQUE - Desactivando hitbox de daño");
        attackHitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            Debug.Log("¡ATAQUE CONECTADO! - Jugador golpeado");
            //logica de player health
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Debug visual del rango de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Debug visual del hitbox de ataque
        if (attackHitbox != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(attackHitbox.bounds.center, attackHitbox.bounds.size);
        }
    }

    #endregion

    #region Patrol
    private void Patrol()
>>>>>>> parent of d9bef5e (changes)
=======
    #region attack
    private void Attack()
    {
        Debug.Log("Estado: ATAQUE - Iniciando ataque");

        // Detener movimiento durante el ataque
        transform.position = transform.position;

        if (Time.time - lastAttackTime >= attackCooldown)
        {
            StartCoroutine(PerformAttack());
            lastAttackTime = Time.time;
        }
    }

    private IEnumerator PerformAttack()
    {
        Debug.Log("ATAQUE - Activando hitbox de daño");
        attackHitbox.enabled = true;

        yield return new WaitForSeconds(0.2f);

        Debug.Log("ATAQUE - Desactivando hitbox de daño");
        attackHitbox.enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (((1 << other.gameObject.layer) & playerLayer) != 0)
        {
            Debug.Log("¡ATAQUE CONECTADO! - Jugador golpeado");
            //logica de player health
        }
    }

    private void OnDrawGizmosSelected()
    {
        // Debug visual del rango de ataque
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, attackRange);

        // Debug visual del hitbox de ataque
        if (attackHitbox != null)
        {
            Gizmos.color = Color.magenta;
            Gizmos.DrawWireCube(attackHitbox.bounds.center, attackHitbox.bounds.size);
        }
    }

    #endregion

    #region Patrol
=======
    #region funciones
    //Patrullaje del enemigo
>>>>>>> Stashed changes
    private void Patrol()
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
=======
    //Patrullaje del enemigo
    private void Patrol() 
>>>>>>> parent of f679069 (state machine meele enemies)
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD

=======
    #region chase
>>>>>>> parent of d9bef5e (changes)
=======
<<<<<<< Updated upstream
    #region chase
=======
>>>>>>> Stashed changes
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
=======

>>>>>>> parent of f679069 (state machine meele enemies)
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

<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
    private void checkForPlayer() 
=======
    #region transitions
    private void checkForPlayer()
>>>>>>> parent of d9bef5e (changes)
=======
<<<<<<< Updated upstream
    #region transitions
    private void checkForPlayer()
=======
    private void Attack() 
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
    {
        //detener el movimiento durante el ataque
        transform.position = transform.position;

        //activar hitbox y hacer daño
        if (Time.time - _lastAttackTime >= attackCooldown)
        {
            _lastAttackTime = Time.time;
            
            StartCoroutine(performAttack());
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (((1 << collision.gameObject.layer) & playerLayer) != 0)
        {
            Debug.Log("Ataque conseguido");
            Debug.DrawRay(collision.transform.position, Vector2.up * 2f, Color.red, 2f);
        }

    }

    private IEnumerator performAttack() 
    {
        //activar la hitbox
        attackHitbox.enabled = true;

        //esperar un frame para detectar colisiones
        yield return new WaitForSeconds(0.1f);

        //desactivar hitbox despues del tiempo de ataque
        attackHitbox.enabled = false;
    }
    #endregion


    #region transiciones
    private void checkForPlayer() 
>>>>>>> Stashed changes
=======
    private void checkForPlayer() 
>>>>>>> parent of f679069 (state machine meele enemies)
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
<<<<<<< HEAD
<<<<<<< HEAD
<<<<<<< HEAD
=======

=======

<<<<<<< Updated upstream
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
    private void CheckAttackConditions()
    {
        if (EnemyVision.Player == null) return;

        float distance = Vector2.Distance(transform.position, EnemyVision.Player.position);
        //Debug.Log($"Distancia al jugador: {distance.ToString("F2")}");

        if (distance <= attackRange)
        {
            Debug.Log("Jugador en rango de ataque - Cambiando a estado ATAQUE");
<<<<<<< HEAD
=======
=======
    private void checkAttackConditions() 
    {
        if (EnemyVision.Player == null) return;

        float distanceToPlayer = Vector2.Distance(transform.position, EnemyVision.Player.position);
        if (distanceToPlayer <= attackRange)
        {
>>>>>>> Stashed changes
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
            currentState = enemyState.Attack;
        }
    }

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
    private void CheckIfPlayerOutOfRange()
    {
        if (EnemyVision.Player == null)
        {
            Debug.Log("Jugador perdido - Volviendo a PATRULLA");
<<<<<<< HEAD
=======
=======
    //vuelve a chase si el enemigo esta fuera de rango
    private void checkIfPlayerOutOfRange() 
    {
        if (EnemyVision.Player == null) 
        {
>>>>>>> Stashed changes
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
            currentState = enemyState.Patrol;
            return;
        }

<<<<<<< HEAD
=======
<<<<<<< Updated upstream
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
        float distance = Vector2.Distance(transform.position, EnemyVision.Player.position);
        if (distance > attackRange)
        {
            Debug.Log("Jugador fuera de rango - Volviendo a PERSECUCIÓN");
<<<<<<< HEAD
=======
=======
        float distanceToPlayer = Vector2.Distance(transform.position, EnemyVision.Player.position);

        if (distanceToPlayer > attackRange)
        {
>>>>>>> Stashed changes
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
            currentState = enemyState.Chase;
        }
    }
    #endregion
<<<<<<< HEAD

>>>>>>> parent of d9bef5e (changes)
=======
<<<<<<< Updated upstream

=======
>>>>>>> Stashed changes
>>>>>>> parent of 09f1a8e (Revert "Merge branch 'DevAlejo'")
=======
>>>>>>> parent of f679069 (state machine meele enemies)
}
