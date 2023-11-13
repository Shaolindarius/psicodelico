using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointHandler : MonoBehaviour
{
    public Transform respawnPoint;

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
        //Outras logicas a serem implementadas
    }
}

