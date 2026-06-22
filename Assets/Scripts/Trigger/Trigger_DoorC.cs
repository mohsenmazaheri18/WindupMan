using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_DoorC : MonoBehaviour
{
    private Trigger_DoorC _triggerDoorC;
    //Door
    public GameObject doorC;
    //Sound Door
    public AudioSource openDoorSound;
    //clip sound Door
    public AudioClip clipSoundDoor;
    //Camera Door Go
    public GameObject cameraToolGo_A;
    //Button Animation
    public GameObject buttonDown;
    
    public BoxCollider objectCollider;
    
    public GameObject textGoToBox;
    
    private void Awake()
    {
        _triggerDoorC = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textGoToBox.SetActive(true);
        }

        //Door C
        if (other.CompareTag("Box_C"))
        {
            doorC.GetComponent<Animator>().Play("Door_B_2");
            openDoorSound.PlayOneShot(clipSoundDoor);
            cameraToolGo_A.SetActive(true);
            StartCoroutine(CameraFalse());
            buttonDown.GetComponent<ButtonMoveDownClicked>().enabled = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textGoToBox.SetActive(false);
        }
    }
    
    private IEnumerator CameraFalse()
    {
        yield return new WaitForSeconds(1f);
        cameraToolGo_A.SetActive(false);
        _triggerDoorC.enabled = false;
        objectCollider.enabled = false;
        textGoToBox.SetActive(false);
        
    }
}
