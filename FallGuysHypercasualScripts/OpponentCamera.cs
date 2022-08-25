using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class OpponentCamera : MonoBehaviour
{
    public Vector3 trackDistance;
    public CinemachineVirtualCamera virtualCam;
    public Transform AIPos;
    private void Start()
    {
        trackDistance = GameObject.FindGameObjectWithTag("CameraManager").transform.GetComponent<CameraManager>().distanceOffset;
        
    }
    private void LateUpdate()
    {
        virtualCam.transform.position = Vector3.Lerp(virtualCam.transform.position, AIPos.position+trackDistance, Time.deltaTime * 2f);
    }
    private void OnDisable()
    {
        this.virtualCam.enabled = false;
    }

}
