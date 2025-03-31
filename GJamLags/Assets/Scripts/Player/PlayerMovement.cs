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
    [Header("Invisible")]
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Color color1, color2;
    public static bool isVisible = true;
    public static float power = 10f;
    [Header("Dash")]
    [SerializeField] private float dashForce = 20f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }
    private void FixedUpdate()
    {
        MovePlayer();
        power = Mathf.Clamp(power, -1, 10);
        power += Time.fixedDeltaTime;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (isVisible)
            {
                Invisible();
                power -= Time.fixedDeltaTime;
            }
            else
            {
                Visible();
                power += Time.fixedDeltaTime;
            }
        }
        Dash();
    }
    //Movement Mechanic
    public void MovePlayer()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
    //Invisible Mechanic
    public void Invisible()
    {
        sprite.color = color2;
        isVisible = false;
        Debug.Log(isVisible);
    }
    public void Visible()
    {
        sprite.color = color1;
        isVisible = true;
        Debug.Log(isVisible);
    }
    //Dash Mechanic
    public void Dash()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            rb.AddForce(movement * dashForce, ForceMode2D.Impulse);
            Debug.Log("Dash");
        }
    }
    
}
