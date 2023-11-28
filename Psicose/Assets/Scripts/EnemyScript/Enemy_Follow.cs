using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Follow : MonoBehaviour
{
    #region Padrao de movimenta��o
    #region movimentacao Player
    //[SerializeField]
    private Transform target;// alvo

    [SerializeField]
    private float speedMove;//velocidade

    [SerializeField]
    private Rigidbody2D rb;//rigidbody

    [SerializeField]
    private float rangedmin;
    #endregion movimenta��o Player
    [SerializeField]
    private float radioVisio;

    [SerializeField]
    private LayerMask layerZoneVision;

    [SerializeField]
    private SpriteRenderer spriteRenderer;

    [SerializeField]
    private Color areaColor;

    [SerializeField]
    private Color linhaColor;
    #endregion Padrao de movimenta��o

    [SerializeField]
    private float distanceAtk;

    [SerializeField]
    private float timeAtk;

    private float timeWaitAtk;


    #region life
    [SerializeField]
    private int life;

    [SerializeField]
    private LifeBar lifeBar;

    #endregion life


    private void Start()
    {
        this.timeWaitAtk = this.timeAtk;
        this.lifeBar.MaxLife = this.life;
        this.lifeBar.Life = this.life;
    }


    void Update()
    {
        Wanted();
        if (this.target != null)
        {
            Move();// tem alvo
            VerifyAtk();
        }
        else
        {
            StopMove();//sem alvo
        }



    }

    private void OnDrawGizmos()
    {
        //visualiza��o de informa��o
        Gizmos.color = this.areaColor;
        Gizmos.DrawWireSphere(this.transform.position, this.radioVisio);
        if (this.target != null)
        {
            Gizmos.color = this.linhaColor;
            Gizmos.DrawLine(this.transform.position, this.target.position);
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


    public void Combat()
    {
        PlayerManager player = this.target.GetComponent<PlayerManager>();
        player.TakeDamage(2);

    }

    private void VerifyAtk()
    {
        PlayerManager player = this.target.GetComponent<PlayerManager>();
        if (player.Death)
        {
            return;
        }


        float distance = Vector3.Distance(this.transform.position, this.target.position);
        if (distance <= this.distanceAtk)
        {
            this.timeWaitAtk -= Time.deltaTime;
            if (this.timeWaitAtk <= 0)
            {
                this.timeWaitAtk = this.timeAtk;
                Combat();
            }
        }

    }


    // fun��o de dano recebido do inimigo
    public void DamageHit(int dano)
    {
        int hit = dano;
        if (this.life > 0)
        {
            this.life = life - hit;
            ViewFeedBackDano(hit);
            this.lifeBar.Life = this.life;
            //possuir vida ainda;




            if (this.life <= 0)
            {
                this.lifeBar.HideBar();
                StopMove();
                Destroy(this.gameObject, 1f);
            }

        }



    }
    //fun��o de feedback de dano recebido.
    private void ViewFeedBackDano(int dano)
    {
        Controlador.Instance.ViewDamage(dano, this.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireball"))
        {
            DamageHit(15);
        }
    }
}
