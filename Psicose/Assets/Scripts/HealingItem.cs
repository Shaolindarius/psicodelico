using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealingItem : MonoBehaviour
{
    public int healAmount = 20;
    public int MaxInteractions = 3;

    private int interactionsCount = 0;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.H))
        {
            HealingItem playerHealth = FindObjectOfType<HealingItem>(); // Cura o Player ao Interagir
            if (playerHealth != null)
            {
                playerHealth.Heal(healAmount);
                interactionsCount++;
            }
            if (interactionsCount > MaxInteractions)
            {
                Destroy(gameObject);
            }
        }
    }

    private void Heal(int healAmount)
    {
        throw new NotImplementedException();
    }
}
