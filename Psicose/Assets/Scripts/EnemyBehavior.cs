using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour 
{
    public int maxHealth = 100; // Vida m�xima do inimigo
    private int currentHealth; // Vida atual do inimigo

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // M�todo para causar dano ao inimigo
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // M�todo para lidar com a morte do inimigo
    private void Die()
    {
        // Implemente o que acontece quando o inimigo morre (por exemplo, reproduzir uma anima��o, dar pontos ao jogador, destruir o objeto inimigo, etc.).
        Debug.Log("Morreu");
    }
}
