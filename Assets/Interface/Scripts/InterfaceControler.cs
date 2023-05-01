using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class InterfaceControler : MonoBehaviour
{
    //variaveis que recebe os corações
    [SerializeField] private GameObject heart1;
    [SerializeField] private GameObject heart2;
    [SerializeField] private GameObject heart3;

    //vetor de corações
    private GameObject[] hearts = new GameObject[3];

    //variavel que recebe o player
    [SerializeField] private GameObject player;

    //variavel que recebe as vidas do player
    private Lives live;

    //variavel que recebe o script de coleta de moedas
    private CoinCollector coin;

    //Recebe o local de escrita do numero de moedas
    public TextMeshProUGUI pont;

    //variavel auxiliar
    private int aux = 2;

    //contadora de moedas
    private int countCoins = 0;

    // Start is called before the first frame update
    void Start()
    {
        hearts[0] = heart1;
        hearts[1] = heart2;
        hearts[2] = heart3;
        live = player.GetComponent<Lives>();
        coin = player.GetComponent<CoinCollector>();
    }

    // Update is called once per frame
    void Update()
    {
        //verificação se o player perdeu vida
        if((aux+1) > live.livesPlayer)
        {
            LosesLive(aux);
            aux = live.livesPlayer - 1;
        }
        //verificação se o player recuperou vida
        if((aux+1) < live.livesPlayer)
        {
            aux += 1;
            winLive(aux);   
        }

        //verificação se o player pegou uma moeda
        if(countCoins < coin.finds)
        {
            ScoreUI();
            countCoins = coin.finds;
        }
    }

    //Função de perder vida
    public void LosesLive(int i)
    {
        hearts[i].SetActive(false);
    }

    //função de recuperar vida
    public void winLive(int i)
    {
        hearts[i].SetActive(true);
    }

    //função que escreve as moedas coletadas na interface
    void ScoreUI()
    {
        pont.text = coin.finds.ToString();
    }
}
