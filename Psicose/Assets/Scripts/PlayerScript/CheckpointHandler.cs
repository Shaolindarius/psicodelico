using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    Vector2 movement;
    public Transform respawnPoint;
    public GameObject Player;

    private void Start()
    {
        transform.position = respawnPoint.position;
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Respawn();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("RespawnPoint"))
        {
            Debug.Log("Salvo");
            respawnPoint = other.gameObject.transform;
        }
    }

    public void Respawn()
    {
        transform.position = respawnPoint.position;

        //Player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        //Player.gameObject.GetComponent<CapsuleCollider2D>().enabled = true;
    }
}

