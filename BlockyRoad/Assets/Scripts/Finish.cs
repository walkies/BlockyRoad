using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;

public class Finish : MonoBehaviour {

    public GameObject endPanel;
    public Text timeTaken;
    public Text moves;
    public Text coinsEarned;
    public UnityEvent myEvent;

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
            StartCoroutine("EndLevel");
            endPanel.SetActive(true);
            myEvent.Invoke();
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
