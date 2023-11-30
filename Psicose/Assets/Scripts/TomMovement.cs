using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TomMovement : MonoBehaviour
{
    [SerializeField]
    Transform target; //Alvo

    [SerializeField]
    public float speedMove = 5f; //Velocidade

    [SerializeField]
    SpriteRenderer spriteRenderer;

    [SerializeField]
    Rigidbody2D rb;

    void Update()
    {
        if (target != null)
        {
            Vector3 position = target.position - transform.position;
            position.Normalize();

            transform.position += position * speedMove * Time.deltaTime;


        }
    }
}
