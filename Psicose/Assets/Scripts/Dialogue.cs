using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dialogue : MonoBehaviour
{
    public Sprite profile;
    public string speechTxt;
    public string ActorsName;

    public LayerMask playerLayer;

    private DialogueControl dc;

    public float radious;

    private void Start()
    {
        dc = FindObjectOfType<DialogueControl>();
    }

    private void FixedUpdate()
    {
       Interact();
    }

    public void Interact()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, radious, playerLayer);
        if (hit != null)
        {
            dc.Speech(profile, speechTxt, ActorsName);
        }
    }

    public void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, radious);
    }

}
