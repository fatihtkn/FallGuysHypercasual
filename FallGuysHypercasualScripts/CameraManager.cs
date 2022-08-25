using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
public class CameraManager : MonoBehaviour
{
    public CinemachineVirtualCamera[] vCameras;
    public static CameraManager cameraManagerSc;
    [SerializeField] private Transform playerPos;
    public Vector3 distanceOffset;
    public float cameraTrackSpeed;
    private void Start()
    {
        cameraManagerSc = GetComponent<CameraManager>();
    }


    private void LateUpdate()
    {
        CameraTrack();
    }


    public void CameraTrack()
    {
        if (GameManager.state == GameManager.GameStates.Started)
        {
            if (vCameras != null)
            {
                vCameras[0].transform.position = Vector3.Lerp(vCameras[0].transform.position, playerPos.position + distanceOffset, Time.deltaTime * cameraTrackSpeed);
            }
            

        }
        else if (GameManager.state == GameManager.GameStates.WallPainting)
        {
            if (vCameras[2] != null)
            vCameras[2].enabled = true;
        }
    }
}
