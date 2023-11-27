using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour 
{
    public int maxHealth = 100; // Vida máxima do inimigo
    private int currentHealth; // Vida atual do inimigo

    private void Start()
    {
        currentHealth = maxHealth;
    }

    // Método para causar dano ao inimigo
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    // Método para lidar com a morte do inimigo
    private void Die()
    {
        // Implemente o que acontece quando o inimigo morre (por exemplo, reproduzir uma animação, dar pontos ao jogador, destruir o objeto inimigo, etc.).
        Debug.Log("Morreu");
    }
}
