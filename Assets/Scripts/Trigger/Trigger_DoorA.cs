using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_DoorA : MonoBehaviour
{
    private static Trigger_DoorA _triggerDoorA;
    //Door
    public GameObject doorA;
    //Sound Door
    public AudioSource openDoorSound;
    //clip sound Door
    public AudioClip clipSoundDoor;
    //Camera Door Go
    public GameObject cameraToolGo_A;
    //Button Animation
    public GameObject buttonDown;

    public BoxCollider objectCollider;

    public GameObject textHelp;
    
    private void Awake()
    {
        _triggerDoorA = this;
    }

    private void OnTriggerStay(Collider other)
    {
        //Door A
        if (other.CompareTag("Player"))
        {
            textHelp.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                doorA.GetComponent<Animator>().Play("Door_F_5");
                openDoorSound.PlayOneShot(clipSoundDoor);
                cameraToolGo_A.SetActive(true);
                StartCoroutine(CameraFalse());
                buttonDown.GetComponent<ButtonMoveDownClicked>().enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            textHelp.SetActive(false);
        }
    }
    
    private IEnumerator CameraFalse()
    {
        yield return new WaitForSeconds(1f);
        cameraToolGo_A.SetActive(false);
        _triggerDoorA.enabled = false;
        objectCollider.enabled = false;
        textHelp.SetActive(false);
    }
}
