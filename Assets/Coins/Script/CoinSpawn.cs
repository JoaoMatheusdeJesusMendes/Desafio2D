using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinSpawn : MonoBehaviour
{
    //variavel para moeda
    public GameObject coin;

    //variavel do inimigo
    private Rigidbody2D enemy;

    //variavel para o enemyhit
    private EnemyHit enemyHit;

    //variavel de controle de spawnados
    private int spawnados = 0;

    // Start is called before the first frame update
    void Start()
    {
        //coloca o enemyHit na variavel
        enemyHit = GetComponent<EnemyHit>();

        //pega rigidbody do inimigo
        enemy = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        //aciona a função de spawnar um ouro caso o inimigo morra e já nã tenha spawnado moedas
        if(spawnados == 0 && enemyHit.enemyDeath)
        {
            SpawnCoin();
            spawnados++;
        }
    }

    //função de surgimento de moeda
    void SpawnCoin()
    {
        //pega posição final do inimigo
        Vector2 spawnPosition = new Vector2 (enemy.transform.position.x, enemy.transform.position.y + (float)0.75);
        //instancia o objeto
        Instantiate(coin, spawnPosition, Quaternion.identity);
    }
}
