using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FuelNeedle : MonoBehaviour {

    Vector3 move = new Vector3(0, 0, 0.2f);
	void Start ()
    {
		
	}

    public void MoveNeedle()
    {
        transform.position = transform.position - move;
    }

}
