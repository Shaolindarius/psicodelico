using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerFire : MonoBehaviour
{
    [SerializeField]
    private GameObject fireball;
    [SerializeField]
    private Transform fireballPosR;
    [SerializeField]
    private Transform fireballPosL;
    [SerializeField]
    private float timeFireball;
    [SerializeField]
    private float timeFireballSpeed;
    [SerializeField]
    private PlayerMovement player;

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

        Transform attackPoint;
        if (this.player.moveDirection == MoveDirection.Right)
        {
            attackPoint = this.fireballPosR;

        }
        else
        {

            attackPoint = this.fireballPosL;
        }
        Instantiate(fireball,attackPoint.position,Quaternion.identity);
        
    }
}
