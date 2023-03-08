using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ReturnOption : MonoBehaviour
{
    //variaveis que recebem o menu e o menu de opções
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject optionsMenu;

    //pega o animator
    public Animator animator;

    //função que ativa as opções
    public void OptReturn()
    {
        //inicia a animação de transição
        animator.SetTrigger("isLoading");
        //função que ativa a animação de mudança de tela
        Wait(1f); 
    }

    //função de delay
    private async void Wait(float duration)
    {
        
        await Task.Delay((int)(duration*1000));
        //Ativa menu principal
        mainMenu.SetActive(true);
        //Desativa o menu de opções
        optionsMenu.SetActive(false);
    }
}
