using System.Collections;
using System.Collections.Generic;
using UnityEditor.Tilemaps;
using UnityEngine;

public class SpawnEnemy : MonoBehaviour
{
    [SerializeField]
    private bool canSpawn;

    [SerializeField]
    private GameObject[] enemyPref;

    [SerializeField]
    private float spawnRate;

    [SerializeField]
    private int numberSpawn;
    void Start()
    {
        StartCoroutine(spawnEnemy());

    }

    private IEnumerator spawnEnemy()
    {
        WaitForSeconds wait = new WaitForSeconds(spawnRate);

        while(true)// verifica se é possivel continuar chamando o persoangem
        {
            yield return wait;// verifica retorna o tempo de wpawn para maquina

            int rand = Random.Range(0,enemyPref.Length);// gera um valor aleatorio entre o número de itens dentro a array;

            GameObject enemyToSpawn = enemyPref[rand];//marca o obejto sorteado

            Instantiate(enemyToSpawn, transform.position, Quaternion.identity); // chama o objeto 
            /* usando esse codigo é possivel cria a opção de controle de números de ordas se vai sair 2 ou mais inimigos simutaneos e a quantidade de inimigos na tela.*/
        }

     
    }

}
