using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class knockback : MonoBehaviour
{
    public UnityEvent onBegin,onDone;
    
    public void KnockBack(GameObject sender){
        StopAllCoroutines();
        onBegin?.Invoke();
        Vector2 dir = (transform.position - sender.transform.position).normalized;
        GetComponent<Rigidbody2D>().AddForce(dir * 1000,ForceMode2D.Impulse);
        StartCoroutine(Reset());
    }
    private IEnumerator  Reset() {
        yield return new WaitForSeconds(0.15f);
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        onDone?.Invoke();
    }
    
}
