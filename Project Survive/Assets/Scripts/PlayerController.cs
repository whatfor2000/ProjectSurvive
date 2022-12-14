using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    //==============================================================================
        public float speed;
        public Animator animator;
        public WeaponMethod weaponMethod;
        public Vector2 pointerInput;
        public WeaponParent weaponParent;
     //===================================================================================   
        private bool isdodge = false;
        public bool iframe = false;
        private Vector2 inputKey;

        
        [SerializeField]
        private InputActionReference pointterPosition;
        private void Start(){
            weaponParent = GetComponentInChildren<WeaponParent>();
            weaponMethod = GetComponentInChildren<WeaponMethod>();
            this.animator = GetComponent<Animator>();
        }
        public void mousedir(){
            if(this.pointerInput.x > 0){
                GetComponent<SpriteRenderer>().flipX = false;
            }else if(this.pointerInput.x < 0){
                GetComponent<SpriteRenderer>().flipX = true;
            }
        }
        private void Update(){
            this.inputKey = new Vector2(Input.GetAxisRaw("Horizontal"),Input.GetAxisRaw("Vertical"));
            this.pointerInput = GetPointerInput();
            weaponParent.Pointerposition = this.pointerInput;
            PlayerControll(inputKey);
        }


        public virtual void PlayerControll(Vector2 input){
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
            if(Input.GetAxisRaw("Jump").Equals(1) && isdodge == false){
                speed = 10;
                this.animator.SetBool("isdodge",true);
                iframe = true;
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

        public IEnumerator Delay(){
        yield return new WaitForSeconds(0.2f);
        iframe = false;
        speed = 3;
        this.animator.SetBool("isdodge",false);
        yield return new WaitForSeconds(2);
        isdodge = false;
        }
        private Vector2 GetPointerInput(){
            Vector3 mousePos = pointterPosition.action.ReadValue<Vector2>();
            mousePos.z = UnityEngine.Camera.main.nearClipPlane;
            return UnityEngine.Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        }
}
