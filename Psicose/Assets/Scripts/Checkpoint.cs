using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3 respawnPosition;

    private void Start()
    {
        // Inicialize a posição de respawn com a posição do checkpoint
        respawnPosition = transform.position;
    }
}
