using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName ="newPlayerData", menuName ="Data/PlayerData/BaseData")]
public class PlayerData : ScriptableObject
{
    [Header("Movement Variables")]
    [SerializeField] public float movementAcceleration = 70f;
    [SerializeField] public float maxMovementSpeed = 12f;

    [Header("Sneak Variables")]
    [SerializeField] public float sneakMaxMovementSpeed = 6f;

    [Header("Linear Drag Variables")]
    [SerializeField] public float groundLinearDrag = 20f;
    [SerializeField] public float airLinearDrag = 2.5f;

    [Header("Gravity Variables")]
    [SerializeField] public float defaultMultiplier = 3f;
    [SerializeField] public float fallMultiplier = 10f;
    [SerializeField] public float lowFallMultiplier = 7f;

    [Header("Land Variables")]
    [SerializeField] public float heightToForceLandAnimation = 6f;

    [Header("Jump Variables")]
    [SerializeField] public float jumpForce = 24f;
    // Coyoty Time
    [SerializeField] public float hangTime = 0.1f;
    // Extra Jumps
    [SerializeField] public int extreJumpAmount = 1;
    // Wall Jump
    [SerializeField] public float wallJumpMovementLockDuration = 0.1f;

    [Header("Wall Variables")]
    [SerializeField] public float wallSlideModifier = 0.5f;
    [SerializeField] public float wallClimbModifier = 0.8f;
    

    [SerializeField] public float wallCorrectionDistance = 0.05f;

    [Header("One-way Platform Variables")]
    [SerializeField] public float oneWayPlatformResetTime = 0.5f;

    [Header("Collision Detection Variables")]
    [Space]
    [Header("Layer Masks")]
    [SerializeField] public LayerMask platformLayer;
    [SerializeField] public LayerMask onewayPlatformLayer;
    [SerializeField] public LayerMask allLayers;

    // Offsets 
    [Space]
    [Header("Offsets")]
    [Header("Character Dimension")]
    [SerializeField] public Vector2 characterDimension;

    [Header("Ground")]
    [SerializeField] public Vector2 groundRaycastSize;
    [SerializeField] public float groundRaycastYOffset = 1f;

    // Jump Corner Correction
    [Header("Jump Corner Correction")]
    [SerializeField] public float topRaycastLength = 1.2f;
    [SerializeField] public Vector3 edgeRaycastOffset;
    [SerializeField] public Vector3 innerRaycastOffset;

    // Ceiling Head Bonk
    [Header("Ceiling Hit")]
    [SerializeField] public float ceilingRaycastLength = 1.2f;

    // Wall
    [Header("Wall")]
    [SerializeField] public Vector2 wallRaycastSize;
    [SerializeField] public float wallClimbRaycastYOffset;
    [SerializeField] public float wallMinimumAngle = 80f;

    // Ledge
    [Header("Ledge")]
    [SerializeField] public float ledgeRaycastYOffset;
    [SerializeField] public float wallLedgeRaycastYOffset;
    [SerializeField] public Vector2 wallLedgeRaycastSize;
    [SerializeField] public float ledgeRaycastLength;
}
