using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    //auxiliar de que lado está indo
    public bool right;

    //pega o animator
    public Animator animator;

    //variavel para força de pulo
    public float jumpForce = 40.0f;

    //variavel para pegar a massa
    public float mass = 3.0f;

    //variavel para pegar o rigidybody do player
    private Rigidbody2D rigidbody;

    //pega a camera do player
    public GameObject camera;

    //variavel da velocidade do player
    public float speed = 0.1f;

    //variavel que guarda o som dos passos
    public AudioSource steps;

    [SerializeField] private Transform feetPosition;

    [SerializeField] private LayerMask groundLayer;

    //variavel para controle se ele está no chão
    public bool isGround;

    // Start is called before the first frame update
    void Start()
    {
        //pega o rigidybody do player
        rigidbody = GetComponent<Rigidbody2D>();

        //coloca a massa do codigo no rigidybody do player
        rigidbody.mass = mass;    

        //pega o animator e coloca na variavel
        animator = GetComponent<Animator>();

        //coloca direita como verdadeiro
        right = true;
    }

    // Update is called once per frame
    void Update()
    {
        isGround = Physics2D.OverlapCircle(feetPosition.position, 0.1f, groundLayer);
        Move();
        if(Input.GetKeyDown(KeyCode.W))
        {
            //se está no chão
            if(isGround)
            {
                animator.SetBool("isJumping", true);
                Jump();
            }
        }
        else
        {
            //se está no chão
            if(isGround)
            {
                animator.SetBool("isJumping", false);
            }
        }
    }
    //função da movimentação do player
    private void Move()
    {
        //ativa o som dos passos
        steps.UnPause();

        //muda a booleana de corrida para true
        animator.SetBool("isRunning", true);

        //determina a translação do player
        float translate = (Input.GetAxis("Horizontal") * speed) * Time.deltaTime;

        //para o personagem só ir para frente
        if(translate<0)
        {
            translate = translate * (-1);
        } 

        //efetua a translação a depender de que lado o personagem está indo
        transform.Translate(translate, 0, 0);
        if(Input.GetKeyDown(KeyCode.A) && right == true)
        {
            transform.Rotate(0, -180, 0);
            //vira a camera para o lado correto
            camera.transform.Rotate(0, 180, 0);
            camera.transform.Translate(0, 0, -80);            
            right = false;
        }
        else if(Input.GetKeyDown(KeyCode.D) && right == false)
        {
            transform.Rotate(0, 180, 0);
            //vira a camera para o lado correto
            camera.transform.Rotate(0, -180, 0);
            camera.transform.Translate(0, 0, -80); 
            right = true;
        }
        else if(!Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A))
        {
            //muda a booleana de corrida para false
            animator.SetBool("isRunning", false);

            //pausa o som dos passos
            steps.Pause();
        }  
    }

    //função de pulo
    private void Jump()
    {
        //logica de pulo
        rigidbody.AddForce(Vector3.up * jumpForce, ForceMode2D.Impulse);
    }

    //função que verifica se o personagem está no chão
   /* private void OnCollisionEnter2D(Collision2D collision) 
    {
        //verifica se é com o chão que o player esta colidindo
        if(collision.gameObject.tag.Equals("Floor"))
        {
            isGround = true;
            //deixa a animação de pular como verdadeira
            animator.SetBool("isJumping", false);
        }
    }

    //função que verifica se o objeto saiu da colisão
    private void OnCollisionExit2D(Collision2D collision)
    {
        isGround = false;
        //deixa a animação de pular como falsa
        animator.SetBool("isJumping", true);
    }*/
}  

