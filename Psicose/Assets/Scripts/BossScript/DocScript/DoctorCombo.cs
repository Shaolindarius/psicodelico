using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorCombo : MonoBehaviour
{
    private BossHealth bossHealth;

    public enum BossState
    {
        Stage1,
        Stage2,
        Stage3
    }

    public bool isInvencible = false;
    private float invencibleTimer = 0f;
    private float invencibleCooldown = 10f;

    public BossState currentState = BossState.Stage1;
    public GameObject projectilePrefab;
    public GameObject playerPrefab;

    public float attackCooldownStage1 = 2f;
    public float attackCooldownStage2 = 1.5f;
    public float superCooldownStage3 = 3f;

    private float attackTimer;

    private void Start()
    {
       bossHealth = GetComponent<BossHealth>();
    }

    private void Update()
    {
        switch (currentState)
        {
            case BossState.Stage1:
                AttackStage1();
                break;
            case BossState.Stage2:
                AttackStage2();
                break;
            case BossState.Stage3:
                SuperDamage();
                break;
            default:
                break;
        }
    }

    private void AttackStage1()
    {
        attackTimer += Time.deltaTime;

        // Ataque normal no estágio 1
        if (attackTimer >= attackCooldownStage1)
        {
            //AttackCombo1();

            attackTimer = 0f;
        }
        if (bossHealth.currentBossHealth <= 100)
        {
            ChangeState(BossState.Stage2);
        }
    }

    private void AttackStage2()
    {
        attackTimer += Time.deltaTime;

        // Ataque com raios e ataques normais no estágio 2
        if (attackTimer >= attackCooldownStage2)
        {
            // Lógica do ataque com raios aqui
            Instantiate(this.projectilePrefab, this.transform.position, Quaternion.identity);
            // Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // Lógica do ataque normal aqui

            attackTimer = 0f;
        }
        if (bossHealth.currentBossHealth <= 50)
        {
            ChangeState(BossState.Stage3);
        }
    }

    private void SuperDamage()
    {
        attackTimer += Time.deltaTime;
        if (attackTimer >= superCooldownStage3)
        {
            if (!isInvencible)
            {
                invencibleTimer += Time.deltaTime;
                if (invencibleTimer >= invencibleCooldown)
                {
                    isInvencible = true;
                    invencibleTimer = 0f;
                }
            }
            if (isInvencible)
            {
                invencibleTimer += Time.deltaTime;
                if (invencibleCooldown >= invencibleTimer)
                {
                    isInvencible = false;
                    invencibleTimer = 0f;
                }
            }

        }
    }

     private void ChangeState(BossState newState)
     {
        currentState = newState;
        // Lógica de transição entre estados somente se necessario
     }
}

