using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMethod : MonoBehaviour
{

    public Animator animator;
     public float delay;
     private bool attackBlocked = false;
    // Start is called before the first frame update



    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
        if(Input.GetMouseButton(0)){
             Attack();
            }
    }
    public void Attack(){
    
        if(attackBlocked == false){
            animator.SetTrigger("swing");
            attackBlocked = true;
            StartCoroutine(DelayAttack());
        }else{
            return;
        }
    }
    private IEnumerator DelayAttack(){
        Debug.Log(delay);
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
