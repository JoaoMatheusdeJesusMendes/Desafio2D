using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsPlayer : MonoBehaviour
{
    //pega posição do checkpoint
    private Vector2 checkpointPos;

    //pega rigidbody do player
    private Rigidbody2D rb;

    //booleana que verifica se o player pegou checkpoint
    public bool haveCheckpoint = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //checkpoint é sempre igual a posição do player atual, mas só atualiza o falor colidindo com a casa
        checkpointPos = transform.position;
    }
    //função que marca checkpoint
    private void OnTriggerEnter2D(Collider2D other) {
        //se player colidir com um objeto com tag checkpoint ele pega a posição dele
        if(other.gameObject.tag == "Checkpoint")
        {
            checkpointPos = other.gameObject.transform.position;
            haveCheckpoint = true;
            Debug.Log("ae");
        }
    }

    //função que inicia player no checkpoint
    public void initCheckpoint(){
        rb.gameObject.transform.position = checkpointPos;
    }
}
