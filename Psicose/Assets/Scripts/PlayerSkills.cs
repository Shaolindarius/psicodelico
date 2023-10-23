using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSkills : MonoBehaviour
{
    
    
    public Ability[] abilities;

    void Update()
    {
        for (int i = 0; i < abilities.Length; i++)
        {
            if (Input.GetKeyDown((i + 1).ToString())) // Habilidade 1 é acionada pressionando "1", habilidade 2 com "2", etc.
            {
                abilities[i].Activate();
            }
        }
    }
}