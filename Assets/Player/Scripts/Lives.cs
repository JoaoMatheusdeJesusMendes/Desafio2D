using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    //variavel do rigidybody
    private Rigidbody2D rd;

    //vidas do player
    public int livesPlayer = 3;

    //variavel que recebe o animator
    public Animator animator;

    //variavel que guarda o som de morte
    public AudioSource deathSong;

    // Start is called before the first frame update
    void Start()
    {
        //pega rigidybody
        rd = GetComponent<Rigidbody2D>();

        //recebe o animator
        animator = GetComponent<Animator>();
    }

    public void TakeDamage(int amount)
    {
        livesPlayer -= amount;
        Debug.Log(livesPlayer);
        if(livesPlayer == 0)
        {
            PlayerDeath();
        }
    }
    // função de morte do player
    private void PlayerDeath()
    {
        //ativa o som de morte
        deathSong.Play();

        //animação de morte
        animator.SetBool("isDeath", true);

        //Desabilita scripts
        GetComponent<Movement>().enabled = false;
        GetComponent<Attack>().enabled = false;
    }

    //função de morte por queda
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "FallDeath")
        {
            this.livesPlayer = 0;
        }
    }

    
}
