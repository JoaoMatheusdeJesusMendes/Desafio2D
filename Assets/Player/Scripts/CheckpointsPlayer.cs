using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckpointsPlayer : MonoBehaviour
{
    //pega posição do checkpoint
    Vector2 checkpointPos;
    //pega rigidbody do player
    Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        //checkpoint é sempre igual a posição do player atual, mas só atualiza o falor colidindo com a casa
        checkpointPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("Checkpoint"))
        {
            //atualiza o valor do chackpoint
            //gameControl.UpdateCheckpoint(transform.position);
        }
    }
}
