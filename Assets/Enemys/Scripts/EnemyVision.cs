using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyVision : MonoBehaviour
{
    [SerializeField] private float distance;

    [SerializeField] private float distanceAttack;

    [SerializeField] private LayerMask layerPlayer;

    private Enemyfollow enemyfollow;

    private EnemyHunting enemyhunting;

    private EnemyHit enemyhit;

    private EnemyAttack enemyattack;

    //pega o animator
    public Animator animator;
    
    //faz mesmo que o start só que antes
    private void Awake() 
    {
        //importa classes 
        enemyfollow = GetComponent<Enemyfollow>();
        enemyhunting = GetComponent<EnemyHunting>();
        enemyhit = GetComponent<EnemyHit>();
        enemyattack = GetComponent<EnemyAttack>();
    }
    // Start is called before the first frame update
    void Start()
    {
        //pega o animator e coloca na variavel
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        VisionEnemy();
    }

    //visão do inimigo
    private void VisionEnemy()
    {
        if(enemyhit.enemyDeath)
            return;

        //cria o circulo de visão de perseguição
        bool vision = Physics2D.OverlapCircle(transform.position, distance, layerPlayer);

        //cria visão de ataque
        bool vsAttack = Physics2D.OverlapCircle(transform.position, distanceAttack, layerPlayer);

        //condicionais
        //em perseguição
        if(vision && !vsAttack)
        {
            //animação de andando
            animator.SetBool("Run", true);
            enemyfollow.canWalk = false; // TODO ATTACK
            enemyhunting.startHunting = true;
            return;
        }
        //fora de perseguição
        if(!vision && !vsAttack)
        {
            if(enemyfollow.speed != 0)
            {
                //animação de andando
                animator.SetBool("Run", true);
                enemyfollow.canWalk = true;
                enemyhunting.startHunting = false;
                return;
            }
            else
            {
                //animação de andando
                animator.SetBool("Run", false);
                enemyfollow.canWalk = true;
                enemyhunting.startHunting = false;
                return;
            }
            
        }
        //posição de ataque
        if(vsAttack)
        {
            //animação de andando
            animator.SetBool("Run", false);
            enemyfollow.canWalk = false;
            enemyhunting.startHunting = false;
            if(enemyattack.canAttack == true)
            {
                enemyattack.isAttack = true;
            }
            return;
        }
    }

    //Serve para desenhar ...
    private void OnDrawGizmosSelected()
    {
        //circulo de perceguição
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, distance);
        
        //circulo de ataque
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, distanceAttack);
    }

}
