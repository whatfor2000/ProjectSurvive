using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMethod : MonoBehaviour
{

   public Animator animator;
     public float attackspeed;
     public bool attackBlocked = false;

    // Start is called before the first frame update



    private void Start() {
        animator = GetComponent<Animator>();
    }

    private void Update() {
    }
    public virtual void Attack(){
    
        if(this.attackBlocked == false){
            //animator.SetTrigger("chage");
            this.attackBlocked = true;
            StartCoroutine(DelayAttack());
            
        }else{
            return;
        }
    }
    public IEnumerator DelayAttack(){
        yield return new WaitForSeconds(1-this.attackspeed);
       // animator.SetTrigger("swing");
        this.attackBlocked = false;
    }
    private int baseDamage = 2;
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag("Enamy")){
            target.gameObject.GetComponent<Health>().TakeDamage(baseDamage); 
        }
    }
   
}
