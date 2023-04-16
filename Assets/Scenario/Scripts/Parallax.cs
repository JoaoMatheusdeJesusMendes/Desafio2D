using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Parallax : MonoBehaviour
{
    //pega a camera do player
    public GameObject cameraPlayer;

    //posição da camera
    private float length, startPos;

    //velocidade do parallax
    public float speedParallax;

    // Start is called before the first frame update
    void Start()
    {
        //posição inicial
        startPos = transform .position.x;
        
        //comprimento da imagem
        length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    // Update is called once per frame
    void Update()
    {
        float temp = (cameraPlayer.transform.position.x * (1-speedParallax));
        float dist = (cameraPlayer.transform.position.x * speedParallax);
        //faz a movimentaçãp da posição
        transform.position = new Vector3 (startPos = dist, transform.position.y, transform.position.z);

        if(temp > startPos + length)
        {
            startPos += length;
        }
        else if (temp < startPos - length)
        {
            startPos -= length;
        }
    }
}
