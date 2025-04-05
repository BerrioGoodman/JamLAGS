using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    private const float maxLifeTime = 3f;
    private float lifeTime = 0f;
    [SerializeField] public Vector2 velocity;
    void Update()
    {
        transform.position += (Vector3)velocity * Time.deltaTime;
        lifeTime += Time.deltaTime;

        if (lifeTime > maxLifeTime) 
        {
            Disable();
        }
    }

    private void Disable()
    {
        lifeTime = 0f;
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player")) 
        {
            Debug.Log("Choqué con el jugador");
        }
    }
}
