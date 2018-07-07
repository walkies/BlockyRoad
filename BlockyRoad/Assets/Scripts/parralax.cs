using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class parralax : MonoBehaviour
{
    public float scrollSpeed;
    public float tileSizeZ;
    public int x;
    public Vector3 move;


    private Vector3 startPosition;

    void Start()
    {
    move = new Vector3(x, 0, 0);
    startPosition = transform.position;
    }

    void Update()
    {
        float newPosition = Mathf.Repeat(Time.time * scrollSpeed, tileSizeZ);
        transform.position = startPosition + move * newPosition;
    }
}
