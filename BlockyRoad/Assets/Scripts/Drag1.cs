using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drag1 : MonoBehaviour {

    public float Speed = 0.01f;
    public Rigidbody rb2;

    Vector3 move = new Vector3(-5, 0, 0);

    void start()
    {
    }
    void Update()
    {
        Vector3 clampedPosition2 = transform.position;
        clampedPosition2.z = Mathf.Clamp(clampedPosition2.z, -1, -1);
        clampedPosition2.y = Mathf.Clamp(clampedPosition2.y, 1.5f, 1.5f);
        clampedPosition2.x = Mathf.Clamp(clampedPosition2.x, -5, 5);
        transform.position = clampedPosition2;


        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody == rb2)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    if (touchDeltaPosition.y > 1)
                    {
                        rb2.MovePosition(transform.position + move * Speed);
                    }
                    if (touchDeltaPosition.y < 1)
                    {
                        rb2.MovePosition(transform.position - move * Speed);
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
