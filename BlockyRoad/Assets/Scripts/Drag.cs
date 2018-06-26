using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Drag : MonoBehaviour
{
    public float speed = 0.0005f;

    void start()
    {

    }
    void Update()
    {

    }

    void OnTriggerStay(Collider c)
    {
        if (c.gameObject.tag != "terrain")
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
                        if (touchDeltaPosition.x > 1)
                        {
                            transform.Translate(0, 0.01f, 0);
                        }
                        if (touchDeltaPosition.x < 1)
                        {
                            transform.Translate(0, -0.01f, 0);
                        }
                    }
                }
            }
        }
    }
    void OnCollisionEnter(Collision d)
    {
        if (d.gameObject.tag == "terrain")
        {
            Debug.Log("ok");
        }
    }
}







