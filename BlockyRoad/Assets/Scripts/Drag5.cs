using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag5 : MonoBehaviour
{

    public float Speed = 0.01f;
    public Rigidbody rb6;

    Vector3 move = new Vector3(-5, 0, 0);

    void start()
    {
    }
    void Update()
    {

            Vector3 clampedPosition6 = transform.position;
            clampedPosition6.z = Mathf.Clamp(clampedPosition6.z, 1, 1);
            clampedPosition6.y = Mathf.Clamp(clampedPosition6.y, 1.1f, 1.1f);
            clampedPosition6.x = Mathf.Clamp(clampedPosition6.x, 0, 6);
            transform.position = clampedPosition6;


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody == rb6)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    if (touchDeltaPosition.y > 1)
                    {
                        rb6.MovePosition(transform.position + move * Speed);
                    }
                    else if (touchDeltaPosition.y < 1)
                    {
                        rb6.MovePosition(transform.position - move * Speed);
                    }
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                  
                }
            }
        }
    }
}

