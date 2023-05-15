using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class CoinCollectedEvent : MonoBehaviour
{
    public UnityEvent enteredTheCollider;

    //cria eventos e quando acontecer algo vai ativar o sinal para uma outra ação ocorrer e quando sair
    //colocar as funções de hit aqui
    private void OnTriggerEnter2D(Collider2D other){
        if(other.gameObject.layer == 9)
        {
            enteredTheCollider.Invoke();
        }
    } 
}
