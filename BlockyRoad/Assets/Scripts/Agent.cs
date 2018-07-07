using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Agent : MonoBehaviour
{

    public float Speed = 1f;
    public Rigidbody rb1;
    Vector3 movealt = new Vector3(Mathf.Round(-1), Mathf.Round(0), Mathf.Round(1));
    Vector3 move = new Vector3(Mathf.Round(0), Mathf.Round(0), Mathf.Round(1));
    public float height;
    public float sideBounds;
    public float dirMax;
    public float dirMin;

    public enum Orientation
    {
        X,
        Y
    }

    public Orientation direction;

    void start()
    {
        if (direction == Orientation.X)
        {

        }
    }

    void Update()
    {
        if (direction == Orientation.X)
        {

            Vector3 clampedPosition = transform.position;
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, dirMin, dirMax);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, height, height);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, sideBounds, sideBounds);
            transform.position = clampedPosition;
        }
        else
        {

            Vector3 clampedPosition = transform.position;
            clampedPosition.z = Mathf.Clamp(clampedPosition.z, sideBounds, sideBounds);
            clampedPosition.y = Mathf.Clamp(clampedPosition.y, height, height);
            clampedPosition.x = Mathf.Clamp(clampedPosition.x, dirMin, dirMax);
            transform.position = clampedPosition;
        }

        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.GetTouch(0).position);
        if (Physics.Raycast(ray, out hit))
        {
            if (hit.rigidbody == rb1)
            {
                if ((Input.touchCount > 0) && (Input.GetTouch(0).phase == TouchPhase.Moved))
                {
                    if (direction == Orientation.X)
                    {
                        Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                        if (touchDeltaPosition.x > 0.5)
                        {
                            rb1.MovePosition(transform.position + move * Time.deltaTime * 5);
                        }
                        else if (touchDeltaPosition.x < 0.5)
                        {
                            rb1.MovePosition(transform.position - move * Time.deltaTime * 5);
                        }
                    }
                    else
                    {
                        Vector3 touchDeltaPosition = Input.GetTouch(0).deltaPosition;
                        if (touchDeltaPosition.y > 0.5)
                        {
                            rb1.MovePosition(transform.position + movealt * Time.deltaTime * 5);
                        }
                        else if (touchDeltaPosition.y < 0.5)
                        {
                            rb1.MovePosition(transform.position - movealt * Time.deltaTime * 5);
                        }
                    }
                }
                else if (Input.GetTouch(0).phase == TouchPhase.Ended)
                {     
                    Superscript.TilEmpty++;
                    Debug.Log("Thie one elly");
                }
            }
        }
    }

    void OnTriggerEnter(Collider c)
    {
        if (c.gameObject.tag == "terrainL")
        {

        }
        if (c.gameObject.tag == "terrainR")
        {

        }
    }
}

