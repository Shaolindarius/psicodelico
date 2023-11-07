using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
  
    public float speed = 5f;
    [SerializeField] public float dashSpeed = 5f;
    [SerializeField] public float dashDuration = 2f;
    [SerializeField] public float dashCooldown = 3f;

    bool isDashing;

    public Rigidbody2D rb;

    Vector2 movement;
    public Animator animator;


    public MoveDirection moveDirection;



    void Start()
    {
        
        rb = GetComponent<Rigidbody2D>();
        this.moveDirection = MoveDirection.Right;
    }

    void Update()
    {
        if(isDashing)
        {
            return;
        }
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        animator.SetFloat("Horizontal", movement.x);
        animator.SetFloat("Vertical", movement.y);
        animator.SetFloat("Velocidade", movement.sqrMagnitude);

        if (movement.x > 0)
        {

            this.moveDirection = MoveDirection.Right;


        }
        else if (movement.x < 0)
        {

            this.moveDirection = MoveDirection.Left;
        }

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartCoroutine(Dash());
        }

      
    }

    private IEnumerator Dash()
    {
        isDashing = true;
        rb.velocity = new Vector2(movement.x * dashSpeed, movement.y * dashSpeed);
        yield return new WaitForSeconds(dashDuration);
        isDashing = false;
    }
    

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);
    }
}