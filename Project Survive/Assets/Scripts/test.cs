using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class test : MonoBehaviour
{

    Vector2 mouse;
    [SerializeField]
    private InputActionReference pointterPosition;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        mouse = GetPointerInput();
    }

    void OnDrawGizmosSelected()
    {
        if (mouse != null)
        {
            // Draws a blue line from this transform to the target
            Gizmos.color = Color.blue;
            Gizmos.DrawLine(transform.position, mouse);
        }
    }

    private Vector2 GetPointerInput(){
            Vector3 mousePos = pointterPosition.action.ReadValue<Vector2>();
            mousePos.z = UnityEngine.Camera.main.nearClipPlane;
            return UnityEngine.Camera.main.ScreenToWorldPoint(mousePos) - transform.position;
        }
}
