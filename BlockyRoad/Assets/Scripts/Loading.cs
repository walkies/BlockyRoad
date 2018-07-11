using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Loading : MonoBehaviour {


	void Start ()
    {
        StartCoroutine("FakeLoad");
	}
	

	void Update ()
    {
		
	}

    public IEnumerator FakeLoad()
    {
        yield return new WaitForSeconds(2);
        gameObject.SetActive(false);
    }


}
