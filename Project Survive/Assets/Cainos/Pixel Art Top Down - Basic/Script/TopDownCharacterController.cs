using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;


namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {


        public float speed;

        private Animator animator;

        private WeaponMethod weaponMethod;

        private string dirview = "W";

        private Vector2 pointerInput;



        [SerializeField]
        private InputActionReference pointterPosition;


        

        private void Start(){
         
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
            mousedir();
            
            Vector2 dir = Vector2.zero;
            if (Input.GetAxisRaw("Horizontal") < 0){
                dir.x = -1;
                animator.SetTrigger("walk");
                mousedir();
            }else if (Input.GetAxisRaw("Horizontal") > 0){
                dir.x = 1;
                animator.SetTrigger("walk"); 
                mousedir();
            }

            if (Input.GetAxisRaw("Vertical") > 0){
                dir.y = 1;
                animator.SetTrigger("walk"); 
                mousedir();
            }else if (Input.GetAxisRaw("Vertical") < 0){
                dir.y = -1;
                animator.SetTrigger("walk"); 
                mousedir();
            }

            if(Input.GetKey(KeyCode.Alpha1))
             weaponMethod = GameObject.Find("Sword64").GetComponent<WeaponMethod>();

            if(Input.GetKey(KeyCode.Alpha2))
             weaponMethod = GameObject.Find("Sword").GetComponent<WeaponMethod>();


            if(Input.GetMouseButtonDown(0)){
             weaponMethod.Attack(dirview);
            }

          
            dir.Normalize();
            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
        private Vector2 GetPointerInput(){
            Vector3 mousePos = pointterPosition.action.ReadValue<Vector2>();
            mousePos.z = UnityEngine.Camera.main.nearClipPlane;
            return UnityEngine.Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        }
    }
}
