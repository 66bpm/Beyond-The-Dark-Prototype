using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : PlayerState
{
    private bool isAttackDone;
    public PlayerAttack(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        isAttackDone = false;
        player.DoAttack();
        isAttackDone = true;
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if (player.transform.position.y > player.HighestPoint) player.HighestPoint = player.transform.position.y;

        if (player.Collisions.onGround && player.CurrentVelocity.y <= 0 && !player.isDroppingFromPlatform)
        {
            if (player.HighestPoint - player.transform.position.y > playerData.heightToForceLandAnimation)
            {
                player.hardLanded = true;
                stateMachine.ChangeState(player.LandState);
            }
            else if (player.HighestPoint - player.transform.position.y > 1f)
            {
                player.ActionSoundManager.SpawnActionSound(playerData.midVolumeSoundRadius, playerData.midVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition, "MidActionSound");
                player.HighestPoint = player.transform.position.y;
            }
        }
        if (isAnimationFinished && isAttackDone)
        {
            VelocityFlipCheck();

            if (!player.Collisions.onGround && !moveAgainstTheWall)
            {
                stateMachine.ChangeState(player.AiredState);
            }
            else
            {
                if (player.InputHandler.CanControl)
                {
                    CheckLedge(input.x);
                    if (climbLedge && input.y > 0)
                    {
                        stateMachine.ChangeState(player.LedgeClimbState);
                    }
                    if (player.Collisions.onGround)
                    {
                        if (input.x != 0f)
                        {
                            if (!sneak && !moveAgainstTheWall)
                            {
                                stateMachine.ChangeState(player.MoveState);
                            }
                            else if (sneak && !moveAgainstTheWall)
                            {
                                stateMachine.ChangeState(player.SneakState);
                            }
                        }
                        else stateMachine.ChangeState(player.IdleState);
                    }
                    else if (player.Collisions.onWallClimbCheck && !climbLedge && input.y > 0 && moveAgainstTheWall)
                    {
                        if (!player.Collisions.onGround)
                            player.ActionSoundManager.SpawnActionSound(playerData.midVolumeSoundRadius, playerData.midVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition, "MidActionSound");
                        stateMachine.ChangeState(player.WallClimbState);
                    }
                    else if (moveAgainstTheWall && input.y == 0 && player.InputHandler.CanMove)
                    {
                        if (!player.Collisions.onGround)
                            player.ActionSoundManager.SpawnActionSound(playerData.midVolumeSoundRadius, playerData.midVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition, "MidActionSound");
                        stateMachine.ChangeState(player.WallSlideState);
                    }
                }
            }
        }
    }
}
