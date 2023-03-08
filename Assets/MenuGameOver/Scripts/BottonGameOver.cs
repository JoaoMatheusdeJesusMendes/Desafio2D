using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonGameOver : MonoBehaviour
{
    [SerializeField] private string nameGame;
    [SerializeField] private string nameMenu;
    
    //função de restart
    public void Restart()
    {
        SceneManager.LoadScene(nameGame);
    }

    //função que vai para o menu principal
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(nameMenu);
    }
}
