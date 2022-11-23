using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMethod : MonoBehaviour
{

    public Animator animator;
     public float attackspeed;
     private bool attackBlocked = false;

    // Start is called before the first frame update



    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
    }
    public void Attack(){
    
        if(attackBlocked == false){
            animator.SetTrigger("chage");
            attackBlocked = true;
            StartCoroutine(DelayAttack());
            
        }else{
            return;
        }
    }
    private IEnumerator DelayAttack(){
        yield return new WaitForSeconds(1-attackspeed);
        animator.SetTrigger("swing");
        attackBlocked = false;
    }
    private int baseDamage = 2;
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Enamy")){
            target.gameObject.GetComponent<Health>().TakeDamage(baseDamage); 
        }
    }
   
}
