using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHitAndAlarm : MonoBehaviour
{
    public GameObject soundAlarm;
    public Animator animCamera;

    public GameObject LosePanel;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            animCamera.enabled = false;
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
