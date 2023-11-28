using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{
    public int currentBossHealth;
    public int BossHealthController { get; private set;}
    public int health = 150;

    #region life
    [SerializeField]
    private int life;

    [SerializeField]
    private LifeBar lifeBar;

    #endregion life

    public void Start()
    {
        this.lifeBar.MaxLife = this.life;
        this.lifeBar.Life = this.life;
    }

    public void TakeDamage(int dano)
    { 
        health -= dano;

        this.life = life - health;
        ViewFeedBackDano(health);
        this.lifeBar.Life = this.life;
        //possuir vida ainda;


        if (health <= 0)
        {
            if (this.life <= 0)
            {
                this.lifeBar.HideBar();
                Destroy(this.gameObject, 1f);
            }
        }
    }

    private void ViewFeedBackDano(int dano)
    {
        Controlador.Instance.ViewDamage(dano, this.transform.position);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Fireball"))
        {
            TakeDamage(15);
        }
    }

    void Die()
    { 
        Destroy(gameObject);
    }

}
