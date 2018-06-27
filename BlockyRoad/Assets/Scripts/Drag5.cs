using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag5 : MonoBehaviour
{

    public float Speed = 0.01f;
    public Rigidbody rb6;

    Vector3 move = new Vector3(0, 0, 10);

    void start()
    {
    }
    void Update()
    {
        Vector3 clampedPosition6 = transform.position;
        clampedPosition6.z = Mathf.Clamp(clampedPosition6.z, -1, -1);
        clampedPosition6.y = Mathf.Clamp(clampedPosition6.y, 1.5f, 1.5f);
        clampedPosition6.x = Mathf.Clamp(clampedPosition6.x, 2, 2);
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
                    if (touchDeltaPosition.x > 1)
                    {
                        rb6.MovePosition(transform.position + move * Speed);
                    }
                    if (touchDeltaPosition.x < 1)
                    {
                        rb6.MovePosition(transform.position - move * Speed);
                    }
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Superscript.Move();
                }
            }
        }
    }
}

