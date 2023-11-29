using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerManager : MonoBehaviour
{

    [SerializeField]
    private int life;
    int lifeNow;
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

    public Image redBar;
    public Image greenBar;


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
        lifeNow = life;

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
        LifeBar();

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

    private void LifeBar()
    {
       Vector3 lifeBarScale  = greenBar.rectTransform.localScale;
        lifeBarScale.x = (float)life / lifeNow;
        greenBar.rectTransform.localScale = lifeBarScale;
        StartCoroutine(RedBarDown(lifeBarScale));

    }

    IEnumerator RedBarDown(Vector3 newScale)
    {
        yield return new WaitForSeconds(1);
        Vector3 redBarScale = redBar.transform.localScale;
        while (redBar.transform.localScale.x > newScale.x)
        {
            redBarScale.x -= Time.deltaTime * 0.25f;
            redBar.transform.localScale = redBarScale;

            yield return null;
        }
        redBar.transform.localScale = newScale;
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
            TakeDamage(2);
        }

        if (other.gameObject.CompareTag("Boss"))
        {
            other.GetComponent<DoctorMove>().PunchHit();
            TakeDamage(5);

        }
    }


}