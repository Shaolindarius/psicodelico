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
        // Adicione aqui a lógica para o que acontece quando a saúde do objeto (TomHealth) chega a zero ou menos
        Destroy(gameObject);
    }
}
