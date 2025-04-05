using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class PlayerMovement : MonoBehaviour
{
    [Header("Movement")]
    public Rigidbody2D rb;
    [SerializeField] private float speed = 5f;
    private Vector2 movement;
    [SerializeField] private Animator animator;
    [Header("Invisible Mechanic")]
    [SerializeField] private SpriteRenderer sprite;
    [SerializeField] private Color color1, color2;
    public static bool isVisible;
    public static bool canInvisible;
    public static float powerDuration = 2f;
    public static float powerCoolDown = 5f;
    [Header("Invisible Power")]
    [SerializeField] private Image invisibleBar;
    [SerializeField] private float invisiblePoints;
    [Header("Dash")]
    [SerializeField] private float dashSpeed = 50f;
    [SerializeField] private bool canDash;
    [SerializeField] private bool isDashing;
    [SerializeField] private float dashDuration = 0.5f;
    [SerializeField] private float dashCoolDown = 0.5f;
    [Header("Healt")]
    [SerializeField] private float healthPoints;
    [SerializeField] private Image healthView;
    [SerializeField] private float damage = 1f;
    private float timer;
    void Start()
    {
        canDash = true;
        isVisible = true;
        canInvisible = true;
        invisiblePoints = 0f;
        healthPoints = 4f;
        rb = GetComponent<Rigidbody2D>();
        sprite = GetComponent<SpriteRenderer>();
    }
    void Update()
    {
        //If is dashing or paused, stop every mechanic
        if (isDashing || PauseMenu.isPaused) return;
        //Inputs for movement
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
        //Animations
        AnimatePlayer();
        //Dash Coroutine
        if (Input.GetKeyDown(KeyCode.C) && canDash) StartCoroutine(Dash());
        //Invisible Coroutine
        if (Input.GetKeyDown(KeyCode.Space) && canInvisible) StartCoroutine(Invisible());
        timer = Mathf.Clamp(timer, 0, 5);
        if (canInvisible) InvisiblePower();
        else LoadPower();
    }
    private void FixedUpdate()
    {
        //If is dashing or paused, stop every mechanic
        if (isDashing || PauseMenu.isPaused) return;
        //Movement method
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
        Debug.Log(isVisible);
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
    //Health
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Damage"))
        {
            healthPoints -= damage;
            healthView.fillAmount = healthPoints / 4f;
        }
    }
    //Invisible power
    public void InvisiblePower()
    {
        invisiblePoints = 2f;
        invisibleBar.fillAmount = invisiblePoints / 2;
    }
    public void LoadPower()
    {
        invisiblePoints = 0f;
        invisibleBar.fillAmount = invisiblePoints / 5;
    }
    public void AnimatePlayer()
    {
        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Speed", movement.sqrMagnitude);
        animator.SetBool("isDashing", isDashing);
        animator.SetBool("isVisible", isVisible);
        if (movement.x < 0)
        {
            Vector3 lS = transform.localScale;
            lS.x = -1;
            transform.localScale = lS;
        }
        else
        {
            Vector3 lS = transform.localScale;
            lS.x = 1;
            transform.localScale = lS;
        }
    }

    public void TakeDamage(int damageAmount) 
    {
        if (isVisible) 
        {
            healthPoints -= damageAmount;
            healthPoints = math.clamp(healthPoints, 0, 4);
            healthView.fillAmount = healthPoints / 4f;

            if (healthPoints <= 0) 
            {
                Debug.Log("Jugador derrotado");
            }
        }
    }
}
