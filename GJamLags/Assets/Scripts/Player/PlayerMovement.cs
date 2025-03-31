using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    private Vector2 movement;
    [Header("Dash")]
    [SerializeField] private float dashForce = 20f;
    [SerializeField] private float dashTime = 2f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        //Movement mechanic
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
        //Dash
        if (Input.GetKey(KeyCode.C) && (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow)))
        {
            rb.AddForce(Vector2.right * dashForce, ForceMode2D.Impulse);
        }
    }
}
