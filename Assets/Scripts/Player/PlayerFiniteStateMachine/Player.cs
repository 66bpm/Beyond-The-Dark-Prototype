using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    #region State
    public PlayerStateMachine StateMachine { get; private set; }

    // Ground State
    public PlayerIdleState IdleState { get; private set; }
    public PlayerMoveState MoveState { get; private set; }
    public PlayerSneakState SneakState { get; private set; }
    public PlayerLandState LandState { get; private set; }

    // Jump State
    public PlayerJumpState JumpState { get; private set; }
    public PlayerWallJumpState WallJumpState { get; private set; }

    // Aired
    public PlayerAired AiredState { get; private set; }

    // Wall
    public PlayerWallClimbState WallClimbState { get; private set; }
    public PlayerWallSlideState WallSlideState { get; private set; }
    public PlayerWallHangState WallHangState { get; private set; }
    public PlayerLedgeClimbState LedgeClimbState { get; private set; }

    #endregion

    #region Unity Component
    public PlayerInputHandler InputHandler { get; private set; }
    [SerializeField] public Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Rigidbody2D RB { get; private set; }
    public CollisionDetection Collisions { get; private set; }
    public DragManager DragManager { get; private set; }
    public PlayerLightController PlayerLightController { get; private set; }
    public ActionSoundManager ActionSoundManager { get; private set; }

    [SerializeField] public PlayerData playerData;
    #endregion

    #region Gameplay Variable
    public Vector2 CurrentVelocity { get; private set; }
    public Vector3 CurrentPosition => transform.position;

    private Vector2 dirTemp;

    private Vector3 ledgeNewPosition;

    public GameObject ledgeTarget;
    public float ledgeDirection;

    public bool isFlipped;

    public bool isDroppingFromPlatform;
    public bool wallJumped;
    public bool extraJumped;
    public bool hardLanded;

    public float lightExposure;
    #endregion

    #region Unity Callback
    private void Awake()
    {
        StateMachine = new PlayerStateMachine();

        // Ground
        IdleState = new PlayerIdleState(this, StateMachine, playerData, "idle");
        MoveState = new PlayerMoveState(this, StateMachine, playerData, "move");
        SneakState = new PlayerSneakState(this, StateMachine, playerData, "sneak");
        LandState = new PlayerLandState(this, StateMachine, playerData, "land");

        // Jump
        JumpState = new PlayerJumpState(this, StateMachine, playerData, "jump");
        WallJumpState = new PlayerWallJumpState(this, StateMachine, playerData, "aired");

        // Aired
        AiredState = new PlayerAired(this, StateMachine, playerData, "aired");

        // Walled
        WallClimbState = new PlayerWallClimbState(this, StateMachine, playerData, "wallClimb");
        WallSlideState = new PlayerWallSlideState(this, StateMachine, playerData, "wallSlide");
        WallHangState = new PlayerWallHangState(this, StateMachine, playerData, "wallHang");
        LedgeClimbState = new PlayerLedgeClimbState(this, StateMachine, playerData, "ledgeClimb");
    }

    private void Start()
    {
        InputHandler = GetComponent<PlayerInputHandler>();
        RB = GetComponent<Rigidbody2D>();
        Collisions = GetComponent<CollisionDetection>();
        DragManager = GetComponent<DragManager>();
        PlayerLightController = GetComponent<PlayerLightController>();
        ActionSoundManager = GetComponent<ActionSoundManager>();

        isFlipped = false;
        StateMachine.Initialize(IdleState);
    }

    private void Update()
    {
        CurrentVelocity = RB.velocity;
        StateMachine.CurrentState.NormalUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion

    #region Ground Method
    public void DoMove(float xDir)
    {
        if (InputHandler.CanMove)
        {
            dirTemp.Set(xDir, 0f);
            RB.AddForce(dirTemp * playerData.movementAcceleration);
            if (Mathf.Abs(CurrentVelocity.x) > playerData.maxMovementSpeed)
            {
                RB.velocity = new Vector2(Mathf.Sign(CurrentVelocity.x) * playerData.maxMovementSpeed, CurrentVelocity.y);
            }
        }
        else
        {
            dirTemp.Set(InputHandler.MovementInput.x * playerData.maxMovementSpeed, CurrentVelocity.y);
            RB.velocity = Vector2.Lerp(CurrentVelocity, dirTemp, .5f * Time.fixedDeltaTime);
        }
    }

    public void DoSneak(float xDir)
    {
        dirTemp.Set(xDir, 0f);
        RB.velocity = dirTemp * playerData.sneakMaxMovementSpeed;
    }
    #endregion

    #region Jump Method
    public IEnumerator DoJumping(Vector2 dir)
    {
        yield return new WaitForFixedUpdate();
        DragManager.ApplyAirDrag();
        RB.AddForce(dir, ForceMode2D.Impulse);
    }
    public void DoJump(Vector2 dir)
    {
        
        dirTemp.Set(CurrentVelocity.x, 0f);
        RB.velocity = dirTemp;
        
        StartCoroutine(DoJumping(dir * playerData.jumpForce));
    }

    public void DoWallJump()
    {
        wallJumped = true;
        Vector2 jumpDirection = Collisions.onRightWall ? Vector2.left : Vector2.right;;
        StopCoroutine(InputHandler.DisableMovement(0));
        StartCoroutine(InputHandler.DisableMovement(playerData.wallJumpMovementLockDuration));
        DoJump(Vector2.up + jumpDirection);
    }
    #endregion

    #region Wall Methods
    public void DoWallClimb()
    {
        dirTemp.Set(InputHandler.MovementInput.normalized.x * 0.1f, InputHandler.MovementInput.y * playerData.maxMovementSpeed * playerData.wallClimbModifier);
        RB.velocity = dirTemp;
    }

    public void DoWallSlide()
    {
        dirTemp.Set(InputHandler.MovementInput.normalized.x * 0.1f, playerData.maxMovementSpeed * playerData.wallSlideModifier * -1f);
        RB.velocity = dirTemp;
    }

    public void StartLedgeClimb()
    {
        dirTemp.Set(0, 0);
        RB.velocity = dirTemp;
        InputHandler.CanControl = false;

        RB.isKinematic = true;

        Vector3 platformPosition = ledgeTarget.transform.position;
        Vector3 p1 = ledgeTarget.transform.TransformPoint(0, 0, 0);
        Vector3 p2 = ledgeTarget.transform.TransformPoint(1, 1, 0);
        float w = p2.x - p1.x;
        float h = p2.y - p1.y;

        if (ledgeDirection > 0f)
        {
            if (isFlipped) Flip();
            transform.position = new Vector3(platformPosition.x - w / 2 - playerData.characterDimension.x / 2 - 0.05f, platformPosition.y + h / 2 - playerData.characterDimension.y / 2 + 0.05f, 0f);
            ledgeNewPosition = CurrentPosition + new Vector3(playerData.characterDimension.x, playerData.characterDimension.y, 0f);
            ActionSoundManager.SpawnActionSound(playerData.lowVolumeSoundRadius, playerData.lowVolumeSoundAnimationDecayTime, CurrentPosition, ActionSoundManager.TopSoundPosition + Vector3.right * playerData.characterDimension.y / 2);
        }
        else if (ledgeDirection < 0f)
        {
            if (!isFlipped) Flip();
            transform.position = new Vector3(platformPosition.x + w / 2 + playerData.characterDimension.x / 2 + 0.05f, platformPosition.y + h / 2 - playerData.characterDimension.y / 2 + 0.05f, 0f);
            ledgeNewPosition = CurrentPosition + new Vector3(-playerData.characterDimension.x, playerData.characterDimension.y, 0f);
            ActionSoundManager.SpawnActionSound(playerData.lowVolumeSoundRadius, playerData.lowVolumeSoundAnimationDecayTime, CurrentPosition, ActionSoundManager.TopSoundPosition + Vector3.left * playerData.characterDimension.y / 2);
        }
    }

    public void CompleteLedgeClimb()
    {
        transform.position = ledgeNewPosition;
        RB.isKinematic = false;
        InputHandler.CanControl = true;
        ActionSoundManager.SpawnActionSound(playerData.lowVolumeSoundRadius, playerData.lowVolumeSoundAnimationDecayTime, CurrentPosition, ActionSoundManager.BottomSoundPosition);
    }
    #endregion

    #region Attack Methods
    public void DoAttack(Vector2 dir)
    {
        dirTemp.Set(dir.x * playerData.characterDimension.x / 2, dir.y * playerData.characterDimension.y / 2);
        float boxAngle;
        if (dir == Vector2.right || dir == Vector2.left) boxAngle = 0f;
        else boxAngle = 90f;

        RaycastHit2D hits = Physics2D.BoxCast(CurrentPosition + (Vector3)dirTemp, playerData.attackBox, boxAngle, dir, playerData.enemyLayer);
    }
    #endregion

    #region Others
    public void Flip()
    {
        PlayerLightController.Flip();
        isFlipped = !isFlipped;
        spriteRenderer.flipX = isFlipped;
    }

    private void AnimationTrigger() => StateMachine.CurrentState.AnimationTrigger();
    private void AnimationFinishTrigger() => StateMachine.CurrentState.AnimationFinishTrigger();
    #endregion

    #region Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Ground
        Gizmos.DrawWireCube(CurrentPosition + Vector3.down * playerData.groundRaycastYOffset, new Vector3(playerData.groundRaycastSize.x, playerData.groundRaycastSize.y, 0f));

        // Corner Correct
        // Character Edge
        Gizmos.DrawLine(CurrentPosition + playerData.edgeRaycastOffset, CurrentPosition + playerData.edgeRaycastOffset + Vector3.up * playerData.topRaycastLength);
        Gizmos.DrawLine(CurrentPosition - playerData.edgeRaycastOffset, CurrentPosition - playerData.edgeRaycastOffset + Vector3.up * playerData.topRaycastLength);
        // Inner Head Bang
        Gizmos.DrawLine(CurrentPosition + playerData.innerRaycastOffset, CurrentPosition + playerData.innerRaycastOffset + Vector3.up * playerData.topRaycastLength);
        Gizmos.DrawLine(CurrentPosition - playerData.innerRaycastOffset, CurrentPosition - playerData.innerRaycastOffset + Vector3.up * playerData.topRaycastLength);
        // To Check Corner Correct Distance
        Gizmos.DrawLine(CurrentPosition - playerData.innerRaycastOffset + Vector3.up * playerData.topRaycastLength, CurrentPosition - playerData.innerRaycastOffset + Vector3.up * playerData.topRaycastLength + Vector3.left * playerData.topRaycastLength);
        Gizmos.DrawLine(CurrentPosition + playerData.innerRaycastOffset + Vector3.up * playerData.topRaycastLength, CurrentPosition + playerData.innerRaycastOffset + Vector3.up * playerData.topRaycastLength + Vector3.right * playerData.topRaycastLength);

        Gizmos.color = Color.green;

        // Wall
        Gizmos.DrawWireCube(CurrentPosition + new Vector3(playerData.characterDimension.x / 2 + playerData.wallRaycastSize.x / 2, 0f, 0f), new Vector3(playerData.wallRaycastSize.x, playerData.wallRaycastSize.y, 0f));
        Gizmos.DrawWireCube(CurrentPosition - new Vector3(playerData.characterDimension.x / 2 + playerData.wallRaycastSize.x / 2, 0f, 0f), new Vector3(playerData.wallRaycastSize.x, playerData.wallRaycastSize.y, 0f));
        Gizmos.DrawLine(CurrentPosition + new Vector3(playerData.characterDimension.x / 2 * -1f, playerData.wallClimbRaycastYOffset, 0f), CurrentPosition + new Vector3(playerData.characterDimension.x / 2 * -1f, playerData.wallClimbRaycastYOffset, 0f) + Vector3.left * playerData.wallRaycastSize.x);
        Gizmos.DrawLine(CurrentPosition + new Vector3(playerData.characterDimension.x / 2, playerData.wallClimbRaycastYOffset, 0f), CurrentPosition + new Vector3(playerData.characterDimension.x / 2, playerData.wallClimbRaycastYOffset, 0f) + Vector3.right * playerData.wallRaycastSize.x);

        Gizmos.color = Color.blue;

        // Ledge
        Gizmos.DrawLine(CurrentPosition + Vector3.up * playerData.characterDimension.y / 2, CurrentPosition + Vector3.up * playerData.characterDimension.y * 1.5f);
        Gizmos.DrawLine(CurrentPosition + Vector3.up * playerData.ledgeRaycastYOffset, CurrentPosition + Vector3.up * playerData.ledgeRaycastYOffset + Vector3.right * playerData.ledgeRaycastLength);
        Gizmos.DrawLine(CurrentPosition + Vector3.up * playerData.ledgeRaycastYOffset, CurrentPosition + Vector3.up * playerData.ledgeRaycastYOffset + Vector3.left * playerData.ledgeRaycastLength);
        Gizmos.DrawLine(CurrentPosition + Vector3.up * playerData.ledgeRaycastYOffset + Vector3.left * playerData.characterDimension.x * 0.4f, CurrentPosition + Vector3.up * playerData.ledgeRaycastYOffset + Vector3.right * playerData.characterDimension.x * 0.4f);
        Gizmos.DrawWireCube(CurrentPosition + new Vector3(playerData.characterDimension.x / 2 + playerData.wallLedgeRaycastSize.x / 2, playerData.wallLedgeRaycastYOffset, 0f), new Vector3(playerData.wallLedgeRaycastSize.x, playerData.wallLedgeRaycastSize.y, 0f));
        Gizmos.DrawWireCube(CurrentPosition + new Vector3((playerData.characterDimension.x / 2 + playerData.wallLedgeRaycastSize.x / 2) * -1, playerData.wallLedgeRaycastYOffset, 0f), new Vector3(playerData.wallLedgeRaycastSize.x, playerData.wallLedgeRaycastSize.y, 0f));
        Gizmos.DrawWireCube(CurrentPosition + Vector3.up * playerData.wallLedgeRaycastYOffset, new Vector3(playerData.characterDimension.x * 0.8f, playerData.wallLedgeRaycastSize.y, 0f));

        Gizmos.color = Color.yellow;

        // Head Bonk
        Gizmos.DrawLine(CurrentPosition, CurrentPosition + Vector3.up * playerData.ceilingRaycastLength);
    }
    #endregion
}
