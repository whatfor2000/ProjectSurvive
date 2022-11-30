using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Healingpool : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Player")){
            Debug.Log("heel");

        }
    }
}
