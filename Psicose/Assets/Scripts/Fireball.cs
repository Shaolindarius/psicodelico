using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class FireballAbility : Ability
{
    public GameObject fireballPrefab; // O prefab da bola de fogo que voc� deve criar.
    public float fireballSpeed; // A velocidade da bola de fogo.
    public Transform firePoint; // O ponto de lan�amento da bola de fogo.

    public FireballAbility()
    {
        abilityType = AbilityType.Fireball; // Define o tipo da habilidade como Fireball.
    }

    public override void Activate()
    {
        base.Activate(); // Chame o m�todo Activate da classe pai.

        // Crie a bola de fogo como um objeto do jogo.
        GameObject fireball = Instantiate(fireballPrefab, firePoint.position, firePoint.rotation);
        Rigidbody2D rb = fireball.GetComponent<Rigidbody2D>();

        // Determine a dire��o para onde a bola de fogo deve se mover (exemplo: dire��o para a direita).
        Vector2 fireballDirection = Vector2.right;

        // Aplique uma for�a � bola de fogo para mov�-la na dire��o desejada.
        rb.velocity = fireballDirection * fireballSpeed;

        // Destrua a bola de fogo ap�s um determinado tempo (opcional).
        Destroy(fireball, 5f);
    }
}
