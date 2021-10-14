using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newBlindEnemyData", menuName = "Data/EnemyData/BlindEnemyData")]
public class BlindEnemyData : EnemyData
{
    [Header("Sound Detection Variable")]
    [SerializeField] public float lowVolumeSoundDetectionRange;
    [SerializeField] public float midVolumeSoundDetectionRange;
    [SerializeField] public float highVolumeSoundDetectionRange;
}
