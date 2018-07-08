using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UIScript : MonoBehaviour
{


    public Collider rb1;
    public UnityEvent myEvent;
    public UnityEvent myEvent2;

    void Start()
    {

    }


    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == rb1)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Stationary))
                {
                    myEvent.Invoke();
                    myEvent2.Invoke();
                }
            }
        }
    }

}
