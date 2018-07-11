using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Manager : MonoBehaviour {

    public Text movesText;
    public Text coinsText;
    public Text timeText;
    public int coinReward;
    public int currentCoins;

    void Start ()
    {
        

    }

	void Update ()
    {
        var _coin = (int)Time.timeSinceLevelLoad;
        movesText.text = "" + Superscript.TilEmpty.ToString();
        timeText.text = "" + Time.timeSinceLevelLoad.ToString("0.00");
        coinsText.text = "" + (coinReward -_coin - Superscript.TilEmpty);
    }

    public void SaveCoins()
    {
        var _coin = (int)Time.timeSinceLevelLoad;
        currentCoins = (coinReward - _coin - Superscript.TilEmpty);
        Superscript.SaveInt(PlayerPrefs.GetInt("coins") + currentCoins);
    }
}
