using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update
    private Animator animator;
    public float currentHealth;
    public float maxHealth;
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

    public void TakeDamage(int damage){
        animator.Play("hit");
        currentHealth -= damage;
        
    }
    private void stop(){
        animator.Play("Idle");
    }
}
