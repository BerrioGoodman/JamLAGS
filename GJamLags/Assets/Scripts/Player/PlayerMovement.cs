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
    public static bool isVisible;
    public static bool canInvisible;
    public static float powerDuration = 2f;
    public static float powerCoolDown = 2f;
    [Header("Dash")]
    [SerializeField] private float dashSpeed = 50f;
    [SerializeField] private bool canDash;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private float dashCoolDown = 0.5f;


    void Start()
    {
        canDash = true;
        isVisible = true;
        canInvisible = true;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        if (isDashing) return;
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        if (Input.GetKeyDown(KeyCode.C) && canDash) StartCoroutine(Dash());
        if (Input.GetKeyDown(KeyCode.Space) && canInvisible) StartCoroutine(Invisible());
    }
    private void FixedUpdate()
    {
        if (isDashing) return;
        MovePlayer();
    }
    //Movement Mechanic
    public void MovePlayer()
    {
        rb.MovePosition(rb.position + movement.normalized * speed * Time.fixedDeltaTime);
    }
    //Invisible Mechanic
    public IEnumerator Invisible()
    {
        isVisible = false;
        canInvisible = false;
        sprite.color = color2;
        Debug.Log(isVisible);
        yield return new WaitForSeconds(powerDuration);
        isVisible = true;
        sprite.color = color1;
        yield return new WaitForSeconds(powerCoolDown);
        canInvisible = true;
    }
    //Dash Mechanic
    public IEnumerator Dash()
    {
        canDash = false;
        isDashing = true;
        rb.MovePosition(rb.position + movement * dashSpeed * Time.fixedDeltaTime);
        Debug.Log("Dash");
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
        yield return new WaitForSeconds(dashCoolDown);
        canDash = true;
    }
}
