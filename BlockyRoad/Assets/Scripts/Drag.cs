using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drag : MonoBehaviour
{
    public float Speed = 0.02f;
    public Rigidbody rb;
    Vector3 move = new Vector3(0, 0, 10);
    public bool TouchingL = false;
    public bool TouchingR = false;

    void start()
    {
        rb = GetComponent<Rigidbody>();
    }
    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody != null)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    if (touchDeltaPosition.x > 1 && TouchingR == false)
                    {
                        TouchingL = false;
                        rb.MovePosition(transform.position + move * Speed);
                    }
                    if (touchDeltaPosition.x < 1&& TouchingL == false)
                    {
                        TouchingR = false;
                        rb.MovePosition(transform.position - move  * Speed);
                    }
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







