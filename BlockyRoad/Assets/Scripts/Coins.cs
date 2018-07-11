using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Coins : MonoBehaviour {

    public Text coinsText;

	void Start ()
    {
		
	}
	

	void Update ()
    {
        coinsText.text = ("" +  PlayerPrefs.GetInt("coins"));
	}
}
