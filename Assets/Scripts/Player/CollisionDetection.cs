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

public class CollisionDetection : MonoBehaviour
{
    private Player player;

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
    public bool onWallLedge;
    public bool onRightWallLedge;

    public GameObject leftNormalLedgeTarget;
    public GameObject rightNormalLedgeTarget;
    public GameObject leftOnewayLedgeTarget;
    public GameObject rightOnewayLedgeTarget;
    public GameObject middleOnewayLedgeTarget;

    private void Start()
    {
        player = GetComponent<Player>();
    }

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
        onGround = Physics2D.BoxCast(player.CurrentPosition + Vector3.down * player.playerData.groundRaycastYOffset, player.playerData.groundRaycastSize, 0f, Vector2.down, 0f, player.playerData.allLayers);
    }

    private void CheckJumpCornerCorrection()
    {
        canCornerCorrect = (Physics2D.Raycast(player.CurrentPosition + player.playerData.edgeRaycastOffset, Vector2.up, player.playerData.topRaycastLength, player.playerData.platformLayer) && !Physics2D.Raycast(player.CurrentPosition + player.playerData.innerRaycastOffset, Vector2.up, player.playerData.topRaycastLength, player.playerData.platformLayer)) ^ (Physics2D.Raycast(player.CurrentPosition - player.playerData.edgeRaycastOffset, Vector2.up, player.playerData.topRaycastLength, player.playerData.platformLayer) && !Physics2D.Raycast(player.CurrentPosition - player.playerData.innerRaycastOffset, Vector2.up, player.playerData.topRaycastLength, player.playerData.platformLayer));
    }

    private void CheckWall()
    {
        RaycastHit2D[] leftHits = Physics2D.BoxCastAll(player.CurrentPosition - new Vector3(player.playerData.characterDimension.x / 2 + player.playerData.wallRaycastSize.x / 2, 0f, 0f), player.playerData.wallRaycastSize, 0f, Vector2.left, 0f, player.playerData.platformLayer);
        RaycastHit2D[] rightHits = Physics2D.BoxCastAll(player.CurrentPosition + new Vector3(player.playerData.characterDimension.x / 2 + player.playerData.wallRaycastSize.x / 2, 0f, 0f), player.playerData.wallRaycastSize, 0f, Vector2.right, 0f, player.playerData.platformLayer);
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
                        if (Vector2.Angle(leftHits[i].normal, Vector2.up) > player.playerData.wallMinimumAngle) onLeftWall = true; ;
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
                        if (Vector2.Angle(rightHits[i].normal, Vector2.up) > player.playerData.wallMinimumAngle) onRightWall = true;
                    }
                }
            }
        }

        onWall = onRightWall || onLeftWall;

        onLeftWallClimbCheck = Physics2D.Raycast(player.CurrentPosition + new Vector3(player.playerData.characterDimension.x / 2 * -1f, player.playerData.wallClimbRaycastYOffset, 0f), Vector2.left, player.playerData.wallRaycastSize.x, player.playerData.platformLayer);
        onRightWallClimbCheck = Physics2D.Raycast(player.CurrentPosition + new Vector3(player.playerData.characterDimension.x / 2, player.playerData.wallClimbRaycastYOffset, 0f), Vector2.right, player.playerData.wallRaycastSize.x, player.playerData.platformLayer);
        onWallClimbCheck = onLeftWallClimbCheck || onRightWallClimbCheck;
    }

    private void CheckCeilingHit()
    {
        hitCeiling = Physics2D.Raycast(player.CurrentPosition, Vector2.up, player.playerData.ceilingRaycastLength, player.playerData.platformLayer);
    }
    private void CheckLedgeTargets()
    {
        RaycastHit2D leftNormalHit = Physics2D.BoxCast(player.CurrentPosition + new Vector3((player.playerData.characterDimension.x / 2 + player.playerData.wallLedgeRaycastSize.x / 2) * -1, player.playerData.wallLedgeRaycastYOffset, 0f), player.playerData.wallLedgeRaycastSize, 0f, Vector2.left, 0f, player.playerData.platformLayer);
        RaycastHit2D rightNormalHit = Physics2D.BoxCast(player.CurrentPosition + new Vector3(player.playerData.characterDimension.x / 2 + player.playerData.wallLedgeRaycastSize.x / 2, player.playerData.wallLedgeRaycastYOffset, 0f), player.playerData.wallLedgeRaycastSize, 0f, Vector2.right, 0f, player.playerData.platformLayer);
        RaycastHit2D leftOnewayHit = Physics2D.BoxCast(player.CurrentPosition + new Vector3((player.playerData.characterDimension.x / 2 + player.playerData.wallLedgeRaycastSize.x / 2) * -1, player.playerData.wallLedgeRaycastYOffset, 0f), player.playerData.wallLedgeRaycastSize, 0f, Vector2.left, 0f, player.playerData.onewayPlatformLayer);
        RaycastHit2D rightOnewayHit = Physics2D.BoxCast(player.CurrentPosition + new Vector3(player.playerData.characterDimension.x / 2 + player.playerData.wallLedgeRaycastSize.x / 2, player.playerData.wallLedgeRaycastYOffset, 0f), player.playerData.wallLedgeRaycastSize, 0f, Vector2.right, 0f, player.playerData.onewayPlatformLayer);
        RaycastHit2D middleOnewayHit = Physics2D.BoxCast(player.CurrentPosition + new Vector3(0f, player.playerData.wallLedgeRaycastYOffset, 0f), new Vector2(player.playerData.characterDimension.x * 0.8f, player.playerData.wallLedgeRaycastSize.y), 0f, Vector2.up, 0f, player.playerData.onewayPlatformLayer);

        bool leftNormalLedgeCheck = onLeftWall && (leftNormalHit.collider != null) && !Physics2D.Raycast(player.CurrentPosition + Vector3.up * player.playerData.ledgeRaycastYOffset, Vector2.left, player.playerData.ledgeRaycastLength, player.playerData.platformLayer);
        bool rightNormalLedgeCheck = onRightWall && (rightNormalHit.collider != null) && !Physics2D.Raycast(player.CurrentPosition + Vector3.up * player.playerData.ledgeRaycastYOffset, Vector2.right, player.playerData.ledgeRaycastLength, player.playerData.platformLayer);
        bool leftOnewayLedgeCheck = (leftOnewayHit.collider != null) && !Physics2D.Raycast(player.CurrentPosition + Vector3.up * player.playerData.ledgeRaycastYOffset, Vector2.left, player.playerData.ledgeRaycastLength, player.playerData.onewayPlatformLayer);
        bool rightOnewayLedgeCheck = (rightOnewayHit.collider != null) && !Physics2D.Raycast(player.CurrentPosition + Vector3.up * player.playerData.ledgeRaycastYOffset, Vector2.right, player.playerData.ledgeRaycastLength, player.playerData.onewayPlatformLayer);
        bool middleOnewayLedgeCheck = (middleOnewayHit.collider != null) && !Physics2D.Raycast(player.CurrentPosition + Vector3.up * player.playerData.ledgeRaycastYOffset + Vector3.left * player.playerData.characterDimension.x * 0.4f, Vector2.right, player.playerData.characterDimension.x * 0.8f, player.playerData.onewayPlatformLayer);

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

        RaycastHit2D[] ceilingHits = Physics2D.RaycastAll(player.CurrentPosition, Vector2.up, player.playerData.characterDimension.y * 1.5f, player.playerData.platformLayer);
        isHighEnoughToClimbLedge = true;
        if (ceilingHits != null)
        {
            for (int i = 0; i < ceilingHits.Length; i++)
            {
                if (ceilingHits[i].collider != null)
                {
                    if (ceilingHits[i].collider.CompareTag("Platform")) isHighEnoughToClimbLedge = false;
                    else isHighEnoughToClimbLedge = true;
                }
            }
        }
    }
}
