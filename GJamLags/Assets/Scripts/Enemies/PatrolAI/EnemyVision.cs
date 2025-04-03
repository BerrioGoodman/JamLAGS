using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private float viewRadius = 5f;
    [SerializeField][Range(0, 360)] float viewAngle = 90f;
    [SerializeField] LayerMask targetMask;
    [SerializeField] LayerMask obstacleMask;
    public PlayerMovement PlayerMovement;

    public bool PlayerDetected { get; private set; } //Se detecta o no al jugador
    public Transform Player { get; private set; } //Referencia al player

    void Update()
    {
        DetectPlayer();
    }

    void DetectPlayer()
    {
        PlayerDetected = false;
        Player = null;
        Collider2D[] targets = Physics2D.OverlapCircleAll(transform.position, viewRadius, targetMask);//detecta todos los colliders en un circulo y los guarda en un array

        foreach (Collider2D target in targets) //busca todos las collisiones guardadas 
        {
            if (target.CompareTag("Player")) //si la colision detectada tiene el tag del jugador
            {
                Vector2 directionToPlayer = (target.transform.position - transform.position).normalized;//calculamos la direccion entre el enemigo y el jugador

                float angleToPlayer = Vector2.Angle(transform.right, directionToPlayer);//angulo de vision entre el enemigo y el jugador

                if (angleToPlayer < viewAngle / 2)//dividimos entre 2 para tener un angulo de vision de izquiera y derecha
                {
                    float distanceToPlayer = Vector2.Distance(transform.position, target.transform.position);

                    RaycastHit2D hit = Physics2D.Raycast(transform.position, directionToPlayer, distanceToPlayer, obstacleMask);

                    if (hit.collider == null && PlayerMovement.isVisible)
                    {
                        PlayerDetected = true;
                        Player = target.transform;
                        Debug.Log("te veo");
                        return;
                    }
                }
            }
        }


    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, viewRadius);

        Vector3 rightDir = Quaternion.Euler(0,0, viewAngle/2) * transform.right;
        Vector3 leftDir = Quaternion.Euler(0,0, -viewAngle/2) * transform.right;

        Gizmos.color = Color.yellow;
        Gizmos.DrawRay(transform.position, rightDir * viewRadius);
        Gizmos.DrawRay(transform.position, leftDir * viewRadius);
    }
}
