using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Attack : MonoBehaviour
{
    //pega o animator
    public Animator animator;

    //variavel do range de ataque
    public float attackRange;

    //variavel do layer do inimigo
    [SerializeField] private LayerMask enemyLayer;

    //variavel que pega o centro do range de ataque
    [SerializeField] private Transform centerAttack;

    //inimigos derrotados
    public int defeated = 0;

    //variavel que guarda o som da espada
    public AudioSource sword;

    // Start is called before the first frame update
    void Start()
    {
       //pega o animator e coloca na variavel
        animator = GetComponent<Animator>(); 
    }

    // Update is called once per frame
    void Update()
    {
        if(Lives.isDeath)
            return;
        //se precionar espaço o player ataca
        if(Input.GetKeyDown(KeyCode.Space))
        {
            AnimationAttack(Random.Range(1,4));
        }
    }
    //função de ataque
    private void AnimationAttack(int rand)
    {
        //despausa o som da espada
        sword.Play();

        //ativa animação a partir do numero randomizado
        switch(rand)
        {
            case 1: animator.SetTrigger("isAttack1");
                    break;
            case 2: animator.SetTrigger("isAttack2");
                    break;
            case 3: animator.SetTrigger("isAttack3");
                    break;
        }
    }

    //Ataque player
    private void AttackRange()
    {
        Collider2D[] hitEnemies = Physics2D.OverlapCircleAll(centerAttack.position, attackRange, enemyLayer);
            //caso inimigo tome dano vai para a tela função de morte
        for(int i=0; i<hitEnemies.Length; i++)
        {
            if(hitEnemies[i])
            {
                hitEnemies[i].GetComponent<EnemyHit>().enemyDeath = true;
                defeated++;
            }
        }
    }

    //range de attack visualmente
    private void OnDrawGizmosSelected()
    {
        //circulo de perceguição
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(centerAttack.position, attackRange);
    }

    
}
