using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Threading.Tasks;

public class MainMenu : MonoBehaviour
{
    //variavel que guarda o nome do jogo
    [SerializeField] private string nameGame;
    
    //variavel que recebe menu principal
    [SerializeField] private GameObject mainMenu;
    
    //variavel que recebe menu de opções
    [SerializeField] private GameObject optionsMenu;

    //variavel que recebe menu do tutorial
    [SerializeField] private GameObject tutorialMenu;

    //pega o animator
    public Animator animator;
    
    //inicia o game
    public void ButtonStart()
    {
        //inicia a animação de transição
        animator.SetTrigger("isLoading");
        //tempo para iniciar o game
        Wait(1f, 2);
    }
    
    //função que ativa as opções
    public void OptActive()
    {
        //inicia a animação de transição
        animator.SetTrigger("isLoading");
        //tempo para iniciar o game
        Wait(1f, 0);
    }
    
    //função que ativa o tutorial
    public void TutorialActive()
    {
        //inicia a animação de transição
        animator.SetTrigger("isLoading");
        Wait(1f, 1);
    }

    //fecha app
    public void Close()
    {
        Application.Quit();    
    }

    //delay de 30 segundos para o temporizador
    private async void Wait(float duration, int i)
    {
        
        await Task.Delay((int)(duration*1000));
        if(i == 0)
        {
            //Desativa menu principal
            mainMenu.SetActive(false);
            //ativa as opções
            optionsMenu.SetActive(true); 
        }
        if(i == 1)
        {
            //Desativa menu principal
            mainMenu.SetActive(false);
            //Ativa o menu secundario
            tutorialMenu.SetActive(true);
        }
        if(i == 2)
        {
            //inicia o game
            SceneManager.LoadScene(nameGame);
        }
    }
}
