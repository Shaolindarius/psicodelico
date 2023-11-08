using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorTAttack : MonoBehaviour
{
    public int DamageAmount = 7;


    
    [SerializeField]
    private float DistanceAtk;

    [SerializeField]
    private float TimeAtk;

    [SerializeField]
    private float CoolDownTimeAtk;
    
    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.CompareTag("Player"))
        {
            //PlayerHealth.TakeDamage(DamageAmount);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
