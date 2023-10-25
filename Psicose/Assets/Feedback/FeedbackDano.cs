using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FeedbackDano : MonoBehaviour
{
    [SerializeField]
    private TextMeshProUGUI textDamage;

    [SerializeField]
    private float textMove;

    [SerializeField]
    private float textMoveSpeed;

    [SerializeField]
    private float textTime;

    private Vector2 posEnd;


    
    void Start()
    {
        this.posEnd = this.transform.position;
        this.posEnd.y = this.textMove;
        
    }

    
    void Update()
    {
        // movimentação do texto;
        this.transform.position=Vector2.Lerp(this.transform.position, this.posEnd, this.textMoveSpeed*Time.deltaTime);
        float distanceNow = Vector2.Distance(this.transform.position,this.posEnd);

        if (distanceNow <= this.textTime)
        {
            Destroy(this.gameObject);
        }
        
    }

    

    public void config(int danoVar)
    {
        this.textDamage.text = "-" + danoVar.ToString();
    }
}
