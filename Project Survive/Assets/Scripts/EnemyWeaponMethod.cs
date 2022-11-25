using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWeaponMethod : WeaponMethod
{
    private void Start() {
        this.animator = GetComponentInParent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D target) {
        Debug.Log("alskdfl");
        if(target.gameObject.CompareTag(tag)){
            target.gameObject.GetComponent<Health>().TakeDamage(baseDamage); 
        }
    }
   
}

