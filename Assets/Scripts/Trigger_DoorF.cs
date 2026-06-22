using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trigger_DoorF : MonoBehaviour
{
    private static Trigger_DoorF _triggerDoorD;
    //Door
    public GameObject doorF;
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
                doorF.GetComponent<Animator>().Play("Door_D_5");
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
