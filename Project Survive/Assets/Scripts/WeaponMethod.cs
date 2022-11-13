using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMethod : MonoBehaviour
{

    public Animator animator;
     public float delay = 0.3f;
     private bool attackBlocked = false;
    // Start is called before the first frame update



    private void Start() {
        animator = GetComponent<Animator>();
    }
    public void Attack(string dirview){
        if(attackBlocked)
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
    private int baseDamage = 2;

    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Enamy")){
            target.gameObject.GetComponent<Health>().TakeDamage(baseDamage); 
        }
    }
   
}
