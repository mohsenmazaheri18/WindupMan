using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TrapLaserTrigger : MonoBehaviour
{
    public GameObject LosePanel;
    public GameObject soundAlarm;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            soundAlarm.SetActive(true);
            StartCoroutine(WaitToReload());
            LosePanel.SetActive(true);
            PlayerPrefs.SetInt("GameLose", 1);
        }
    }
    private IEnumerator WaitToReload()
    {
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Game");
    }
}
