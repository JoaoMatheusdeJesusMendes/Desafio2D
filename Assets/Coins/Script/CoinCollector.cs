using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    //pega corpo d player
    private Rigidbody2D player;
    
    //pega o objeto moeda
    public GameObject coin;

    //variavel de controle de moedas achadas
    public int finds = 0;

    // Start is called before the first frame update
    void Start()
    {
        player = GetComponent<Rigidbody2D>();   
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //ao colidir com a moeda
    private void OnTriggerEnter2D(Collider2D other)
    {
        //se colidir com a moeda
        if(other.gameObject.layer == 9)
        {
            //destroi moeda
            Destroy(other.gameObject);
            finds+=1;
        }
    }
}
