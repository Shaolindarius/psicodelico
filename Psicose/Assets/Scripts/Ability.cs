using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{
    public enum AbilityType
    {
        None,
        Fireball,
        Jump, // Adicione outros tipos de habilidade, se necessário.
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
                case AbilityType.Jump:
                    JumpLogic();
                    break;
                    // Adicione outros casos para tipos de habilidade adicionais.
            }
        }
    }

    private void ResetCooldown()
    {
        isReady = true;
    }

    // Lógica da habilidade de bola de fogo.
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
