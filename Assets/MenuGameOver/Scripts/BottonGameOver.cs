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

    //pega o game object do player
    public GameObject player;

    //pega o próprio menu de game over
    [SerializeField] private GameObject menuGameOverMorte;

    //pega o menu da interface
    [SerializeField] private GameObject interfacePainel;

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
        if(player.GetComponent<CheckpointsPlayer>().haveCheckpoint == false)
        {
            SceneManager.LoadScene(nameGame);
        }
        else
        {
            //recupera todas as vidas do player
            player.GetComponent<Lives>().livesPlayer = 3;
            
            //desativa menu de game over
            menuGameOverMorte.SetActive(false);

            //ativa interface
            interfacePainel.SetActive(true);

            
            
            //inicia a função de spawnar no checkpoint
            player.GetComponent<CheckpointsPlayer>().initCheckpoint();

            //para animação de morte
            player.GetComponent<Lives>().animator.SetBool("isDeath", false);

            //habilita scripts scripts
            GetComponent<Movement>().enabled = true;
            GetComponent<Attack>().enabled = true;
        }
    }

    //função que vai para o menu principal
    public void ReturnMainMenu()
    {
        SceneManager.LoadScene(nameMenu);
    }
}
