using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int MaxHealth = 100;
    public int CurrentHealth;
    public Respawn RespawnScript;

    // Start is called before the first frame update
    void Start()
    {
        CurrentHealth = MaxHealth;


    }

    public void TakeDamage(int damage)
    {
        CurrentHealth -= damage;
        Debug.Log("Damage Taken");
        if (CurrentHealth <= 0)
        {
            Die();
        }
        
    }

    public void OnEnterT(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            TakeDamage(10);
        }
    }

    public void Die()
    {

    }

}
