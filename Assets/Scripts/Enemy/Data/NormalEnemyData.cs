using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newNormalEnemyData", menuName = "Data/EnemyData/NormalEnemyData")]
public class NormalEnemyData : EnemyData
{
    [Header("Detection Variable")]
    [Header("Light Detection Variable")]
    [Range(0.0f, 360f)] [SerializeField] public float visionConeAngle;
    [Range(0.0f, 90f)] [SerializeField] public float visionConeTiltRange;
    [Range(0.0f, 1.0f)] [SerializeField] public float undetectionedLightExposureThreshold;
    [Range(0.0f, 1.0f)] [SerializeField] public float noLightExposureThreshold;
    [Range(0.0f, 1.0f)] [SerializeField] public float lowLightExposureThreshold;
    [Range(0.0f, 1.0f)] [SerializeField] public float highLightExposureThreshold;
    [SerializeField] public float noLightDetectionRange;
    [SerializeField] public float lowLightDetectionRange;
    [SerializeField] public float highLightDetectionRange;
    [SerializeField] public float lowLightCountTime;
    [SerializeField] public float highLightCountTime;

    [Header("Sound Detection Variable")]
    [SerializeField] public float lowVolumeSoundDetectionRange;
    [SerializeField] public float midVolumeSoundDetectionRange;
    [SerializeField] public float highVolumeSoundDetectionRange;
}
