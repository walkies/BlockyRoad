using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag2 : MonoBehaviour
{

    public float Speed = 0.01f;
    public Rigidbody rb3;

    Vector3 move = new Vector3(-5, 0, 0);

    void start()
    {
    }
    void Update()
    {
        Vector3 clampedPosition3 = transform.position;
        clampedPosition3.z = Mathf.Clamp(clampedPosition3.z, -1, -1);
        clampedPosition3.y = Mathf.Clamp(clampedPosition3.y, 1.5f, 1.5f);
        clampedPosition3.x = Mathf.Clamp(clampedPosition3.x, 0, 6);
        transform.position = clampedPosition3;


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody == rb3)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    if (touchDeltaPosition.y > 1)
                    {
                        rb3.MovePosition(transform.position + move * Speed);
                    }
                    if (touchDeltaPosition.y < 1)
                    {
                        rb3.MovePosition(transform.position - move * Speed);
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

