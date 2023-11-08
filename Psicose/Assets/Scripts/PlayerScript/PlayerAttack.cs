using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField]
    public Transform attackPointR;
    [SerializeField]
    public Transform attackPointL;
    [SerializeField]
    public float attackRange;
    [SerializeField]
    public LayerMask EnemyLayers;
    [SerializeField]
    public int attackDamage;

    [SerializeField]
    private PlayerMovement player;


    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            Attack();
        }
    }


    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        if (this.attackPointR != null)
        {
            Gizmos.DrawWireSphere(this.attackPointR.position, this.attackRange);
        }

        if (this.attackPointL != null)
        {
            Gizmos.DrawWireSphere(this.attackPointL.position, this.attackRange);
        }


        Transform attackPoint;
        if (this.player.moveDirection == MoveDirection.Right)
        {
            attackPoint = this.attackPointR;
        }
        else
        {
            attackPoint = this.attackPointL;
        }
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(attackPoint.position, this.attackRange);
    }

    private void Attack()
    {
        Transform attackPoint;
        if(this.player.moveDirection == MoveDirection.Right)
        {
            attackPoint = this.attackPointR;

        }
        else
        { 
        
            attackPoint = this.attackPointL;
        }



        Collider2D[] collidersEnemy = Physics2D.OverlapCircleAll(attackPoint.position, this.attackRange,this.EnemyLayers);
        if(collidersEnemy != null )
        {
            //verifica a existencia de inimigos na area do golpe.

            foreach (Collider2D colliderEnemy in collidersEnemy)
            {
                Enemy_Follow enemy = colliderEnemy.GetComponent<Enemy_Follow>();
                if (enemy != null)
                {
                    enemy.DamageHit(attackDamage);
                }
            }
        }

        /*Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, EnemyLayers);

        foreach (Collider2D enemy in hitEnemies)
        {
            enemy.GetComponent<Enemy_Follow>().DamageHit(attackDamage);
        }
        */
    }



}