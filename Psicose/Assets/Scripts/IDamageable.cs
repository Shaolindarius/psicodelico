using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Interface para objetos que podem sofrer dano
public interface IDamageable
{
    // Exemplo de um script de vida genérico que implementa a interface IDamageable
    public class Life : MonoBehaviour, IDamageable
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
            Destroy(gameObject);
        }
    }
}

