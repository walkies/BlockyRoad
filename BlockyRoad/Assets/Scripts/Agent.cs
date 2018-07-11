using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Agent : MonoBehaviour
{

    public float Speed = 1f;
    public Rigidbody rb1;
    public Collider col;
    public UnityEvent moveEvent;
    Vector3 movealt = new Vector3(Mathf.Round(-1), Mathf.Round(0), Mathf.Round(1));
    Vector3 move = new Vector3(Mathf.Round(0), Mathf.Round(0), Mathf.Round(1));
    public float height;
    public float sideBounds;
    public float dirMax;
    public float dirMin;

    #region ShopSetUps
    public GameObject ambulance;
    public GameObject sports;
    public GameObject police;
    public GameObject fire;
    #endregion



    public enum Orientation
    {
        X,
        Y
    }

    public Orientation direction;



    void Awake()
    {
      
        #region ShopSetUps

        if (PlayerPrefs.HasKey("Ambulance"))
        {
            if (gameObject.name == "bus" || gameObject.name == "bus (1)" || gameObject.name == "bus (2)")
            {
                gameObject.SetActive(false);
                GameObject newGo = Instantiate(ambulance);
            }
        }

        if (PlayerPrefs.HasKey("PoliceCar"))
        {
            if (gameObject.name == "car1" || gameObject.name == "car1 (1)")
            {
                gameObject.SetActive(false);
                GameObject newGo = Instantiate(police);
            }
        }

        if (PlayerPrefs.HasKey("FireTruck"))
        {
            if (gameObject.name == "truck")
            {
                gameObject.SetActive(false);
                GameObject newGo = Instantiate(fire);
            }
        }

        if (PlayerPrefs.HasKey("SportCar"))
        {
            if (gameObject.name == "agent")
            {
                gameObject.SetActive(false);
                GameObject newGo = Instantiate(sports);
            }
        }
    }

        #endregion


    void start()
    {
        
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
            if (hit.collider == col)
            {
                if (Input.touchCount == 1)
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
                        moveEvent.Invoke();
                        Superscript.TilEmpty++;
                        Debug.Log("Thie one elly");
                    }
                }
            }
        }
    }
}

