using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DoctorTHealth : MonoBehaviour
{
    public int BossMaxHealth = 200;
    private int BossCurrentHealh;

    // Start is called before the first frame update
    void Start()
    {
        BossCurrentHealh = BossMaxHealth;
    }

    public void TakeDamage(int damage)
    {
        BossCurrentHealh -= damage;
        if(BossCurrentHealh < 0)
        {
            DefeatBoss();
        }

    }
    
    public void DefeatBoss()
    {
       Destroy(gameObject);
    }
}
