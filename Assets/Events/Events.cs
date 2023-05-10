using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


//RequireComponent(typeof(Rigidbody)) -> Adiciona altomaticamente o rigidbody quando eu colocar esse codigo
public class Events : MonoBehaviour
{
    public UnityEvent enteredTheCollider;
    public UnityEvent cameOutOfTheCollider;
    
    //cria eventos e quando acontecer algo vai ativar o sinal para uma outra ação ocorrer e quando sair
    //colocar as funções de hit aqui
    private void OnTriggerEnter(Collider2D other){
        enteredTheCollider.Invoke();
    }
    private void OnTriggerExit(Collider2D other){
        cameOutOfTheCollider.Invoke();
    }
}
