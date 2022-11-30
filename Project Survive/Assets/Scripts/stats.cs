using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class stats : MonoBehaviour
{


    // Start is called before the first frame update
    private Animator animator;
    public float currentHealth;
    public float maxHealth;

    public healthbar hp;
    
   

    
    void Start()
    {
        animator = GetComponent<Animator>();
        currentHealth = maxHealth;    
    }
    private void Update() {
        if(currentHealth <= 0){
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage, GameObject sender){
        
        if(!GetComponent<PlayerController>().iframe){
            animator.Play("hit");
            currentHealth -= damage;
            knockback temp = GetComponent<knockback>();
            if(temp != null){
                temp.KnockBack(sender);
            }
        }
        if(!currentHealth.Equals(maxHealth)){
            hp.enable();
        }else{
            hp.disable();
        }
    }
    public void TakeDamage(int damage){
        if(!GetComponent<PlayerController>().iframe){
            animator.Play("hit");
            currentHealth -= damage;
            knockback temp = GetComponent<knockback>();
        }  
    }
    private void stop(){
        animator.Play("Idle");
    }
}
