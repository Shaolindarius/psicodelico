using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Ability[] abilities; // Array de habilidades atribu�das ao jogador.

    void Start()
    {
        // Configure as habilidades no in�cio do jogo.
        abilities = new Ability[2]; // Suponha que o jogador pode ter at� duas habilidades.

        // Habilidade 1 (�ndice 0) � a habilidade da bola de fogo.
        abilities[0] = GetComponent<FireballAbility>();

    }

    void Update()
    {
        // L�gica para ativar habilidades com base na entrada do jogador.
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Ativar a primeira habilidade (tecla "1").
        {
            abilities[0].Activate();
        }
    }
}