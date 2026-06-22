using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonMoveDownClicked : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        transform.Translate(0, -0.25f, 0);
    }
}
