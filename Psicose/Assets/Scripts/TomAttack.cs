using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomAttack : MonoBehaviour
{
    public Transform player;
    public float range = 3f;
    public int damage = 10;

    public Animator anim;
    public float attackRate = 2f;

    public float nextAttackTime = 3f;
    public bool isAttacking = false;
    public float attackDuration = 2.0f;

    public float attackCooldown = 4.0f;

    public LayerMask attackMask;




    private void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim.GetComponent<Animator>();
    }

    void Update()
    {
        if (Vector3.Distance(player.position, transform.position) <= range)
        {
            Attack();
        }
        else
        {
            StopAttack();
        }

        if (attackCooldown <= 0)
        {
            isAttacking = false;
            attackCooldown = 4.0f;
        }
        else
        {
            attackCooldown -= Time.deltaTime;
        }
    }

    void Attack()
    {
        if (!isAttacking)
        {
            isAttacking = true;
            anim.SetTrigger("Attack");
            Invoke("StopAttack", attackDuration);
        }
        else
        {
            return;
        }

        Collider2D collider = Physics2D.OverlapCircle(transform.position, range, attackMask);
        if (collider != null)
        {
            collider.GetComponent<PlayerManager>().TakeDamage(damage);
        }
    }

    void StopAttack()
    {
        CancelInvoke("Attack");
    }


    private void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, range);
    }

}
