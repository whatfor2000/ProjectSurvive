using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMethod : MonoBehaviour
{
    private int baseDamage = 2;

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Enamy")){
            target.gameObject.GetComponent<Health>().TakeDamage(baseDamage); 
        }
    }
   
}
