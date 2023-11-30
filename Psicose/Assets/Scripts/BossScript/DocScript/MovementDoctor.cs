using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementDoctor : MonoBehaviour
{
    public Animator anim;

    [SerializeField]
    private Transform target; //Alvo

    [SerializeField]
    private float radioVisio;

    [SerializeField]
    private LayerMask layerZoneVision;

    [SerializeField]
    private float speedMove = 5f;//velocidade
    [SerializeField]
    private float rangedmin;

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Rigidbody2D rb;

    void Update()
    {
        Wanted();
        if (this.target != null)
        {
            Move();// tem alvo           
            
        }
        else
        {
            StopMove();//sem alvo
        }
    }

    private void Wanted()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.radioVisio, this.layerZoneVision);
        if (colisor != null)
        {
            Vector2 posNow = this.transform.position;
            Vector2 posTarget = colisor.transform.position;
            Vector2 dir = posTarget - posNow;
            dir = dir.normalized;

            RaycastHit2D hit = Physics2D.Raycast(posNow, dir);
            if (hit.transform != null)
            {
                if (hit.transform.CompareTag("Player"))
                {
                    this.target = colisor.transform;
                }
                else
                {
                    this.target = null;
                }
            }
            else
            {
                this.target = null;
            }


        }
        else
        {
            this.target = null;
        }
    }

    private void Move()
    {
        Vector2 posTarget = this.target.position;
        Vector2 posNow = this.transform.position;

        float dist = Vector2.Distance(posNow, posTarget);
        if (dist >= this.rangedmin)
        {
            Vector2 dir = posTarget - posNow;
            dir = dir.normalized;
            this.rb.velocity = (this.speedMove * dir);
            anim.SetBool("follow", true);

            //flip sprite

            if (this.rb.velocity.x > 0)
            {
                this.spriteRenderer.flipX = true;
            }
            //***
        }
        else
        {
            StopMove();
        }


    }
    private void StopMove()
    {
        this.rb.velocity = Vector2.zero;
        anim.SetBool("follow", false);
    }
}
