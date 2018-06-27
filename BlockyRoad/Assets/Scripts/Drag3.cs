using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag3 : MonoBehaviour
{

    public float Speed = 0.01f;
    public Rigidbody rb4;

    Vector3 move = new Vector3(-5, 0, 0);

    void start()
    {
    }
    void Update()
    {
        Vector3 clampedPosition4 = transform.position;
        clampedPosition4.z = Mathf.Clamp(clampedPosition4.z, 1, 1);
        clampedPosition4.y = Mathf.Clamp(clampedPosition4.y, 1.5f, 1.5f);
        clampedPosition4.x = Mathf.Clamp(clampedPosition4.x, 0, 6);
        transform.position = clampedPosition4;


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody == rb4)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    if (touchDeltaPosition.y > 1)
                    {
                        rb4.MovePosition(transform.position + move * Speed);
                    }
                    if (touchDeltaPosition.y < 1)
                    {
                        rb4.MovePosition(transform.position - move * Speed);
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

