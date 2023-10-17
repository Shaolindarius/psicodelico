using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot : MonoBehaviour
{
    public GameObject bullet;
    public Transform bulletPos;

    private float timer;
    private GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player"); // pega a tag do player e compara para calcular as informações
    }

    // Update is called once per frame
    void Update()
    {
        

        float distance = Vector2.Distance(transform.position, player.transform.position);
        
        if(distance < 10 )
        {
            timer += Time.deltaTime;

            if(timer > 2)
        {
            timer = 0;// rest time a cada 2 seg
            shoot();// chama a função atirar
        }
        }


        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Respawn>().LoseLife();
        }

    }
    void shoot()
    {
       Instantiate(bullet,bulletPos.position,Quaternion.identity);
    }
}
