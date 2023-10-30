using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    Vector2 Checkpoint;
    SpriteRenderer spriteRenderer;



    private void Awake()
    {
        SpriteRenderer spriteRenderer = GetComponent<SpriteRenderer>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        Checkpoint = transform.position;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy"))
        {
            Die();
        }
    }
    
    void Die()
    {
        StartCoroutine(respawn(0.5f));
    }

    IEnumerator respawn(float duration)
    {
        spriteRenderer.enabled = false;
        yield return new WaitForSeconds(duration);
        transform.position = Checkpoint;
        spriteRenderer.enabled = true;
    }
}
