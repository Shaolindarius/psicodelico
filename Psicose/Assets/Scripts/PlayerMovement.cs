using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f; // Velocidade de movimento do jogador.

    private Rigidbody2D rb;

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
       movement.x = Input.GetAxisRaw("Horizontal");
       movement.y = Input.GetAxisRaw("Vertical");

       animator.SetFloat("Horizontal", movement.x);
       animator.SetFloat("Vertical", movement.y);
       animator.SetFloat("Velocidade", movement.sqrMagnitude);

        Vector3 characterScale = transform.localScale;
        if(movement.x>0)
        {
            characterScale.x = 10;
            this.moveDirection = MoveDirection.Right;

            
        }else if(movement.x<0)
        {
            characterScale.x = -10;
            this.moveDirection= MoveDirection.Left;
        }
        transform.localScale = characterScale;
    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed * Time.fixedDeltaTime);

    }
}
