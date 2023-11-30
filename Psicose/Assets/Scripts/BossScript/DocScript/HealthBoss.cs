using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static IDamageable;

public class HealthBoss : MonoBehaviour
{
    public int health = 100;

    public bool isInvulnerable = false;
    public Animator anim;




    public void TakeDamage(int mobhit)
    {
        health -= mobhit;

       
        if (health <= 0)
        {
            this.health = 0;
            Die();
            //Player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            //Player.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;


        }
    }


    void Die()
    {
        anim.SetBool("dead", true);
        Destroy(gameObject,5f);
    }
}
