using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : PlayerController
{
    private new float speed;
    public float checkRadius;
    public float attackRadius;
    public bool shouldRotate;
    private new Animator animator;
    private new WeaponMethod weaponMethod;
    private new WeaponParent weaponParent;

    public LayerMask whatIsPlayer;

    private Transform target;
    private Rigidbody2D rb;
    private Animator anim;
    private Vector2 movement;
    public Vector3 dir;

    private bool isInChaseRange;
    private bool isInAttackRange;

    private void Start() {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        target = GameObject.FindWithTag("Player").transform;
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
            

            if(Input.GetMouseButton(0)){
                GetComponentInChildren<WeaponMethod>().Attack();
            }
            if(GetComponentInChildren<WeaponMethod>().attackBlocked){
              mousedir();  
            }
            dir.Normalize();
            GetComponent<Rigidbody2D>().velocity = speed * dir;

        }

    private void FixedUpdate() {
        if(isInChaseRange && !isInAttackRange){
            PlayerControll(movement); 
        }
        if(isInAttackRange){
                movement = Vector2.zero;
                PlayerControll(movement);
        }

    }
  
    

    }
