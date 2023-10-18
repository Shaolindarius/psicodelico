using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int health = 100;

    private int MAX_HEALTH = 100;

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            Damage(10);
        }
        if (Input.GetKeyDown(KeyCode.R))
        {
            Heal(20);
        }
    }

    public void Damage(int amount)
    {
        if (amount < 0)
        {

        }
        if (health <= 0)
        {
            Die();
        }

        health -= amount;
    }

    public void Heal(int amount)
    {
        if (amount < 0)
        {

        }

        bool wouldBeOverHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverHealth)
        {
            health = MAX_HEALTH;
        }
        else
        {
            health += amount;
        }
    }

    private void Die()
    {
        Debug.Log("Morri");
        Destroy(gameObject);
    }
}
