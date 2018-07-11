using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using UnityEngine;

public class UIScript : MonoBehaviour
{
    public Collider rb1;
    public UnityEvent myEvent;
    public UnityEvent myEvent2;
    public bool isShop;

    int TapCount;
    public float MaxDubbleTapTime = 0.3f;
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
                        if (isShop == false)
                        {
                            myEvent.Invoke();
                            myEvent2.Invoke();
                            TapCount = 0;
                        }
                        else if (isShop == true)
                        {
                            if (PlayerPrefs.GetInt("coins") >= 100 && PlayerPrefs.HasKey(gameObject.name) == false)
                            {
                                PlayerPrefs.SetString(gameObject.name, ("Purchased"));
                                myEvent.Invoke();
                                myEvent2.Invoke();
                            }
                        }
                    }      
                }
            }
        }
        
    }
    public void TakeCoins()
    {
        Superscript.SaveInt(PlayerPrefs.GetInt("coins") - 100);
    }
}





