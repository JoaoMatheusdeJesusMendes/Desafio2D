using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BottonGameOver : MonoBehaviour
{
    [SerializeField] private string nameGame;
    [SerializeField] private string nameMenu;

    //pega o som de fundo do jogo
    public GameObject soundTrack;

    private void Awake() {
        GameObject[] objs = GameObject.FindGameObjectsWithTag("Sound");
        
        if(objs.Length > 1)
        {
            Destroy(soundTrack);
        }
        DontDestroyOnLoad(soundTrack);
        //chama a função de quando uma cena é carregada
        SceneManager.sceneLoaded += OnSceneLoaded;
    }

    //destroi a trilha sonora ao entrar novamente no menu
    void OnSceneLoaded(UnityEngine.SceneManagement.Scene scene, UnityEngine.SceneManagement.LoadSceneMode mode)
    {
        //se carregar o menu
        if(scene.name == "Menus")
        {
            Destroy(soundTrack);
        }
    }

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
