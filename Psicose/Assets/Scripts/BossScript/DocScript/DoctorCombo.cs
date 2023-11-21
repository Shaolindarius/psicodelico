using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoctorCombo : MonoBehaviour
{

public enum BossState
{
    Stage1,
    Stage2,
    Stage3
}

public class BossController : MonoBehaviour
{
    public BossState currentState = BossState.Stage1;
    public GameObject projectilePrefab;
    public GameObject enemyPrefab;

    public Transform[] spawnPoints;

    public float attackCooldownStage1 = 2f;
    public float attackCooldownStage2 = 1.5f;
    public float spawnCooldownStage3 = 3f;

    private float attackTimer;
    private float spawnTimer;

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
                SpawnEnemies();
                break;
            default:
                break;
        }
    }

    private void AttackStage1()
    {
        attackTimer += Time.deltaTime;

        // Ataque normal no est�gio 1
        if (attackTimer >= attackCooldownStage1)
        {
            

            attackTimer = 0f;
        }
        //if(BossHealth <= 75)
        {
          
        }
        // Mudar para o pr�ximo est�gio quando necess�rio
        // Exemplo: if (condi��o para mudar para o pr�ximo est�gio)
        //     ChangeState(BossState.Stage2);
    }

    private void AttackStage2()
    {
        attackTimer += Time.deltaTime;

        // Ataque com raios e ataques normais no est�gio 2
        if (attackTimer >= attackCooldownStage2)
        {
            // L�gica do ataque com raios aqui
            // Instantiate(projectilePrefab, transform.position, Quaternion.identity);

            // L�gica do ataque normal aqui

            attackTimer = 0f;
        }

        // Mudar para o pr�ximo est�gio quando necess�rio
        // Exemplo: if (condi��o para mudar para o pr�ximo est�gio)
        //     ChangeState(BossState.Stage3);
    }

    private void SpawnEnemies()
    {
        spawnTimer += Time.deltaTime;

        // Spawn de inimigos no est�gio 3
        if (spawnTimer >= spawnCooldownStage3)
        {
            // L�gica de spawn de inimigos aqui
            // Exemplo: SpawnEnemy();

            spawnTimer = 0f;
        }

        // Voltar para um est�gio anterior ou reiniciar quando necess�rio
        // Exemplo: if (condi��o para voltar ao est�gio anterior)
        //     ChangeState(BossState.Stage2);
    }

    private void ChangeState(BossState newState)
    {
        currentState = newState;
        // L�gica de transi��o entre estados, se necess�rio
    }

    private void SpawnEnemy()
    {
        if (spawnPoints.Length > 0 && enemyPrefab != null)
        {
            Transform spawnPoint = spawnPoints[Random.Range(0, spawnPoints.Length)];
            Instantiate(enemyPrefab, spawnPoint.position, Quaternion.identity);
        }
    }
}

}
