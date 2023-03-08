using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunting : MonoBehaviour
{
    //variavel da velocidade
    public float speed;

    //pega posição do player
    Transform player;

    //pega corpo do inimigo
    Rigidbody2D rb;

    //booleana para começar a perseguição
    public bool startHunting = false;

    //cria um objeto da classe enemyfollow
    private Enemyfollow enemyfollow;

    void Start()
    {
        //pega posição do player
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        //pega corpo rigido do inimigo
        rb = GetComponent<Rigidbody2D>();

        //pega o enemyfollow
        enemyfollow = GetComponent<Enemyfollow>();

    }
    // Update is called once per frame
    void Update()
    {
        HuntingEnemy();
    }

    //função de perseguisão do inimigo
    private void HuntingEnemy()
    {
        if(!startHunting)
        return;
        

        //determina a translação do inimigo
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //gira o inimigo caso ele não esteja olhando para o player
        if(player.position.x < rb.position.x && enemyfollow.forRight == true)
        {
            enemyfollow.Inverts();
        }
        else if(player.position.x > rb.position.x && enemyfollow.forRight != true)
        {
            enemyfollow.Inverts();
        }
    }
}
