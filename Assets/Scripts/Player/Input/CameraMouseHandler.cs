using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraMouseHandler : MonoBehaviour
{
    [SerializeField] public CinemachineVirtualCamera vCam;
    private CinemachineTransposer transposer;
    public PlayerInputHandler inputHandler;
    private Vector3 cameraVelocity = Vector3.zero;
    [SerializeField] private float cameraPanMaxLength;
    [SerializeField] private float cameraPanSpeed;
    [SerializeField] private Vector3 defaultOffset;

    private void Start()
    {
        transposer = vCam.GetCinemachineComponent<CinemachineTransposer>();
    }

    public void AimAtMouse()
    {
        if (inputHandler.AimInput)
        {
            Vector3 targetOffset = inputHandler.AimDirectionInput * cameraPanMaxLength;
            targetOffset.z = transposer.m_FollowOffset.z;
            transposer.m_FollowOffset = Vector3.MoveTowards(transposer.m_FollowOffset, targetOffset, Time.deltaTime * cameraPanSpeed);
        }
        else
        {
            if (transposer.m_FollowOffset != defaultOffset)
            {
                transposer.m_FollowOffset = Vector3.MoveTowards(transposer.m_FollowOffset, defaultOffset, Time.deltaTime * cameraPanSpeed);
            }
        }
    }
}
