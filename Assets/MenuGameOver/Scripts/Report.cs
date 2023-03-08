using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Report : MonoBehaviour
{
    //variavel que recebe a area de texto do relatório
    public TextMeshProUGUI rep;

    public TextMeshProUGUI repEnd;

    [SerializeField] private GameObject player;
    
    //escreve relatório do game
    public void WriteReportDeath()
    {
        rep.text = "Relatório\n" + "Moedas coletadas: " + player.GetComponent<CoinCollector>().finds + "\n";
        rep.text = rep.text + "Inimigos derrotados: " + player.GetComponent<Attack>().defeated + "\n";
        rep.text = rep.text + "Vidas: " + player.GetComponent<Lives>().livesPlayer;
    }
    public void WriteReportEndLevel()
    {
        repEnd.text = "Relatório\n" + "Moedas coletadas: " + player.GetComponent<CoinCollector>().finds + "\n";
        repEnd.text = repEnd.text + "Inimigos derrotados: " + player.GetComponent<Attack>().defeated + "\n";
        repEnd.text = repEnd.text + "Vidas: " + player.GetComponent<Lives>().livesPlayer;
    }
}
