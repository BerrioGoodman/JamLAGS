using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AIchase : MonoBehaviour
{
    public float speed;
    public float distanceBetween;
    [SerializeField]private EnemyVision enemyVision;
    [SerializeField]private EnemyPatrol enemPatrol;
   
    void Start()
    {
        
    }

   
    void Update()
    {

        if (enemyVision.PlayerDetected && enemyVision.Player != null)
        {
            chase();
        } 
        else 
        {
            this.enabled = false;
            enemPatrol.enabled = true;
        }

        
    }

    private void chase() 
    {
        float distance = Vector2.Distance(transform.position, enemyVision.Player.transform.position);
        if (distance < distanceBetween) 
        {
            transform.position = Vector2.MoveTowards(transform.position, enemyVision.Player.transform.position, speed * Time.deltaTime);
        }


        Vector2 direction = enemyVision.Player.transform.position - transform.position;
        direction.Normalize();
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;  
        transform.rotation = Quaternion.Euler(0, direction.x < 0 ? 180 : 0, angle);
        
    }
}
