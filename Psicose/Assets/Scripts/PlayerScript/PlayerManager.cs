using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    [SerializeField]
    private int life;
    [SerializeField]
    private GameObject Player;
    [SerializeField]
    private int punchDamager;
    [SerializeField]
    private int fireBallDamager;

    private Renderer rend;
    private Color color;
    [SerializeField]
    private float invTime;

    public bool Death
    {
        get
        {
            return (this.life <= 0);
        }
    }

    
    void Start()
    {
        rend = GetComponent<Renderer>();
        color = rend.material.color;

    }

    public void Update()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            TakeDamage(5);
        }
    }
    public void TakeDamage(int mobhit)
    {
        life -= mobhit;

        StartCoroutine(GetInvuneravel());


        if (life <= 0)
        {
            this.life = 0;
            Player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            Player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            //Player.gameObject.GetComponent<PlayerAttack>().enabled = false;
            //Player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            //Player.gameObject.GetComponent<SpriteRenderer>().enabled = false;
            //Player.gameObject.GetComponent<PlayerFire>().enabled = false;

        }
    }

    IEnumerator GetInvuneravel()
    {
        Physics2D.IgnoreLayerCollision(8, 9, true);
        color.a = 0.6f;
        rend.material.color = color;
        yield return new WaitForSeconds(invTime);
        Physics2D.IgnoreLayerCollision(8, 9, false);
        color.a = 1f;
        rend.material.color = color;
    }

    private void OnEnterTrigger2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bullet"))
        {
            TakeDamage(9);
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            other.GetComponent<DoctorMove>().PunchHit();
            TakeDamage(5);

        }
    }


}