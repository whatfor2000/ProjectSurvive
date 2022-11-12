using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Animator animator;
     public float delay = 0.3f;
     private bool attackBlocked = false;
    // Start is called before the first frame update

    private void Update() {
        
    }
    public void Attack(){
        if(attackBlocked)
            return;


        animator.SetTrigger("Attack");
        attackBlocked = true;
        StartCoroutine(DelayAttack());

    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;
    }
}
