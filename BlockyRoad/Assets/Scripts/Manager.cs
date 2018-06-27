using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public Text MovesText;

    void Start ()
    {
		
	}
	

	void Update ()
    {
        MovesText.text = "" + Superscript.TilEmpty.ToString();
    }
}
