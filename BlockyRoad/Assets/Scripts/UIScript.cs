using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public Collider rb1;
    public UnityEvent myEvent;
    public UnityEvent myEvent2;

    int TapCount;
    public float MaxDubbleTapTime = 1;
    float NewTime;

    void Start()
    {
        TapCount = 0;
    }

    void Update()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == rb1)
            {
                if (Input.touchCount == 1)
                {
                    Touch touch = Input.GetTouch(0);
                    if (Input.GetTouch(0).phase == TouchPhase.Ended)
                    {
                        TapCount += 1;
                        NewTime = Time.time + MaxDubbleTapTime;
                    }
                    if (Time.time > NewTime)
                    {
                        TapCount = 0;
                    }
                    else if (TapCount == 2 && Time.time <= NewTime)
                    {
                        myEvent.Invoke();
                        myEvent2.Invoke();
                        TapCount = 0;
                    }
                   
                }
            }
        }
        
    }
}





