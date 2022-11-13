using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;

        private Animator animator;

        private WeaponParent weaponParent;

        private string dirview = "W";

        private void Start()
        {
            weaponParent = GameObject.Find("Sword").GetComponent<WeaponParent>();
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
                dirview = "A";
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
                dirview = "D";
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
                dirview = "W";
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
                dirview = "S";

            }

            if(Input.GetKey(KeyCode.Alpha1))
                weaponParent = GameObject.Find("Sword64").GetComponent<WeaponParent>();

            if(Input.GetKey(KeyCode.Alpha2))
                weaponParent = GameObject.Find("Sword").GetComponent<WeaponParent>();


            if(Input.GetMouseButtonDown(0)){
                weaponParent.Attack(dirview);
            }

          

            

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }
    }
}
