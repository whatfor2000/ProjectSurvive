﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed = 3;
        private Animator animator;
        private WeaponMethod weaponMethod;
        private Vector2 pointerInput;
        private WeaponParent weaponParent;
        private bool isdodge = false;

        [SerializeField]
        private InputActionReference pointterPosition;
        private void Start(){

            weaponParent = GetComponentInChildren<WeaponParent>();
            weaponMethod = GameObject.Find("Sword").GetComponent<WeaponMethod>();
            animator = GetComponent<Animator>();

        }
        void mousedir(){
            if(pointerInput.x > 0){
                GetComponent<SpriteRenderer>().flipX = false;
            }else if(pointerInput.x < 0){
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        private void Update(){

            pointerInput = GetPointerInput();
            weaponParent.Pointerposition = pointerInput;
            Vector2 dir = Vector2.zero;
            if (Input.GetAxisRaw("Horizontal") < 0){
                dir.x = -1;
                animator.SetBool("IsWalk",true);
                GetComponent<SpriteRenderer>().flipX = true;
            }else if (Input.GetAxisRaw("Horizontal") > 0){
                dir.x = 1;
                animator.SetBool("IsWalk",true);
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (Input.GetAxisRaw("Vertical") > 0){
                dir.y = 1;
                animator.SetBool("IsWalk",true); 
           
            }else if (Input.GetAxisRaw("Vertical") < 0){
                dir.y = -1;
                animator.SetBool("IsWalk",true); 
                
            }
            if(Input.GetAxisRaw("Vertical").Equals(0)  && Input.GetAxisRaw("Horizontal").Equals(0)){
                animator.SetBool("IsWalk",false);
            }

            if(Input.GetAxisRaw("Jump").Equals(1) && isdodge == false){
                speed = 10;
                animator.SetBool("isdodge",true);

                isdodge = true;
                StartCoroutine(Delay());
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

        private IEnumerator Delay(){
        yield return new WaitForSeconds(0.2f);

        speed = 3;
        animator.SetBool("isdodge",false);
        yield return new WaitForSeconds(2);
        isdodge = false;
        }
        private Vector2 GetPointerInput(){
            Vector3 mousePos = pointterPosition.action.ReadValue<Vector2>();
            mousePos.z = UnityEngine.Camera.main.nearClipPlane;
            return UnityEngine.Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        }
    }
}
