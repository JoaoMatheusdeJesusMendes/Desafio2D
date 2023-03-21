using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : MonoBehaviour
{
    //pega o animator
    public Animator animator;

    //pega corpo do inimigo
    Rigidbody2D rd;

    //booleana de morte do inimigo
    public bool enemyDeath = false;

    //variavel que guarda o som de morte
    public AudioSource deathSong;

    // Start is called before the first frame update
    void Start()
    {
        rd = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(enemyDeath)
        {
            DeathEnemy();
        }
    }

    //função de morte de inimigo
    public void DeathEnemy()
    {
        //inicia o som de morte do inimigo
        deathSong.Play();
        //animção de morte
        animator.SetTrigger("Death");
        //desativa colisão
        GetComponent<Collider2D>().enabled = false;
        GetComponent<Rigidbody2D>().isKinematic = true;
    }

    //função da queda do inimigo nos espinhos
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "FallDeath")
        {
            //animação de morte
            animator.SetBool("Death", true);
            //desativa funções do inimigo
            GetComponent<Collider2D>().enabled = false;
            GetComponent<Rigidbody2D>().isKinematic = true; 
        }
    }
}
