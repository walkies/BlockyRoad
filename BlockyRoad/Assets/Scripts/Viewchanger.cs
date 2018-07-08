using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Viewchanger : MonoBehaviour
{
    public GameObject mainMenu;
    public GameObject levels;
    public GameObject options;
    public GameObject shop;
    public GameObject achievements;

    void Start()
    {
       
    }

    void Update()
    {

    }

    public void PlayLevel(string name)
    {
        SceneManager.LoadScene(name, LoadSceneMode.Single);
    }

    public void Levels()
    {
        mainMenu.SetActive(false);
        levels.SetActive(true);
        options.SetActive(false);
        shop.SetActive(false);
        achievements.SetActive(false);
    }

    public void Back()
    {
        mainMenu.SetActive(true);
        levels.SetActive(false);
        options.SetActive(false);
        shop.SetActive(false);
        achievements.SetActive(false);
    }

    public void Options()
    {
        mainMenu.SetActive(false);
        levels.SetActive(false);
        options.SetActive(true);
        shop.SetActive(false);
        achievements.SetActive(false);
    }

    public void Shop()
    {
        mainMenu.SetActive(false);
        levels.SetActive(false);
        options.SetActive(false);
        shop.SetActive(true);
        achievements.SetActive(false);
    }

    public void Achievements()
    {
        mainMenu.SetActive(false);
        levels.SetActive(false);
        options.SetActive(false);
        shop.SetActive(false);
        achievements.SetActive(true);
    }

    public void Quit()
    {
        Debug.Log("working");
        Application.Quit();
    }
}