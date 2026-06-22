using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using VLB;

public class Trigger_CameraFalse : MonoBehaviour
{
    private static Trigger_CameraFalse _triggerCameraFalse;
    //sec Camera
    public GameObject camera1;
    public GameObject camera2;
    public GameObject camera3;
    //sec Camera Cone
    public GameObject camera_Cone1;
    public GameObject camera_Cone2;
    public GameObject camera_Cone3;
    //Camera Door Go
    public GameObject cameraToolGo_A;
    //Button Animation
    public GameObject buttonDown;

    public GameObject soundCameraErorr;

    public BoxCollider objectCollider;
    
    public GameObject textHelp;

    private void Awake()
    {
        _triggerCameraFalse = this;
    }

    private void OnTriggerStay(Collider other)
    {
        //Door E
        if (other.CompareTag("Player"))
        {
            textHelp.SetActive(true);
            if (Input.GetKeyDown(KeyCode.E))
            {
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
        soundCameraErorr.SetActive(true);
        camera1.GetComponent<Animator>().enabled = false;
        camera2.GetComponent<Animator>().enabled = false;
        camera3.GetComponent<Animator>().enabled = false;
        camera_Cone1.GetComponent<VolumetricLightBeam>().enabled = false;
        camera_Cone2.GetComponent<VolumetricLightBeam>().enabled = false;
        camera_Cone3.GetComponent<VolumetricLightBeam>().enabled = false;
        camera_Cone1.GetComponent<PlayerHitAndAlarm>().enabled = false;
        camera_Cone2.GetComponent<PlayerHitAndAlarm>().enabled = false;
        camera_Cone3.GetComponent<PlayerHitAndAlarm>().enabled = false;
        camera_Cone1.GetComponent<CapsuleCollider>().enabled = false;
        camera_Cone2.GetComponent<CapsuleCollider>().enabled = false;
        camera_Cone3.GetComponent<CapsuleCollider>().enabled = false;
        yield return new WaitForSeconds(1f);
        cameraToolGo_A.SetActive(false);
        _triggerCameraFalse.enabled = false;
        objectCollider.enabled = false;
        textHelp.SetActive(false);
    }
}
