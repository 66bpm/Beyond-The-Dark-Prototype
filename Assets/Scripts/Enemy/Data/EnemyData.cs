using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "newEnemyData", menuName = "Data/EnemyData/BaseData")]
public class EnemyData : ScriptableObject
{
    [Header("Combat Stat")]
    [SerializeField] public float maxHp = 3f;
    [SerializeField] public float attack = 1f;
    [SerializeField] public float attackDelay = 0.5f;
    [SerializeField] public float attackCooldown = 1f;

    [Header("Movement Variables")]
    [SerializeField] public float movementAcceleration = 70f;
    [SerializeField] public float maxMovementSpeed = 12f;
    [SerializeField] public float patrolSpeed = 8f;

    [Header("Linear Drag Variables")]
    [SerializeField] public float groundLinearDrag = 20f;
    [SerializeField] public float airLinearDrag = 2.5f;

    [Header("Gravity Variables")]
    [SerializeField] public float defaultMultiplier = 3f;
    [SerializeField] public float fallMultiplier = 10f;

    [Header("Jump Variables")]
    [SerializeField] public float jumpForce = 24f;

    
}
