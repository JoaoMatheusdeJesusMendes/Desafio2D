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
    void Awake()
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
        if(isAttack)
            AttackEnemy();
    }

    //função de ataque
    private void AttackEnemy()
    {
        animator.SetTrigger("Attack");
        sword.Play();
        //delay de ataque
        StartCoroutine(Wait(3));
    }

    public void CheckAttack()
    {
        Collider2D Attack = Physics2D.OverlapCircle(transform.position, distanceAttack, layerPlayer);
        if(Attack.TryGetComponent(out Lives liv))
        {
            Debug.Log("OI");
            liv.TakeDamage(1);
        }
    }

    //delay de ataque
    private IEnumerator Wait(float duration)
    {
        WaitForSeconds sec = new WaitForSeconds(duration);
        canAttack = false;
        yield return sec;
        canAttack = true;
    }
}
