using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAired : PlayerState
{
    private float highestPoint;
    public PlayerAired(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.wallJumped = false;
        highestPoint = player.transform.position.y;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if (player.transform.position.y > highestPoint) highestPoint = player.transform.position.y;
        else if (player.Collisions.onGround && player.CurrentVelocity.y <= 0 && !player.isDroppingFromPlatform)
        {
            if ((highestPoint - player.transform.position.y > playerData.heightToForceLandAnimation) || input.x == 0)
            {
                stateMachine.ChangeState(player.LandState);
            }
            else
            {
                if (player.InputHandler.CanControl)
                {
                    if (input.x != 0f && !sneak && !moveAgainstTheWall)
                    {
                        stateMachine.ChangeState(player.MoveState);
                    }
                    else if (input.x != 0f && sneak && !moveAgainstTheWall)
                    {
                        stateMachine.ChangeState(player.SneakState);
                    }
                }
                else stateMachine.ChangeState(player.LandState);
            }
        }
        else if (input.y > 0 && moveAgainstTheWall && player.InputHandler.CanMove)
        {
            CheckLedge(input.x);
            if (climbLedge)
            {
                stateMachine.ChangeState(player.LedgeClimbState);
            }
            else if (player.Collisions.onWallClimbCheck && !climbLedge && player.InputHandler.CanControl)
            {
                stateMachine.ChangeState(player.WallClimbState);
            }

        }
        else if (moveAgainstTheWall && input.y == 0 && player.InputHandler.CanMove && player.InputHandler.CanControl)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
        else if (jumpInput && player.InputHandler.CanControl)
        {
            if (player.Collisions.onWall)
            {
                player.InputHandler.UseJumpInput();
                stateMachine.ChangeState(player.WallJumpState);
            }
            else if (!player.Collisions.onWall && player.JumpState.CanExtraJump())
            {
                player.JumpState.DecreaseAmountOfExtraJump();
                player.wallJumped = false;
                player.extraJumped = true;
                stateMachine.ChangeState(player.JumpState);
            }
            
        }

        player.animator.SetFloat("yVelocity", player.CurrentVelocity.y);
        player.animator.SetFloat("yVelocity", Mathf.Abs(player.CurrentVelocity.x));
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.DoMove(input.x);
        if (player.CurrentVelocity.y > 0f && player.Collisions.canCornerCorrect) CornerCorrect();
    }

    private void CornerCorrect()
    {
        RaycastHit2D leftHit = Physics2D.Raycast(player.CurrentPosition - playerData.innerRaycastOffset + Vector3.up * playerData.topRaycastLength, Vector2.left, playerData.topRaycastLength, playerData.platformLayer);
        RaycastHit2D rightHit = Physics2D.Raycast(player.CurrentPosition + playerData.innerRaycastOffset + Vector3.up * playerData.topRaycastLength, Vector2.right, playerData.topRaycastLength, playerData.platformLayer);

        if (leftHit.collider != null)
        {
            float newPos = Vector3.Distance(new Vector3(leftHit.point.x, player.CurrentPosition.y, 0f) + Vector3.up * playerData.topRaycastLength, player.CurrentPosition - playerData.edgeRaycastOffset + Vector3.up * playerData.topRaycastLength);
            player.transform.position = new Vector3(player.CurrentPosition.x + newPos + playerData.wallCorrectionDistance, player.CurrentPosition.y, player.CurrentPosition.z);
            player.RB.velocity = new Vector2(player.CurrentVelocity.x, player.CurrentVelocity.y);
            return;

        }
        if (rightHit.collider != null)
        {
            float newPos = Vector3.Distance(new Vector3(rightHit.point.x, player.CurrentPosition.y, 0f) + Vector3.up * playerData.topRaycastLength, player.CurrentPosition + playerData.edgeRaycastOffset + Vector3.up * playerData.topRaycastLength);
            player.transform.position = new Vector3(player.CurrentPosition.x - newPos - playerData.wallCorrectionDistance, player.CurrentPosition.y, player.CurrentPosition.z);
            player.RB.velocity = new Vector2(player.CurrentVelocity.x, player.CurrentVelocity.y);
        }
    }
}
