using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_DoorB : MonoBehaviour
{
    private static Trigger_DoorB _triggerDoorB;
    //Door
    public GameObject doorB;
    //Sound Door
    public AudioSource openDoorSound;
    //clip sound Door
    public AudioClip clipSoundDoor;
    //Camera Door Go
    public GameObject cameraToolGo_C;
    //Button Animation
    public GameObject buttonDown;
    
    public BoxCollider objectCollider;
    
    public GameObject textGoToBox;
    
    private void Awake()
    {
        _triggerDoorB = this;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textGoToBox.SetActive(true);
        }

        //Door B
        if (other.CompareTag("Box_B"))
        {
            doorB.GetComponent<Animator>().Play("Door_A_1");
            openDoorSound.PlayOneShot(clipSoundDoor);
            cameraToolGo_C.SetActive(true);
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
        cameraToolGo_C.SetActive(false);
        _triggerDoorB.enabled = false;
        objectCollider.enabled = false;
        textGoToBox.SetActive(false);
    }
}
