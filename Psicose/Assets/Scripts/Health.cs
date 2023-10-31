using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] private float startingHealth;

    public float currentHealth { get; private set; }
    private bool dead;

    [SerializeField] private float iFramesDuration;
    [SerializeField] private int numberOfFlashes;
    private SpriteRenderer spriterender;

    [SerializeField] private Behaviour[] components;
    private bool invulnerable;

    private void Awake()
    {
        currentHealth = startingHealth;
        spriterender = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int damage)
    {
        if (invulnerable) return;
        currentHealth = Mathf.Clamp(currentHealth - damage, 0, startingHealth);

        if (currentHealth > 0)
        {
            StartCoroutine(Invunerability());
        }
        else
        {
            if (!dead)
            {
                foreach (Behaviour component in components)
                    component.enabled = false;

                dead = true;

            }
        }
    }

    public void AddHealth(float value)
    {
        currentHealth = Mathf.Clamp(currentHealth + value, 0, startingHealth);
    }

    public void Respawn()
    {
        dead = false;
        AddHealth(startingHealth);
        StartCoroutine(Invunerability());

        foreach (Behaviour component in components)
            component.enabled = true;
    }

    private IEnumerator Invunerability()
    {
        invulnerable = true;
        Physics2D.IgnoreLayerCollision(2, 3, true);
        for (int i = 0; i < numberOfFlashes; i++)
        {
            spriterender.color = new Color(1, 0, 1, 0);
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));
            spriterender.color = Color.white;
            yield return new WaitForSeconds(iFramesDuration / (numberOfFlashes * 2));

        }
        Physics2D.IgnoreLayerCollision(2, 3, false);
        invulnerable = false;
    }

    private void Deactivate()
    {
        gameObject.SetActive(false);
    }
}
