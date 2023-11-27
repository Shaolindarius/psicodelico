using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MisterMove : MonoBehaviour
{
    
    private Transform target;
    [SerializeField]
    private float radioChase;
    [SerializeField]
    private LayerMask layerZoneVision;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speedMove;
    [SerializeField]
    private float rangedmin;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Color areaColor;
    [SerializeField]
    private Color lineColor;






    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        Wanted();
        if (this.target != null)
        {
            Move();// tem alvo
                   //VerifyAtk();
        }
        else
        {
            StopMove();//sem alvo
        }

    }


    private void OnDrawGizmos()
    {
        //visualização de informação
        Gizmos.color = this.areaColor;
        Gizmos.DrawWireSphere(this.transform.position, this.radioChase);
        if (this.target != null)
        {
            Gizmos.color = this.lineColor;
            Gizmos.DrawLine(this.transform.position, this.target.position);
        }
    }

    private void Wanted()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.radioChase, this.layerZoneVision);
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
    }
}
