using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{
    [SerializeField] public Transform player;
    [SerializeField] public Transform RespawnPoint;



    private void OnTriggerEnter2D(Collider2D other)
    {
       if(other.CompareTag("Player"))
       {
            player.transform.position = RespawnPoint.transform.position;
            
       }
    }
}
