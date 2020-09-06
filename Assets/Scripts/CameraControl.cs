using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraControl : MonoBehaviour
{

    public int minOrthoSize;
    public int maxOrthoSize;

    public CinemachineVirtualCamera virtualCamera;

    public void UpdateFollowTarget(Transform target)
    {
        virtualCamera.Follow = target;
        virtualCamera.LookAt = target;
    }

    public void ZoomOut()
    {
        virtualCamera.m_Lens.OrthographicSize = maxOrthoSize;
    }

    public void ZoomIn()
    {
        virtualCamera.m_Lens.OrthographicSize = minOrthoSize;
    }

}
