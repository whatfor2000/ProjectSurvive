using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMethod : MonoBehaviour
{

    public Animator animator;
    public float attackspeed;
    public bool attackBlocked = false;

    public Targettag targettag;
    


    // Start is called before the first frame update



    private void Start() {
        this.animator = GetComponent<Animator>();
    }

    public virtual void Attack(){
    
        if(this.attackBlocked == false){
            this.animator.SetTrigger("chage");
            this.attackBlocked = true;
            StartCoroutine(DelayAttack());
            
        }else{
            return;
        }
    }
    public IEnumerator DelayAttack(){
        yield return new WaitForSeconds(1-this.attackspeed);
        this.animator.SetTrigger("swing");
        this.attackBlocked = false;
    }
    
    public int baseDamage = 2;
    private void OnTriggerEnter2D(Collider2D target) {
        if(target.gameObject.CompareTag(targettag.ToString())){
            target.gameObject.GetComponent<stats>().TakeDamage(baseDamage,this.gameObject); 
        }
    }

    public enum Targettag{
    Player,
    Enamy
}

   
}
