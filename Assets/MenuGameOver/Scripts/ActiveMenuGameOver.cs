using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class ActiveMenuGameOver : MonoBehaviour
{
    [SerializeField] private GameObject player;

    [SerializeField] private GameObject menuGameOverMorte;

    [SerializeField] private GameObject interfacePainel;

    [SerializeField] private GameObject menuGameOverEndLevel;

    private Report rpt;

    private void Start() 
    {
        rpt = GetComponent<Report>();
    }

    // Update is called once per frame
    void Update()
    {
        if(player.GetComponent<Lives>().livesPlayer == 0)
        {
            Wait(2000);
        }
    }

    //ativa o menu de restart
    private void MenuRestartActive()
    {
        menuGameOverMorte.SetActive(true);
        interfacePainel.SetActive(false);
        rpt.WriteReportDeath();
    }

    public void MenuEndGameActive()
    {
        menuGameOverEndLevel.SetActive(true);
        interfacePainel.SetActive(false);
        rpt.WriteReportEndLevel(); 
    }

    //delay de ataque
    private async void Wait(float duration)
    {
        await Task.Delay((int)(duration));
        MenuRestartActive();
    }
}
