using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public enum AbilityType
    {
        None,
        Fireball,
        Dash,
    }

    public AbilityType abilityType;
    public string abilityName;
    public Sprite icon;
    public float cooldown;
    public bool isReady = true;

    public virtual void Activate()
    {
        if (isReady)
        {
            isReady = false;
            Invoke("ResetCooldown", cooldown);

            switch (abilityType)
            {
                case AbilityType.Fireball:
                    FireballLogic();
                    break;
                case AbilityType.Dash:
                    //DashLogic();
                    break;
                   
            }
        }
    }

    private void ResetCooldown()
    {
        isReady = true;
    }

    
    protected virtual void FireballLogic()
    {
        // Implemente a lógica para a habilidade da bola de fogo aqui.
    }

    // Lógica da habilidade de pulo.
    protected virtual void JumpLogic()
    {
        // Implemente a lógica para a habilidade de pulo aqui.
    }
}
