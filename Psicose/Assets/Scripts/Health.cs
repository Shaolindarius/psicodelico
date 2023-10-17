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

    private void Damage(int amount)
    {
        if (amount < 0)
        {

        }
        if (health <= 0)
        {
            Die();
        }

        this.health -= amount;
    }

    private void Heal(int amount)
    {
        if (amount < 0)
        {

        }

        bool wouldBeOverHealth = health + amount > MAX_HEALTH;

        if (wouldBeOverHealth)
        {
            this.health = MAX_HEALTH;

        }
        else
        {
            this.health += amount;
        }

    }

    private void Die()
    {
        Debug.Log("Morri");
        Destroy(gameObject);
    }
}