using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ApplicationManager : MonoBehaviour
{
    private void Awake()
    {
        Screen.fullScreen = true;
        Screen.SetResolution(Screen.currentResolution.height, Screen.currentResolution.width, true);
        Application.targetFrameRate = 60;
        Physics.gravity = new Vector3(0, -10, 0);
        
    }
    

}
