using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fireball : MonoBehaviour
{
    [SerializeField] public float fireballForce = 2f;
    [SerializeField] public Rigidbody2D rb;
    [SerializeField] public int fireballDamage = 10;
    [SerializeField] public bool cooldownfireball = true;
    [SerializeField] public float fireballChase;
    [SerializeField] public GameObject fireballPrefab;
    [SerializeField] public float timer;
    private GameObject enemy;

    // Update is called once per frame

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        enemy = GameObject.FindGameObjectWithTag("Enemy");
       
        Vector3 direction = enemy.transform.position - transform.position;
        rb.velocity = new Vector2 (direction.x, direction.y).normalized * fireballForce;

        float rot = Mathf.Atan2 (-direction.x, -direction.y) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0, 0, rot + 90);




    }
    void Update()
    {
        timer += Time.deltaTime;
        if(timer > 5)
        {
            Destroy(this.gameObject, 5f);
        }

    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            Destroy(this.gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(gameObject,5f);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(this.transform.position, this.fireballChase);
    }
}
