using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionHouse : MonoBehaviour
{
    //rigidbody do player
    private Rigidbody2D rigidbody;

    //variavel que guarda o game object de eventos
    [SerializeField] private GameObject events;

    // Start is called before the first frame update
    void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
    }
    
    //função se o player colidir com a casa
    public void ActiveMenuEndGame() 
    {
        events.GetComponent<ActiveMenuGameOver>().MenuEndGameActive();
    }
}
