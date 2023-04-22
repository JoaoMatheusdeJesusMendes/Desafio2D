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
    //ativa o menu de restart
    public void MenuRestartActive()
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
}
