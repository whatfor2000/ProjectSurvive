using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        private WeaponMethod weaponMethod;

        private string dirview = "W";

        private void Start()
        {
         weaponMethod = GameObject.Find("Sword").GetComponent<WeaponMethod>();
            animator = GetComponent<Animator>();
        }
        private void Update(){
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A)){
                dir.x = -1;
                animator.SetInteger("Direction", 3);
                dirview = "A";
            }else if (Input.GetKey(KeyCode.D)){
                dir.x = 1;
                animator.SetInteger("Direction", 2);
                dirview = "D";
            }

            if (Input.GetKey(KeyCode.W)){
                dir.y = 1;
                animator.SetInteger("Direction", 1);
                dirview = "W";
            }else if (Input.GetKey(KeyCode.S)){
                dir.y = -1;
                animator.SetInteger("Direction", 0);
                dirview = "S";
            }

            if(Input.GetKey(KeyCode.Alpha1))
             weaponMethod = GameObject.Find("Sword64").GetComponent<WeaponMethod>();

            if(Input.GetKey(KeyCode.Alpha2))
             weaponMethod = GameObject.Find("Sword").GetComponent<WeaponMethod>();


            if(Input.GetMouseButtonDown(0)){
             weaponMethod.Attack(dirview);
            }

          
            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
