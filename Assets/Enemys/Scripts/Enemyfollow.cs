using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class Enemyfollow : MonoBehaviour
{
    //variavel de controle de virada do inimigo
    private bool canTurn = true;

    //variavel que guarda a velocidade do inimigo
    public float speed;

    //variavel que guarda o alvo do inimigo
    private Transform Target;

    //variavel de controle se o inimigo está no chão
    private bool ground = true;

    //variavel para ver condição de andar
    public bool canWalk = true;

    //variavel de checagem do chão
    public Transform groundCheck;
    
    //variavel guarda com o que o inimigo tem que colidir (chão)
    public LayerMask groundLayer;

    //variavel que verifica se o inimigo esta virado para a direita
    public bool forRight = true;

    // Start is called before the first frame update
    void Start()
    {
        Target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    // Update is called once per frame
    void Update()
    {
        WalkEnemy();
    }
    
    //movimentação do inimigo
    private void WalkEnemy()
    {
        if(!canWalk)
        return;
        //faz o inimigo andar pela plataforma
        transform.Translate(Vector2.right * speed * Time.deltaTime);
        //Cria uma linha imaginaria entre 2 pontos
        ground = Physics2D.Linecast(groundCheck.position, transform.position, groundLayer);
        //se estiver saindo do chão, inverte sentido de movimento
        if(ground == false)
        {
            if(canTurn)
            {
            Inverts();
            Wait(1);
            }
        }
    }
    //inverte rosto do inimigo
    public void Inverts()
    {
        //inverte de true para false e vice versa
        forRight = !forRight;
        //rotaciona o inimigo para direuta
        if(forRight)
        {
            transform.rotation = Quaternion.Euler(0, 0, 0); 
        }
        //rotação do inimigo para esquerda
        else
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
    }

    //delay de 1 segundo para o inimigo poder virar
    private async void Wait(float duration)
    {
        canTurn = false;
        await Task.Delay((int)(duration*1000));
        canTurn = true;
    }
}
