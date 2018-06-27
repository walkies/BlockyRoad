using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag4 : MonoBehaviour
{

    public float Speed = 0.01f;
    public Rigidbody rb5;

    Vector3 move = new Vector3(0, 0, 10);

    void start()
    {
    }
    void Update()
    {
        Vector3 clampedPosition5 = transform.position;
        clampedPosition5.z = Mathf.Clamp(clampedPosition5.z, -1, -1);
        clampedPosition5.y = Mathf.Clamp(clampedPosition5.y, 1.5f, 1.5f);
        clampedPosition5.x = Mathf.Clamp(clampedPosition5.x, 2, 2);
        transform.position = clampedPosition5;


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody == rb5)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    if (touchDeltaPosition.x > 1)
                    {
                        rb5.MovePosition(transform.position + move * Speed);
                    }
                    if (touchDeltaPosition.x < 1)
                    {
                        rb5.MovePosition(transform.position - move * Speed);
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

