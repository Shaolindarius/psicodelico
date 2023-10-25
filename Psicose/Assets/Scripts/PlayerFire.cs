using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private Transform fireballPos;
    [SerializeField]
    private float timeFireball;
    [SerializeField]
    private float timeFireballSpeed;

    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (Input.GetKeyUp(KeyCode.E))
        {
            if(timer> timeFireball)
            {
                timer = 0;
                FireballShoot();
            }
            
            
        }
    }

    private void  FireballShoot()
    {
        Instantiate(fireball,fireballPos.position,Quaternion.identity);
        
    }
}
