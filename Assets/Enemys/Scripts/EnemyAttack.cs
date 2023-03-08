using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class EnemyAttack : MonoBehaviour
{
    //variavel booleana do inimigo atacando
    public bool isAttack = false;

    //variavel booleana de ataque
    public bool canAttack = true;

    //variavel de visão do inimigo
    private EnemyVision ev;

    //pega o animator
    public Animator animator;
    
    //variavel que guarda o som da espada
    public AudioSource sword;

    [SerializeField] private float distanceAttack;

    [SerializeField] private LayerMask layerPlayer;

    // Start is called before the first frame update
    void Start()
    {
        //pega o animator e coloca na variavel
        animator = GetComponent<Animator>();

        //coloca a visão do inimigo na variavel
        ev = GetComponent<EnemyVision>();
    }

    // Update is called once per frame
    void Update()
    {
        //condição para inimigo atacar
        if(isAttack == true)
            AttackEnemy();
    }

    //função de ataque
    public void AttackEnemy()
    {
        Collider2D Attack = Physics2D.OverlapCircle(transform.position, distanceAttack, layerPlayer);
        animator.SetTrigger("Attack");
        sword.Play();
        if(Attack)
        {
            if( Attack.GetComponent<Lives>().livesPlayer > 0)
            {
                //se estiver no range de ataque e na visão do inimigo tira 1 de vida do player
                Attack.GetComponent<Lives>().livesPlayer -= 1;
            }

            else
            {
                GetComponent<EnemyAttack>().enabled = false;
            }
        }
        isAttack = false;
        //delay de ataque
        Wait(3000);
    }

    //delay de ataque
    private async void Wait(float duration)
    {
        canAttack = false;
        await Task.Delay((int)(duration));
        canAttack = true;
    }
}
