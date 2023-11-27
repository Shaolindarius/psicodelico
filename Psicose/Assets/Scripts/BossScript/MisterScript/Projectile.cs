using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 moveDirection;
    [SerializeField]private float moveSpeed;

    private void OnEnable()
    {
        Invoke("Destroy", 1f);
    }

     void Start()
    {
       
    }

     void Update()
    {
        transform.Translate(moveDirection * moveSpeed * Time.deltaTime);  
    }

    public  void SetMoveDirection(Vector2 dir)
    {
        moveDirection = dir;
    }

    private void Destroy()
    {
        gameObject.SetActive(false);
    }
    private void OnDisable()
    {
        CancelInvoke();
    }

}
