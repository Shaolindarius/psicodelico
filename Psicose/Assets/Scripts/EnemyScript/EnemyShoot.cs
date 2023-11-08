using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    private Transform target;

    [SerializeField]
    private Rigidbody2D rb;
    [SerializeField]
    private float speedMove;

    [SerializeField]
    private GameObject bullet;
    [SerializeField]
    private Transform bulletPos;
    [SerializeField]
    private float timerShoot;
    [SerializeField]
    private float shootZone;

    [SerializeField]
    private float scapeZone;

    [SerializeField]
    private LayerMask layerZoneVision;

    [SerializeField]
    private Color areaColor;
    [SerializeField]
    private Color linhaColor;
    [SerializeField]
    private Color scapeColor;
    [SerializeField]
    private SpriteRenderer spriteRenderer;

    private float timer;

    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // pega a tag do player e compara para calcular as informações
    }

    // Update is called once per frame
    void Update()
    {
        Scape();
        if(target != null)
        {
            InvokeRepeating("Move", 0f, 3f);
            
        }
        else
        {
            StopMove();
            float distance = Vector2.Distance(transform.position, player.transform.position);
            if (distance < shootZone)
            {
                timer += Time.deltaTime;

                if (timer > timerShoot)
                {
                    timer = 0;// rest time a cada 2 seg
                    shoot();// chama a função atirar
                }
            }

        }

        
        
        


        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {/*
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Respawn>().LoseLife();
        }
        */
    }
    void shoot()
    {
       Instantiate(bullet,bulletPos.position,Quaternion.identity);
    }

    private void Scape()
    {
        Collider2D colisor = Physics2D.OverlapCircle(this.transform.position, this.scapeZone, this.layerZoneVision);
        if(colisor != null )
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
        if (dist <= this.scapeZone)
        {
            Vector2 dir = posTarget - posNow;
            dir = dir.normalized;
            this.rb.velocity -= (this.speedMove * dir);

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

    private void OnDrawGizmos()
    {
        //visualização de informação
        Gizmos.color = this.areaColor;
        Gizmos.DrawWireSphere(this.transform.position, this.shootZone);

        Gizmos.color = this.scapeColor;
        Gizmos.DrawWireSphere(this.transform.position, this.scapeZone);
        if (this.target != null)
        {
            Gizmos.color = this.linhaColor;
            Gizmos.DrawLine(this.transform.position, this.target.position);
        }
    }
}
