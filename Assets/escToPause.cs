using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class escToPause : MonoBehaviour
{
    public GameObject MenuPause;
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            MenuPause.SetActive(true);
            Time.timeScale = 0f;
        }
    }

    public void continueGame()
    {
        Time.timeScale = 1f;
    }
    public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }
    
    public void exit()
    {
        Application.Quit();
    }
}
