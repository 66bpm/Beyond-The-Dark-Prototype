using UnityEngine;
/*

▒▒▒▒▒▒▒▒▒▄▄▄▄▒▄▄▄▒▒▒
▒▒▒▒▒▒▄▀▀▓▓▓▀█░░░█▒▒
▒▒▒▒▄▀▓▓▄██████▄░█▒▒
▒▒▒▄█▄█▀░░▄░▄░█▀▀▄▒▒
▒▒▄▀░██▄░░▀░▀░▀▄▓█▒▒
▒▒▀▄░░▀░▄█▄▄░░▄█▄▀▒▒
▒▒▒▒▀█▄▄░░▀▀▀█▀▓█▒▒▒
▒▒▒▄▀▓▓▓▀██▀▀█▄▀▒▒▒▒
▒▒█▓▓▄▀▀▀▄█▄▓▓▀█▒▒▒▒
▒▒▀▄█░░░░░█▀▀▄▄▀█▒▒▒
▒▒▒▄▀▀▄▄▄██▄▄█▀▓▓█▒▒
▒▒█▀▓█████████▓▓▓█▒▒
▒▒█▓▓██▀▀▀▒▒▒▀▄▄█▀▒▒
▒▒▒▀▀▒▒▒▒▒▒▒▒▒▒▒▒▒▒▒
*/

public class JumpOld : MonoBehaviour
{
    private PlayerStateOld ps;
    private PlayerControllerOld pc;
    private CollisionsOld coll;
    private DragManager dm;
    private Rigidbody2D rb;

    [Header("Jump Variables")]
    [SerializeField] private float jumpForce = 24f;

    // Coyoty Time
    [SerializeField] private float hangTime = 0.1f;
    [HideInInspector] public float hangTimeCounter;

    // Jump Buffer
    [SerializeField] private float jumpBufferLength = 0.1f;
    [HideInInspector] public float jumpBufferCounter;

    // Extra Jumps
    [SerializeField] private int extraJumps = 1;
    [HideInInspector] public int extraJumpsValue;

    // Wall Jump
    [SerializeField] private float wallJumpMovementLockDuration = 0.1f;

    [SerializeField] public float wallCorrectionDistance = 0.05f;


    private void Awake()
    {
        ps = GetComponent<PlayerStateOld>();
        pc = GetComponent<PlayerControllerOld>();
        coll = GetComponent<CollisionsOld>();
        dm = GetComponent<DragManager>();
        rb = GetComponent<Rigidbody2D>();
    }
    private void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            jumpBufferCounter = jumpBufferLength;
        }
        else
        {
            jumpBufferCounter -= Time.deltaTime;
        }
    }

    private void FixedUpdate()
    {
        if (coll.onGround && rb.velocity.y <=0 && !ps.isDroppingFromOnewayPlatform)
        {
            extraJumpsValue = extraJumps;
            hangTimeCounter = hangTime;
            ps.extraJumped = false;
        }
        else
        {
            hangTimeCounter -= Time.fixedDeltaTime;
            if (!coll.onWall || rb.velocity.y < 0f || ps.canWallClimb) ps.isJumping = false;
        }
        if (ps.canJump && ps.canControl)
        {
            ps.wallJumped = false;
            if (coll.onWall && !coll.onGround)
            {
                WallJump();
            }
            else DoJump(Vector2.up);
        }
        if (coll.canCornerCorrect) CornerCorrect(rb.velocity.y);
    }
    private void DoJump(Vector2 direction)
    {
        if ((!coll.onGround && !coll.onWall && hangTimeCounter <= 0) || ps.isDroppingFromOnewayPlatform)
        {
            extraJumpsValue--;
            ps.extraJumped = true;
        }

        dm.ApplyAirDrag();
        rb.velocity = new Vector2(rb.velocity.x, 0f);
        rb.AddForce(direction * jumpForce, ForceMode2D.Impulse);

        hangTimeCounter = 0f;
        jumpBufferCounter = 0f;
    }

    private void WallJump()
    {
        ps.wallJumped = true;
        Vector2 jumpDirection = coll.onRightWall ? Vector2.left : Vector2.right;
        StopCoroutine(pc.DisableMovement(0));
        StartCoroutine(pc.DisableMovement(wallJumpMovementLockDuration));
        DoJump(Vector2.up + jumpDirection);
    }

    private void CornerCorrect(float yVelocity)
    {
        RaycastHit2D leftHit = Physics2D.Raycast(transform.position - coll.innerRaycastOffset + Vector3.up * coll.topRaycastLength, Vector2.left, coll.topRaycastLength, coll.platformLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(transform.position + coll.innerRaycastOffset + Vector3.up * coll.topRaycastLength, Vector2.right, coll.topRaycastLength, coll.platformLayer);

        if (leftHit.collider != null)
        {
            float newPos = Vector3.Distance(new Vector3(leftHit.point.x, transform.position.y, 0f) + Vector3.up * coll.topRaycastLength, transform.position - coll.edgeRaycastOffset + Vector3.up * coll.topRaycastLength);
            transform.position = new Vector3(transform.position.x + newPos + wallCorrectionDistance, transform.position.y, transform.position.z);
            rb.velocity = new Vector2(rb.velocity.x, yVelocity);
            return;

        }
        if (rightHit.collider != null)
        {
            float newPos = Vector3.Distance(new Vector3(rightHit.point.x, transform.position.y, 0f) + Vector3.up * coll.topRaycastLength, transform.position + coll.edgeRaycastOffset + Vector3.up * coll.topRaycastLength);
            transform.position = new Vector3(transform.position.x - newPos - wallCorrectionDistance, transform.position.y, transform.position.z);
            rb.velocity = new Vector2(rb.velocity.x, yVelocity);
        }
    }
}
