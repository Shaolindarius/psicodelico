using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    private GameObject player;
    private Rigidbody2D rb;
    public float force;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
       /* rb = GetComponent<Rigidbody2D>();
        player = GameObject.FindGameObjectWithTag("Player");
        // identifica a posição do personagem
        Vector3 direction = player.transform.position - transform.position;
        // determina a força do tiro/velocidade
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        // rotação de tiro
        float rot = Mathf.Atan2(-direction.y, -direction.x)* Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0,0,rot+90);*/
    }

    // Update is called once per frame
    // destroir o tiro após 10 seg.
    void Update()
    {
        timer+= Time.deltaTime;

        if(timer>8)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Respawn>().LoseLife();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("IceBullet"))
        {
            collision.gameObject.GetComponent<GeloGround>().Ice();
            
        }

    }
    void OnTriggerEnter2D(Collider2D other)
    {
        // ao acerta o jogador a bala some
        if (other.gameObject.CompareTag("Player"))
        {
            
            // aqui é onde podemos incrementar a queda de vida.
           Destroy(gameObject); 
        }
    }
}
