using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    //variavel do rigidybody
    private Rigidbody2D rd;

    public static bool isDeath = false;

    //vidas do player
    public int livesPlayer = 3;

    //variavel que recebe o animator
    public Animator animator;

    //variavel que guarda o som de morte
    public AudioSource deathSong;

    [SerializeField] private ActiveMenuGameOver gameOverScreen;

    [SerializeField] private GameObject inter;

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

        gameOverScreen.MenuRestartActive();

        isDeath = true;
    }

    //função de morte por queda
    public void DeathFall() {
        int i;
        //tira os corações do player
        for(i = livesPlayer - 1; i >= 0; i--)
        {
            inter.GetComponent<InterfaceControler>().LosesLive(i);
        }
        this.TakeDamage(livesPlayer);
        //animação de morte
        animator.SetBool("isDeath", true);
    }

    
}
