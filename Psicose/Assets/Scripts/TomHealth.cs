using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class TomHealth : MonoBehaviour , IDamageable
{
    public int health = 100;

    public void TakeDamage(int damage)
    {
        health -= damage;

        if (health <= 0)
        {
            Die();
        }
    }

    void Die()
    {
        // Adicione aqui a l�gica para o que acontece quando a sa�de do objeto (TomHealth) chega a zero ou menos
        Destroy(gameObject);
    }
}
