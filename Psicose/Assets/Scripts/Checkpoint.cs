using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Checkpoint : MonoBehaviour
{
    public Vector3 respawnPosition;

    private void Start()
    {
        // Inicialize a posi��o de respawn com a posi��o do checkpoint
        respawnPosition = transform.position;
    }
}
