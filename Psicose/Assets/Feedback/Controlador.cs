using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Controlador : MonoBehaviour
{
    [SerializeField]
    private FeedbackDano feedbackDanoP;

    private static Controlador instance;

    private void Awake()
    {
        instance = this;
    }

    public static Controlador Instance
    {
        get { return instance; }
    }

    public void ViewDamage(int damage,Vector2 pos)
    {
        FeedbackDano newfeedbackDano = Instantiate(this.feedbackDanoP,pos,Quaternion.identity);
        newfeedbackDano.config(damage);
    }
 
}
