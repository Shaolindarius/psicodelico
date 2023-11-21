using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int currentBossHealth;
    public int BossHealthController { get; private set;}
    public int health = 150;

    public bool isInvulnerable = false;

    public void TakeDamage(int damageAmount)
    {
        if (isInvulnerable)
            return;

        health -= damageAmount;

        if (health <= 75)
        {
          
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
