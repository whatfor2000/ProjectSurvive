using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float speed = 10.0f;
    private Rigidbody rb;
    public Vector3 movement;

    private bool onTheFloor = true;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");
        movement = new Vector3(x,-0.4f,z); 
     }
     private void OnCollisionEnter(Collision other) {
         if(other.gameObject.tag == "ground"){
            onTheFloor = true;
         }
        }
     private void FixedUpdate() {
        moveAble(movement);
        if(Input.GetButton("Jump") && (onTheFloor)){
         rb.AddForce(new Vector3(0,500,0), ForceMode.Impulse);
         onTheFloor = false;
        }
     }
     void moveAble(Vector3 move){
        rb.velocity = move*speed;
     }
}
