using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartMenu : MonoBehaviour
{
    public GameObject panel;
    public GameObject tapToStartText;
    public GameObject handImage;
    public bool control;
    public static StartMenu startMenuSc;




    public void StartUp()
    {
        startMenuSc = GetComponent<StartMenu>();
        CameraManager.cameraManagerSc.vCameras[1].enabled = false;
        PlayerStartUp();
        OpponentStartUp();
        
        panel.SetActive(false);
        tapToStartText.SetActive(false);
        handImage.SetActive(false);
        StartCoroutine(Timer());
    }



    private IEnumerator Timer()
    {
        yield return new WaitForSeconds(2f);
        GameManager.state = GameManager.GameStates.Started;
    }
    private void PlayerStartUp()
    {
        AnimationController.animator.SetTrigger("runTrigger");
    }
    private void OpponentStartUp()
    {
        if (OpponentAnimationControl.girlAnimatorSc != null)
        {
            control = true;
        }
        
    }
}
