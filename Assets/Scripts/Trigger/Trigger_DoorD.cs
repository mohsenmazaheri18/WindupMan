using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_DoorD : MonoBehaviour
{
    private static Trigger_DoorD _triggerDoorD;
    //Door
    public GameObject doorD;
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
        _triggerDoorD = this;
    }

    private void OnTriggerStay(Collider other)
    {
        //Door D
        if (other.CompareTag("Player"))
        {
            textHelp.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
                doorD.GetComponent<Animator>().Play("Door_C_3");
                openDoorSound.PlayOneShot(clipSoundDoor);
                cameraToolGo_A.SetActive(true);
                StartCoroutine(CameraFalse());
                buttonDown.GetComponent<ButtonMoveDownClicked>().enabled = true;
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        //Door D
        if (other.CompareTag("Player"))
        {
            textHelp.SetActive(false);
        }
    }
    
    private IEnumerator CameraFalse()
    {
        yield return new WaitForSeconds(1f);
        cameraToolGo_A.SetActive(false);
        _triggerDoorD.enabled = false;
        objectCollider.enabled = false;
        textHelp.SetActive(false);
    }
}
