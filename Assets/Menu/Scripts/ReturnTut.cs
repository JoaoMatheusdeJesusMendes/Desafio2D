using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ReturnTut : MonoBehaviour
{
    //variavel que guarda o game object dos componentes de UI
    [SerializeField] private GameObject mainMenu;
    [SerializeField] private GameObject tutorialMenu;

    //pega o animator
    public Animator animator;

    public void TutorialBack()
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
        //desativa o menu secundario
        tutorialMenu.SetActive(false);
        //ativa o menu principal
        mainMenu.SetActive(true);
    }
}
