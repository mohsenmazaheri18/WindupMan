using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuScripts : MonoBehaviour
{
    public void GoScene()
    {
        SceneManager.LoadScene("CutScene");
    }
    public void QuitApp()
    {
        Application.Quit();
    }
}
