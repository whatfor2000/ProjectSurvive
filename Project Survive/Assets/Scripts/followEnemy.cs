using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class followEnemy : PlayerController
{
   
   public Transform target;
   public float minimumDistance;

   [SerializeField]
   Transform castPoint;

   private void Update() {
    PlayerControll(inputKey);
    if(CanSeePlayer(minimumDistance)){
        
    }else{
        this.inputKey.y = 0;
    }
   }

   bool CanSeePlayer(float distance){
    bool val = false;
    float casrDist = distance;

    Vector2 endPos = castPoint.position+Vector3.up * distance;
    //RaycastHit2D hit = Physics2D.CircleCast(endPos,distance,endPos,1 << LayerMask.NameToLayer("Player"));
    RaycastHit2D hit = Physics2D.Linecast(castPoint.position,endPos,1 << LayerMask.NameToLayer("Player"));
    
    if(hit.collider != null){
        if(hit.collider.gameObject.CompareTag("Player")){
            val = true;
            this.inputKey.y = 1;
        }else{
            val = false;
        }
        Debug.DrawLine(castPoint.position,endPos,Color.blue);
    }
   
    return val;
   }

    public override void PlayerControll(Vector2 input){
            Vector2 dir = input;
            if (input.x < 0){
                dir.x = -1;
                GetComponent<SpriteRenderer>().flipX = true;
            }else if (input.x > 0){
                dir.x = 1;
                GetComponent<SpriteRenderer>().flipX = false;
            }
            if (input.y > 0){
                dir.y = 1;
            }else if (input.y < 0){
                dir.y = -1;
            }
            if(input.x.Equals(0)&&input.y.Equals(0)){
                GetComponent<Rigidbody2D>().velocity = Vector2.zero;
            }

            dir.Normalize();
            GetComponent<Rigidbody2D>().velocity = speed * dir;

        }





   
}
