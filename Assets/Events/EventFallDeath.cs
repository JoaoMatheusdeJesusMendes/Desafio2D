using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
public class EventFallDeath : MonoBehaviour
{
    public UnityEvent enteredTheCollider;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "FallDeath")
        {
            enteredTheCollider.Invoke();
        }
    }
}
