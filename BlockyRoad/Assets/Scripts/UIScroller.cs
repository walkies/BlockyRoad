using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UIScroller : MonoBehaviour {

    public Collider rb1;
    public int left;
    public int right;

    void Start ()
    {
		
	}


    void Update()
    {
        Vector3 clampedPosition = transform.position;
        clampedPosition.x = Mathf.Clamp(clampedPosition.x, left, right);
        transform.position = clampedPosition;

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.collider == rb1)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                    if (touchDeltaPosition.x > 0.5)
                    {
                        rb1.gameObject.transform.Translate(Vector3.right * Time.deltaTime * 20);
                    }
                    else if (touchDeltaPosition.x < 0.5)
                    {
                        rb1.gameObject.transform.Translate(Vector3.left * Time.deltaTime * 20);
                    }
                }
            }
        }
    }
                   
}
