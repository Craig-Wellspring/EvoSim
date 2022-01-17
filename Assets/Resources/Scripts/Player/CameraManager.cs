using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraManager : MonoBehaviour
{
    CinemachineVirtualCamera pCam;

    void Start()
    {
        pCam = FindObjectOfType<CinemachineVirtualCamera>();
    }

    public void FocusCamera(Transform _target, float _fov = 60)
    {
        pCam.Follow = _target;
        pCam.LookAt = _target;
        pCam.m_Lens.FieldOfView = 20;
    }
}
