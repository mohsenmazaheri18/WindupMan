using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TriggerEndGame : MonoBehaviour
{
    public GameObject cameraFinish;
    public GameObject character;
    public GameObject characterCamera;
    public GameObject uiGameObject;

    public GameObject credits;
    
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            cameraFinish.SetActive(true);
            character.SetActive(false);
            characterCamera.SetActive(false);
            uiGameObject.SetActive(true);
            StartCoroutine(LastGame());
        }
    }

    IEnumerator LastGame()
    {
        yield return new WaitForSeconds(3f);
        credits.SetActive(true);
        
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
}
