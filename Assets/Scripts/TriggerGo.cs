using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Video;

public class TriggerGo : MonoBehaviour
{
    public VideoPlayer video;


    private void Start()
    {
        video.loopPointReached += EndReached;
    }

    void EndReached(UnityEngine.Video.VideoPlayer vp)
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Game");
    }

    public void GoScene()
    {
        SceneManager.LoadScene("Game");
    }
}


