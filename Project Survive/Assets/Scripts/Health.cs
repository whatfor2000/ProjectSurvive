using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    // Start is called before the first frame update

    public float currentHealth;
    public float maxHealth;
    void Start()
    {
        currentHealth = maxHealth;    
    }
    private void Update() {
        if(currentHealth <= 0){
            Destroy(this.gameObject);
        }
    }

    public void TakeDamage(int damage){
        currentHealth -= damage;
    }
}