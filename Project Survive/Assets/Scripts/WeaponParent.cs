using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponParent : MonoBehaviour
{
    public Animator animator;
    public float delay = 0.3f;
    private bool attackBlocked = false;
    public GameObject tail;
    // Start is called before the first frame update
    public void Attack(string dirview){
        tail.SetActive(true);
        if (attackBlocked)
            return;


        if(dirview == "W"){          
            animator.SetTrigger("Attack_W");
            attackBlocked = true;
            StartCoroutine(DelayAttack());
          
        }
        if(dirview == "A"){           
            animator.SetTrigger("Attack_A");
            attackBlocked = true;
            StartCoroutine(DelayAttack());
         
        }
        if(dirview == "S"){
            animator.SetTrigger("Attack_S");
            attackBlocked = true;
            StartCoroutine(DelayAttack());
            
        }
        if(dirview == "D"){
            animator.SetTrigger("Attack_D");
            attackBlocked = true;
            StartCoroutine(DelayAttack());
            
        }
    }

    private IEnumerator DelayAttack()
    {
        yield return new WaitForSeconds(delay);
        attackBlocked = false;      
    }
}
