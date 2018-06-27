using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{

    public float Speed = 0.01f;
    public Rigidbody rb1;

    Vector3 move = new Vector3(0, 0, 10);

    public bool TouchingL = false;
    public bool TouchingR = false;

    void start()
    {
        
    }
    void Update()
    {
        Vector3 clampedPosition1 = transform.position;
        clampedPosition1.z = Mathf.Clamp(clampedPosition1.z, -5, 1);
        clampedPosition1.y = Mathf.Clamp(clampedPosition1.y, 1, 1f);
        clampedPosition1.x = Mathf.Clamp(clampedPosition1.x, 3, 3f);
        transform.position = clampedPosition1;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody == rb1)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    if (touchDeltaPosition.x > 1 && TouchingR == false)
                    {
                        TouchingL = false;
                        rb1.MovePosition(transform.position + move * Speed);
                    }
                    if (touchDeltaPosition.x < 1 && TouchingL == false)
                    {
                        TouchingR = false;
                        rb1.MovePosition(transform.position - move * Speed);
                    }
                }
                if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {
                    Superscript.Move();
                }
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "terrainL")
        {
            TouchingL = true;
        }
        if (c.gameObject.tag == "terrainR")
        {
            TouchingR = true;
        }
    }
}

