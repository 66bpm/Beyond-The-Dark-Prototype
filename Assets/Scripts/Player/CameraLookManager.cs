using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CameraLookManager : MonoBehaviour
{
    private CinemachineInputProvider inputProvider;
    private CinemachineVirtualCamera vCam;
    [SerializeField] private PlayerInputHandler inputHandler;
    [SerializeField] private float cameraPanMaxLength;
    [SerializeField] private float cameraPanSpeed;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
