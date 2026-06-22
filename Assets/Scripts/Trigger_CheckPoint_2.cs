using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_CheckPoint_2 : MonoBehaviour
{
    public GameObject textShowSaved;
    public GameObject SpawnPoint;
    public GameObject Player;
    
    public int savePoint;

    private void Awake()
    {
        savePoint = PlayerPrefs.GetInt("GameSaved");
        if (savePoint == 2)
        {
            Player.transform.position = SpawnPoint.transform.position;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            savePoint = 2;
            textShowSaved.SetActive(true);
            PlayerPrefs.SetInt("GameSaved", savePoint);
            Debug.Log(savePoint);
            StartCoroutine(GameSaveTextFalse());
        }
    }

    private IEnumerator GameSaveTextFalse()
    {
        yield return new WaitForSeconds(1f);
        textShowSaved.SetActive(false);
        gameObject.SetActive(false);
    }
}
