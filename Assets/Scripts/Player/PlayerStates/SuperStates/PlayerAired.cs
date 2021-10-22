using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAired : PlayerState
{
    private float highestPoint;
    private bool isHeadHit;
    public PlayerAired(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.wallJumped = false;
        highestPoint = player.transform.position.y;
        isHeadHit = false;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();

        VelocityFlipCheck();

        if (player.transform.position.y > highestPoint) highestPoint = player.transform.position.y;

        
        if (player.Collisions.onGround && player.CurrentVelocity.y <= 0 && !player.isDroppingFromPlatform)
        {
            if (highestPoint - player.transform.position.y > playerData.heightToForceLandAnimation)
            {
                player.hardLanded = true;
                stateMachine.ChangeState(player.LandState);
            }
            else
            {
                stateMachine.ChangeState(player.LandState);
            }
        }
        else if (player.InputHandler.CanControl)
        {
            CheckLedge(input.x);
            if (climbLedge && input.y > 0)
            {
                stateMachine.ChangeState(player.LedgeClimbState);
            }
            if (player.InputHandler.CanMove)
            {
                if (player.Collisions.onWallClimbCheck && !climbLedge && input.y > 0 && moveAgainstTheWall)
                {
                    player.ActionSoundManager.SpawnActionSound(playerData.midVolumeSoundRadius, playerData.midVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition, "MidActionSound");
                    stateMachine.ChangeState(player.WallClimbState);
                }
                else if (moveAgainstTheWall && input.y == 0 && player.InputHandler.CanMove)
                {
                    player.ActionSoundManager.SpawnActionSound(playerData.midVolumeSoundRadius, playerData.midVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition, "MidActionSound");
                    stateMachine.ChangeState(player.WallSlideState);
                }
                else if (jumpInput)
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
            }
        }
        if (player.Collisions.hitCeiling && !isHeadHit)
        {
            player.ActionSoundManager.SpawnActionSound(playerData.lowVolumeSoundRadius, playerData.lowVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.TopSoundPosition);
            isHeadHit = true;
        }
        else
        {
            isHeadHit = false;
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
