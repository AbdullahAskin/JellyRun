using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using DG.Tweening;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public CinemachineVirtualCamera cineMachine;
    public Transform camTarget;

    public void SetLookAt(Transform targetLookAtTrans)
    {
        cineMachine.LookAt = targetLookAtTrans;
    }

    public void SetCameraParent(Transform parentTrans)
    {
        camTarget.SetParent(parentTrans, true);
    }
    
}