using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int currentBossHealth;
    public int BossHealthController { get; private set; }
    public int health = 150;

    public bool isInvencible = false;



    public void Start()
    {
        currentBossHealth = health;
    }

    public void TakeDamage(int damage)
    {
        if (isInvencible)
        {
            return;
        }

        health -= damage;

        if(health <= 25)
        {
            GetComponent<Animator>().SetBool("FinalMoments", true);
        }

        if (health <= 0)
        {
            Die();
        }


    }

    void Die()
    {
        Destroy(gameObject);
    }
}


