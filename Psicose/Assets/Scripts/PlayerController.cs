using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Ability[] abilities; // Array de habilidades atribuídas ao jogador.

    void Start()
    {
        // Configure as habilidades no início do jogo.
        abilities = new Ability[2]; // Suponha que o jogador pode ter até duas habilidades.

        // Habilidade 1 (índice 0) é a habilidade da bola de fogo.
        abilities[0] = GetComponent<FireballAbility>();

    }

    void Update()
    {
        // Lógica para ativar habilidades com base na entrada do jogador.
        if (Input.GetKeyDown(KeyCode.Alpha1)) // Ativar a primeira habilidade (tecla "1").
        {
            abilities[0].Activate();
        }
    }
}