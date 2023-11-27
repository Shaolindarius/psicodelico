using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
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

   




    public void Update()
    {
       // if (collision.compareTag("Enemy"))
       // {
          //  TakeDamager(5);
       // }
    }
    public void TakeDamager(int enemy)
    {
        life -= enemy;
        if(life <= 0)
        {
            Player.gameObject.GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            Player.gameObject.GetComponent<CapsuleCollider2D>().enabled = false;
            Player.gameObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
            Player.gameObject.GetComponent<PlayerAttack>().enabled = false;
            Player.gameObject.GetComponent<PlayerMovement>().enabled = false;
            Player.gameObject.GetComponent<SpriteRenderer>().enabled = false;

        }
    }



}
