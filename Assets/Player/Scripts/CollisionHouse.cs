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
    private void OnTriggerEnter2D(Collider2D other) 
    {
        //verifica se é com o chão que o player esta colidindo
        if(other.gameObject.layer == 11)
        {
            events.GetComponent<ActiveMenuGameOver>().MenuEndGameActive();
        }
    }
}
