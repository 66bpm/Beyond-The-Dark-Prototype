using UnityEngine;
/*
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠟⠋⠉⠉⠛⠻⢿⣿⠿⠛⠋⠁⠈⠙
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⢿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠁⠴⣿⠟⠉⠀⠀⠈⡀⠀⠀⠀⠀⠀⠀
⣿⣿⣿⣿⣿⣿⣿⣿⣿⣿⡿⠋⠀⣾⣿⣿⣿⣿⣿⠿⠿⠿⠛⠛⠉⠉⠀⠀⠀⠀⠀⠀⠀⠉⢁⠀⠀⠈⠀⠀⠀⠀⢀⡇⠀⠀⠀⠀⠀⠀
⣿⣿⣿⣿⣿⣿⣿⣿⣿⡏⠀⠀⣀⣿⠿⠛⠉⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢠⡀⠀⠀⠀⢀⣠⣾⣿⠀⠀⠐⢦⡀⠀
⣿⣿⣿⣿⣿⣿⣿⣿⣿⡀⣠⡾⠋⠁⠀⠀⠀⠀⠀⠀⠀⠀⣤⣤⣄⣀⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠻⠿⠿⠟⠛⠋⢷⣄⠀⠀⠹⣦
⣿⣿⣿⣿⣿⣿⣿⣿⣿⠟⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡟⠛⠛⠛⠛⠯⠶⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣷⣤⡀⠘
⣿⣿⣿⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠉⠑⠢⣀⠈⠢⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠙⣿⣿⣷
⣿⣿⣿⣿⣿⣿⠏⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢰⠀⠀⡇⠀⠀⠀⣀⠄⠒⠀⠀⠀⠀⠀⠑⠢⡙⡳⣄⠀⠀⠀⠈⠀⠀⠀⠀⠈⠻⣿
⣿⣿⣿⣿⡿⠃⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⡆⠀⠃⢀⡴⠚⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠱⠈⠳⡄⠀⠀⠀⢂⠀⠀⠀⠀⠘
⣿⣿⣿⡿⠁⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⣾⡀⢐⠉⠀⠀⠀⠀⠀⠀⠀⠀⠀⢀⣀⣀⣴⡀⠁⠀⠙⢦⠀⠀⠈⣧⡀⠀⠀⠀
⣿⣿⣿⠃⠀⠀⠀⡇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⡏⠳⡈⡀⠀⠀⠀⠀⠀⢀⣤⣶⣿⡿⠿⠽⠿⠿⣿⣷⣶⣌⡳⡀⠀⢹⣷⡄⠀⠀
⣿⡟⠁⠀⠀⠀⠀⣷⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢸⠀⠑⢥⠀⠀⡾⠋⣰⡿⡟⠊⠀⠚⣿⣿⣿⣶⣄⠀⠉⢹⠀⢳⠀⢸⣿⣿⡄⠀
⣿⠇⠀⠀⠀⠀⠀⢹⣇⠀⠀⠀⠂⠀⠀⠀⠀⠀⠀⠀⠘⡄⠀⠈⠀⠈⠀⠰⢻⠋⠀⣀⣀⣠⣿⣿⣿⣿⣿⣇⠀⠈⠀⠀⢃⢘⡏⢿⣿⡄
⡿⠀⠀⠀⠀⠀⠀⣿⠈⠣⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢃⠀⠀⠀⠀⠀⠀⠋⠀⠀⢿⣿⣿⣿⣿⣿⡿⠟⠁⠀⠀⠀⠀⠘⣼⡇⠈⢿⣿
⡇⠀⠀⠀⠀⡆⠀⣿⠀⠀⡨⠂⠄⡀⠀⠀⠀⠠⣀⠀⠀⠘⡄⠀⠀⠀⠀⠀⠀⠀⠀⠈⠙⠻⠿⠛⠁⠀⠀⠀⠀⠀⠀⠀⠀⣿⠀⠀⠈⣿
⡇⠀⠀⠀⠀⠀⠀⢸⠀⣐⠊⠀⠀⠀⢉⠶⠶⢂⠈⠙⠒⠂⠠⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠇⠀⠀⠀⠸
⠀⣀⠂⢣⡀⠀⠀⠘⣠⠃⠀⠀⠀⠀⣠⣴⣾⠷⠤⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⡀⡙⠀⠈⢧⠀⠡⡀⢉⠀⠀⠀⠀⣴⣿⡫⣋⣥⣤⣀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⡗⠃⠐⠀⠈⣷⡀⢳⡄⠂⠀⠀⣸⣿⡛⠑⠛⢿⣿⣿⣷⡄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⡇⡀⠂⡀⠀⣸⢱⡈⠇⠐⠄⡠⣿⡟⠁⠀⠀⣸⣿⣿⣿⡟⠀⠀⠀⠀⠈⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣿⡐⡀⠀⢠⠏⠀⢳⡘⡄⠈⠀⢿⡿⠀⢻⣿⣿⣿⡿⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣿⣧⠐⢀⡏⠀⠀⠀⢳⡴⡀⠀⢸⣿⡄⠀⠉⠛⠋⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣶⣶⣶⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣿⣿⣆⠀⠐⡀⠀⠀⠀⢻⣷⡀⠀⠃⠙⠂⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⢿⣿⣿⣿⣄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀
⣿⣿⣿⣆⠀⠙⣄⠀⠀⠀⠱⣕⠄⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠻⣿⣿⣿⣦⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣴
⣿⣿⣿⣿⣧⡀⠘⢦⡀⠀⠀⠈⢢⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠘⠿⣿⣿⣇⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⣠⣾⣿
⣿⣿⣿⣿⣿⣷⢄⠈⠻⣆⠀⠀⠀⠑⢄⡀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠀⠈⠛⠿⠀⠀⠀⠀⠀⠀⠀⠀⢀⣴⣾⣿⣿⣿
 */

public class CollisionsOld : MonoBehaviour
{

    // Booleans
    [Space]
    [Header("Collision Booleans")]
    public bool onGround;

    public bool canCornerCorrect;

    public bool hitCeiling;

    public bool onWall;
    public bool onLeftWall;
    public bool onRightWall;
    public bool onWallClimbCheck;
    public bool onLeftWallClimbCheck;
    public bool onRightWallClimbCheck;

    public bool isHighEnoughToClimbLedge;

    public GameObject leftNormalLedgeTarget;
    public GameObject rightNormalLedgeTarget;
    public GameObject leftOnewayLedgeTarget;
    public GameObject rightOnewayLedgeTarget;
    public GameObject middleOnewayLedgeTarget;

    public bool onWallLedge;
    public bool onRightWallLedge;

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

    // Update is called once per frame
    private void FixedUpdate()
    {
        CheckGround();
        CheckWall();
        CheckJumpCornerCorrection();
        CheckCeilingHit();
        CheckLedgeTargets();
        CheckLedgeClimb();
    }

    private void CheckGround()
    {
        onGround = Physics2D.BoxCast(transform.position + Vector3.down*groundRaycastYOffset, groundRaycastSize, 0f, Vector2.down, 0f, allLayers);
    }

    private void CheckJumpCornerCorrection()
    {
        canCornerCorrect = (Physics2D.Raycast(transform.position + edgeRaycastOffset, Vector2.up, topRaycastLength, platformLayer) && !Physics2D.Raycast(transform.position + innerRaycastOffset, Vector2.up, topRaycastLength, platformLayer)) ^ (Physics2D.Raycast(transform.position - edgeRaycastOffset, Vector2.up, topRaycastLength, platformLayer) && !Physics2D.Raycast(transform.position - innerRaycastOffset, Vector2.up, topRaycastLength, platformLayer));
    }

    private void CheckWall()
    {
        RaycastHit2D[] leftHits = Physics2D.BoxCastAll(transform.position - new Vector3(characterDimension.x / 2 + wallRaycastSize.x / 2, 0f, 0f), wallRaycastSize, 0f, Vector2.left, 0f, platformLayer);
        RaycastHit2D[] rightHits = Physics2D.BoxCastAll(transform.position + new Vector3(characterDimension.x / 2 + wallRaycastSize.x / 2, 0f, 0f), wallRaycastSize, 0f, Vector2.right, 0f, platformLayer);
        onLeftWall = false;
        onRightWall = false;
        if (leftHits != null)
        {
            for (int i = 0; i < leftHits.Length; i++)
            {
                if (leftHits[i].collider != null)
                {
                    if (leftHits[i].collider.gameObject.CompareTag("Platform"))
                    {
                        if (Vector2.Angle(leftHits[i].normal, Vector2.up) > wallMinimumAngle) onLeftWall = true; ;
                    }
                }
            }
        }
        if (rightHits != null)
        {
            for (int i = 0; i < rightHits.Length; i++)
            {
                if (rightHits[i].collider != null)
                {
                    if (rightHits[i].collider.gameObject.CompareTag("Platform"))
                    {
                        if (Vector2.Angle(rightHits[i].normal, Vector2.up) > wallMinimumAngle) onRightWall = true;
                    }
                }
            }
        }

        // No longer used since it was change to BoxCastAll
        // bool onLeftWall = Physics2D.BoxCast(transform.position - new Vector3(characterDimension.x / 2 + wallRaycastSize.x / 2, 0f, 0f), wallRaycastSize, 0f, Vector2.left, 0f, groundLayer);
        // onRightWall = Physics2D.BoxCast(transform.position + new Vector3(characterDimension.x / 2 + wallRaycastSize.x / 2, 0f, 0f), wallRaycastSize, 0f, Vector2.right, 0f, groundLayer);

        onWall = onRightWall || onLeftWall;


        // Another Raycasts to check if it's higher than half of player size (for wall climbing so the character doesn't climb a small tile)
        onLeftWallClimbCheck = Physics2D.Raycast(transform.position + new Vector3(characterDimension.x / 2 * -1f, wallClimbRaycastYOffset, 0f), Vector2.left, wallRaycastSize.x, platformLayer);
        onRightWallClimbCheck = Physics2D.Raycast(transform.position + new Vector3(characterDimension.x / 2, wallClimbRaycastYOffset, 0f), Vector2.right, wallRaycastSize.x, platformLayer);
        onWallClimbCheck = onLeftWallClimbCheck || onRightWallClimbCheck;
    }

    private void CheckCeilingHit()
    {
        hitCeiling = Physics2D.Raycast(transform.position, Vector2.up, ceilingRaycastLength, platformLayer);
    }
    private void CheckLedgeTargets()
    {
        RaycastHit2D leftNormalHit = Physics2D.BoxCast(transform.position + new Vector3((characterDimension.x / 2 + wallLedgeRaycastSize.x / 2) * -1, wallLedgeRaycastYOffset, 0f), wallLedgeRaycastSize, 0f, Vector2.left, 0f, platformLayer);
        RaycastHit2D rightNormalHit = Physics2D.BoxCast(transform.position + new Vector3(characterDimension.x / 2 + wallLedgeRaycastSize.x / 2, wallLedgeRaycastYOffset, 0f), wallLedgeRaycastSize, 0f, Vector2.right, 0f, platformLayer);
        RaycastHit2D leftOnewayHit = Physics2D.BoxCast(transform.position + new Vector3((characterDimension.x / 2 + wallLedgeRaycastSize.x / 2) * -1, wallLedgeRaycastYOffset, 0f), wallLedgeRaycastSize, 0f, Vector2.left, 0f, onewayPlatformLayer);
        RaycastHit2D rightOnewayHit = Physics2D.BoxCast(transform.position + new Vector3(characterDimension.x / 2 + wallLedgeRaycastSize.x / 2, wallLedgeRaycastYOffset, 0f), wallLedgeRaycastSize, 0f, Vector2.right, 0f, onewayPlatformLayer);
        RaycastHit2D middleOnewayHit = Physics2D.BoxCast(transform.position + new Vector3(0f, wallLedgeRaycastYOffset, 0f), new Vector2(characterDimension.x * 0.8f,wallLedgeRaycastSize.y), 0f, Vector2.up, 0f, onewayPlatformLayer);

        bool leftNormalLedgeCheck = onLeftWall && (leftNormalHit.collider != null) && !Physics2D.Raycast(transform.position + Vector3.up * ledgeRaycastYOffset, Vector2.left, ledgeRaycastLength, platformLayer);
        bool rightNormalLedgeCheck = onRightWall && (rightNormalHit.collider != null) && !Physics2D.Raycast(transform.position + Vector3.up * ledgeRaycastYOffset, Vector2.right, ledgeRaycastLength, platformLayer);
        bool leftOnewayLedgeCheck = (leftOnewayHit.collider != null) && !Physics2D.Raycast(transform.position + Vector3.up * ledgeRaycastYOffset, Vector2.left, ledgeRaycastLength, onewayPlatformLayer);
        bool rightOnewayLedgeCheck = (rightOnewayHit.collider != null) && !Physics2D.Raycast(transform.position + Vector3.up * ledgeRaycastYOffset, Vector2.right, ledgeRaycastLength, onewayPlatformLayer);
        bool middleOnewayLedgeCheck = (middleOnewayHit.collider != null) && !Physics2D.Raycast(transform.position + Vector3.up * ledgeRaycastYOffset + Vector3.left * characterDimension.x *0.4f, Vector2.right, characterDimension.x *0.8f, onewayPlatformLayer);

        if (leftNormalLedgeCheck) leftNormalLedgeTarget = leftNormalHit.collider.gameObject;
        else leftNormalLedgeTarget = null;
        if (rightNormalLedgeCheck) rightNormalLedgeTarget = rightNormalHit.collider.gameObject;
        else rightNormalLedgeTarget = null;
        if (leftOnewayLedgeCheck) leftOnewayLedgeTarget = leftOnewayHit.collider.gameObject;
        else leftOnewayLedgeTarget = null;
        if (rightOnewayLedgeCheck) rightOnewayLedgeTarget = rightOnewayHit.collider.gameObject;
        else rightOnewayLedgeTarget = null;
        if (middleOnewayLedgeCheck) middleOnewayLedgeTarget = middleOnewayHit.collider.gameObject;
        else middleOnewayLedgeTarget = null;
    }
    private void CheckLedgeClimb()
    {
        
        RaycastHit2D[] ceilingHits = Physics2D.RaycastAll(transform.position, Vector2.up, characterDimension.y * 1.5f, platformLayer);
        isHighEnoughToClimbLedge = true;
        if (ceilingHits != null)
        {
            for (int i =0; i < ceilingHits.Length; i++)
            {
                if (ceilingHits[i].collider != null)
                {
                    if (ceilingHits[i].collider.CompareTag("Platform")) isHighEnoughToClimbLedge = false;
                    else isHighEnoughToClimbLedge = true;
                }
            }
        }
        /*
        onRightWallLedge = Physics2D.BoxCast(transform.position + new Vector3(characterDimension.x / 2 + wallLedgeRaycastSize.x / 2, wallLedgeRaycastYOffset, 0f), wallLedgeRaycastSize, 0f, Vector2.right, 0f, platformLayer);
        bool onLeftWallLedge = Physics2D.BoxCast(transform.position + new Vector3((characterDimension.x / 2 + wallLedgeRaycastSize.x / 2) * -1, wallLedgeRaycastYOffset, 0f), wallLedgeRaycastSize, 0f, Vector2.left, 0f, platformLayer);
        onWallLedge = onRightWallLedge || onLeftWallLedge;
        onRightLedge = onRightWall && onRightWallLedge && !Physics2D.Raycast(transform.position + Vector3.up * ledgeRaycastYOffset, Vector2.right, ledgeRaycastLength, platformLayer);
        onLeftLedge = onLeftWall && onLeftWallLedge && !Physics2D.Raycast(transform.position + Vector3.up * ledgeRaycastYOffset, Vector2.left, ledgeRaycastLength, platformLayer);
        onLedge = (onRightLedge || onLeftLedge);
        */
    }

    public Vector2 GetCharacterDimension()
    {
        return characterDimension; 
    }

    // Gizmos
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;

        // Ground
        Gizmos.DrawWireCube(transform.position + Vector3.down*groundRaycastYOffset, new Vector3(groundRaycastSize.x, groundRaycastSize.y, 0f));

        // Corner Correct
        // Character Edge
        Gizmos.DrawLine(transform.position + edgeRaycastOffset, transform.position + edgeRaycastOffset + Vector3.up * topRaycastLength);
        Gizmos.DrawLine(transform.position - edgeRaycastOffset, transform.position - edgeRaycastOffset + Vector3.up * topRaycastLength);
        // Inner Head Bang
        Gizmos.DrawLine(transform.position + innerRaycastOffset, transform.position + innerRaycastOffset + Vector3.up * topRaycastLength);
        Gizmos.DrawLine(transform.position - innerRaycastOffset, transform.position - innerRaycastOffset + Vector3.up * topRaycastLength);
        // To Check Corner Correct Distance
        Gizmos.DrawLine(transform.position - innerRaycastOffset + Vector3.up * topRaycastLength, transform.position - innerRaycastOffset + Vector3.up * topRaycastLength + Vector3.left * topRaycastLength);
        Gizmos.DrawLine(transform.position + innerRaycastOffset + Vector3.up * topRaycastLength, transform.position + innerRaycastOffset + Vector3.up * topRaycastLength + Vector3.right * topRaycastLength);

        Gizmos.color = Color.green;

        // Wall
        Gizmos.DrawWireCube(transform.position + new Vector3(characterDimension.x / 2 + wallRaycastSize.x / 2, 0f, 0f), new Vector3(wallRaycastSize.x, wallRaycastSize.y, 0f));
        Gizmos.DrawWireCube(transform.position - new Vector3(characterDimension.x / 2 + wallRaycastSize.x / 2, 0f, 0f), new Vector3(wallRaycastSize.x, wallRaycastSize.y, 0f));
        Gizmos.DrawLine(transform.position + new Vector3(characterDimension.x / 2 * -1f, wallClimbRaycastYOffset, 0f), transform.position + new Vector3(characterDimension.x / 2 * -1f, wallClimbRaycastYOffset, 0f) + Vector3.left * wallRaycastSize.x);
        Gizmos.DrawLine(transform.position + new Vector3(characterDimension.x / 2, wallClimbRaycastYOffset, 0f), transform.position + new Vector3(characterDimension.x / 2, wallClimbRaycastYOffset, 0f) + Vector3.right * wallRaycastSize.x);

        Gizmos.color = Color.blue;

        // Ledge
        Gizmos.DrawLine(transform.position + Vector3.up * characterDimension.y/2, transform.position + Vector3.up * characterDimension.y * 1.5f);
        Gizmos.DrawLine(transform.position + Vector3.up * ledgeRaycastYOffset, transform.position + Vector3.up * ledgeRaycastYOffset + Vector3.right * ledgeRaycastLength);
        Gizmos.DrawLine(transform.position + Vector3.up * ledgeRaycastYOffset, transform.position + Vector3.up * ledgeRaycastYOffset + Vector3.left * ledgeRaycastLength);
        Gizmos.DrawLine(transform.position + Vector3.up * ledgeRaycastYOffset + Vector3.left * characterDimension.x * 0.4f, transform.position + Vector3.up * ledgeRaycastYOffset + Vector3.right * characterDimension.x * 0.4f);
        Gizmos.DrawWireCube(transform.position + new Vector3(characterDimension.x / 2 + wallLedgeRaycastSize.x / 2, wallLedgeRaycastYOffset, 0f), new Vector3(wallLedgeRaycastSize.x, wallLedgeRaycastSize.y, 0f));
        Gizmos.DrawWireCube(transform.position + new Vector3((characterDimension.x / 2 + wallLedgeRaycastSize.x / 2) * -1, wallLedgeRaycastYOffset, 0f), new Vector3(wallLedgeRaycastSize.x, wallLedgeRaycastSize.y, 0f));
        Gizmos.DrawWireCube(transform.position + Vector3.up * wallLedgeRaycastYOffset, new Vector3(characterDimension.x * 0.8f, wallLedgeRaycastSize.y, 0f));

        Gizmos.color = Color.yellow;

        // Head Bonk
        Gizmos.DrawLine(transform.position, transform.position + Vector3.up * ceilingRaycastLength);
    }
}
