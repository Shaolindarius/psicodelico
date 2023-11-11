using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MisterPower : MonoBehaviour
{
    public static MisterPower misterPowerInstance;


    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private bool notEnoughBulletsInPool = true;
    private List<GameObject> bullets;
    //[SerializeField] private float bulletMoveSpeed;
    [SerializeField] private int bulletDamaged;


    private void Awake()
    {
        misterPowerInstance = this;
    }

    void Start()
    {
        bullets = new List<GameObject>();
    }

    public GameObject GetBullet()
    {
        if (bullets.Count > 0)
        {
            for(int i = 0;i<bullets.Count;i++)
            {
                if (!bullets[i].activeInHierarchy)
                {
                    return bullets[i];
                }
            }
        }


        if (notEnoughBulletsInPool)
        {
            GameObject bul = Instantiate(bulletPrefab);
            bul.SetActive(false);
            bullets.Add(bul);
            return bul;
        }
        return null;

    }

    public void Attack()
    {
        
    }
 
}
