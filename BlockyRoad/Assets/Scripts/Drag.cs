using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drag : MonoBehaviour
{
    public float Speed = 0.01f;
    public Rigidbody rb;

    Vector3 move = new Vector3(0, 0, 10);

    void start()
    {
    }
    void Update()
    {
            Vector3 clampedPosition = transform.position;
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, -4.5f, -1);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, 0.77f, 0.77f);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, 0, 0);
            transform.position = clampedPosition;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody == rb)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    if (touchDeltaPosition.x > 1)
                    {
                        rb.MovePosition(transform.position + move * Speed);
                    }
                    else if (touchDeltaPosition.x < 1)
                    {
                        rb.MovePosition(transform.position - move  * Speed);
                    }
                }
                else if(Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    
                }
            }
        }
    }
}







