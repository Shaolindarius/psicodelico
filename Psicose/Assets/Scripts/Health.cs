using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] public int health = 100;
    public float respawnDelay = 2.0f;
    private bool isRespawning = false;
    private Vector3 respawnPosition;

    private int MAX_HEALTH = 100;

    private void OnEnterCollision2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
		{
			Damage(10);
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

    public void Respawn()
	{
		GameObject[] checkpoints = GameObject.FindGameObjectsWithTag("Checkpoint");
        health = MAX_HEALTH;
        isRespawning = false;

        if (checkpoints.Length > 0)
        {
            // Encontre o checkpoint mais próximo
            float minDistance = float.MaxValue;
            GameObject nearestCheckpoint = null;

            foreach (GameObject checkpoint in checkpoints)
            {
                float distance = Vector3.Distance(transform.position, checkpoint.transform.position);
                if (distance < minDistance)
                {
                    minDistance = distance;
                    nearestCheckpoint = checkpoint;
                }
            }

           
            respawnPosition = nearestCheckpoint.GetComponent<Checkpoint>().respawnPosition;
        }

        
        transform.position = respawnPosition;
    }
	

    private void Die()
    {
        if (!isRespawning)
        {
            //Debug.Log("Morri");
            isRespawning = true;
         
            Invoke("Respawn", respawnDelay);
        }
    }
}
