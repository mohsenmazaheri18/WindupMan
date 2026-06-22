using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoDown : MonoBehaviour
{
    public GameObject player;

    public GameObject cameraplayare;

    public GameObject cutplayer;

    public GameObject cutcamera;

    public int cut;
    
    // Start is called before the first frame update
    void Start()
    {
        cut = PlayerPrefs.GetInt("GameLose");
        if (cut == 1)
        {
            cutcamera.SetActive(false);
            cutplayer.SetActive(false);
            player.SetActive(true);
            cameraplayare.SetActive(true);
        }
    }
}
