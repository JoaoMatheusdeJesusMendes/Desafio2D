using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHunting : MonoBehaviour
{
    //variavel da velocidade
    public float speed;

    //pega posição do player
    [SerializeField] private  GameObject player;

    //pega corpo do inimigo
    Rigidbody2D rb;

    //booleana para começar a perseguição
    public bool startHunting = false;

    //cria um objeto da classe enemyfollow
    private Enemyfollow enemyfollow;

    void Start()
    {
        //pega corpo rigido do inimigo
        rb = GetComponent<Rigidbody2D>();

        //pega o enemyfollow
        enemyfollow = GetComponent<Enemyfollow>();

    }
    // Update is called once per frame
    void Update()
    {
        //chama a função de persegução do inimigo
        HuntingEnemy();
    }

    //função de perseguisão do inimigo
    private void HuntingEnemy()
    {
        if(!startHunting)
        return;
        /*
        //gira o inimigo caso ele não esteja olhando para o player
        if(player.transform.localPosition.x < rb.transform.localPosition.x && enemyfollow.forRight)
        {
            enemyfollow.Inverts();
        }
        else if(player.transform.localPosition.x > rb.transform.localPosition.x && !enemyfollow.forRight)
        {
            enemyfollow.Inverts();
        }*/
        //função que gira o player
        Flip(GetAxis());
        //determina a velocidade do inimigo
        rb.velocity = new Vector2(GetAxis() * speed, rb.velocity.y);
        //transform.Translate(transform.right * speed * Time.deltaTime);
    }

    //função para ver se o player está a direita ou a esquerda do player
    private int GetAxis()
    {
        if(player.transform.position.x < transform.localPosition.x)
            return -1;
            

        if(player.transform.position.x > transform.localPosition.x)
            return 1;
        
        return 0;
    }
    
    //função que rotaciona o player
    private void Flip(float horizontal)
    {
        if(horizontal > 0 && !enemyfollow.forRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);
            enemyfollow.forRight = !enemyfollow.forRight;
        }
        if(horizontal < 0 && enemyfollow.forRight)
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
            enemyfollow.forRight = !enemyfollow.forRight;
        }
    }
}
