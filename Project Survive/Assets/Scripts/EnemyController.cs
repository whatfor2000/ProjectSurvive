using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : WeaponMethod
{
    public float speed;
    public float checkRadius;
    public float attackRadius;
    public bool shouldRotate;

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
        //anim.SetBool("isRunning",isInChaseRange);

        isInChaseRange = Physics2D.OverlapCircle(transform.position,checkRadius,whatIsPlayer);
        isInAttackRange = Physics2D.OverlapCircle(transform.position,attackRadius,whatIsPlayer);

        dir = (target.position - transform.position);
        float angle = Mathf.Atan2(dir.y,dir.x) * Mathf.Rad2Deg;
        dir.Normalize();
        movement = dir;
        if(shouldRotate){
            anim.SetFloat("X",dir.x);
            anim.SetFloat("Y",dir.y);
        }
    }
    private void FixedUpdate() {
        anim.SetBool("isWalk",false);
            if(isInChaseRange && !isInAttackRange){
                anim.SetBool("isWalk",true);
                MoveCharacter(movement);
            }
            if(isInAttackRange){
                anim.SetBool("isWalk",false);
                if(!attackBlocked){
                    Attack();  
                    target.GetComponent<Health>().TakeDamage(1);
                    rb.velocity = Vector2.zero;
                    StartCoroutine(DelayAttack());
                }
            }
        }
        private void MoveCharacter(Vector2 dir){
            rb.MovePosition((Vector2)transform.position + (dir * this.speed * Time.deltaTime));
        }


    

    

    }
