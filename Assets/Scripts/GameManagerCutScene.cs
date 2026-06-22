using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerCutScene : MonoBehaviour
{
    public int speedCamera;
    public GameObject firstHole;
    public GameObject firstHoleCamera;
    public GameObject character;
    public GameObject cameraCharacter;

    private void Start()
    {
        StartCoroutine(playCameraFirst());
    }

    IEnumerator playCameraFirst()
    {
        yield return new WaitForSeconds(speedCamera);
        firstHole.SetActive(false);
        firstHoleCamera.SetActive(false);
        character.SetActive(true);
        cameraCharacter.SetActive(true);
    }
}
