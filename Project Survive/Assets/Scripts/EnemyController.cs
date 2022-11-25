using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PlayerController
{
    
    public float checkRadius;
    public float attackRadius;
    public bool shouldRotate;
    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
        this.weaponParent = GetComponentInChildren<WeaponParent>();
        this.weaponMethod = GameObject.Find("Sword").GetComponent<WeaponMethod>();
    }
    private void Update() {


        Debug.DrawLine(transform.position,target.position,Color.blue);
        isInChaseRange = Physics2D.OverlapCircle(transform.position,checkRadius,whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position,attackRadius,whatIsPlayer);
        dir = (target.position - transform.position);
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
    }
    public override void PlayerControll(Vector2 input){
            Vector2 dir = Vector2.zero;
            if (input.x < 0){
                dir.x = -1;
                this.animator.SetBool("IsWalk",true);
                GetComponent<SpriteRenderer>().flipX = true;
            }else if (input.x > 0){
                dir.x = 1;
                this.animator.SetBool("IsWalk",true);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (input.y > 0){
                dir.y = 1;
                this.animator.SetBool("IsWalk",true); 
            }else if (input.y < 0){
                dir.y = -1;
                this.animator.SetBool("IsWalk",true); 
            }
            if(input.x.Equals(0)&&input.y.Equals(0)){
                this.animator.SetBool("IsWalk",false);
            }
            dir.Normalize();
            GetComponent<Rigidbody2D>().velocity = this.speed * dir;

        }

    private void FixedUpdate() {
        if(isInChaseRange && !isInAttackRange){
            PlayerControll(movement); 
            this.pointerInput = target.transform.position - transform.position;
            weaponParent.Pointerposition = this.pointerInput;
        }else{
            PlayerControll(Vector2.zero); 
            this.pointerInput = Vector2.zero;
        }
        if(isInAttackRange){
                movement = Vector2.zero;
                PlayerControll(movement);
                this.pointerInput = target.transform.position - transform.position;
                weaponParent.Pointerposition = pointerInput;
                GetComponentInChildren<WeaponMethod>().Attack();
        }

    }
  
    

    }
