using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

    public GameObject endPanel;
    public Text timeTaken;
    public Text moves;
    public Text coinsEarned;
    public Manager mang;

    void Start ()
    {
        GetComponentInChildren<Manager>();
    }
	

	void Update ()
    {
        
    }

    public void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            endPanel.SetActive(true);
            StartCoroutine("EndLevel");
            mang.SaveCoins();
            Superscript.SaveString(("coins"), mang.currentCoins.ToString());
            StopCoroutine("EndLevel");
        }
    }
    public IEnumerator EndLevel()
    {
        yield return new WaitForSeconds(1);
        timeTaken.gameObject.SetActive(true);
        moves.gameObject.SetActive(true);
        coinsEarned.gameObject.SetActive(true);
        Time.timeScale = 0;
    }
}
