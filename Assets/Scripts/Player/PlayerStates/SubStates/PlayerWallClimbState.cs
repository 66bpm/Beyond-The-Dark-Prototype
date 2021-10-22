using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerWalled
{
    private float actionSoundCounter;
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        actionSoundCounter = playerData.wallClimbSoundPeriod;
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        FlipCheck();
        if (player.InputHandler.CanControl)
        {
            CheckLedge(input.x);
            if (climbLedge && input.y > 0f)
            {
                stateMachine.ChangeState(player.LedgeClimbState);
            }
            else if (moveAgainstTheWall)
            {
                if (input.y > 0f)
                {
                    if (player.Collisions.onWallClimbCheck && !climbLedge && player.Collisions.hitCeiling)
                    {
                        stateMachine.ChangeState(player.WallHangState);
                    }
                }
                else if (input.y == 0f)
                {
                    stateMachine.ChangeState(player.WallSlideState);
                }
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (moveAgainstTheWall && input.y > 0f)
        {
            if (actionSoundCounter <= 0f)
            {
                actionSoundCounter = playerData.wallClimbSoundPeriod;
                player.ActionSoundManager.SpawnActionSound(playerData.lowVolumeSoundRadius, playerData.lowVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition);
            }
            else
            {
                actionSoundCounter -= Time.fixedDeltaTime;
            }
        }
        player.DoWallClimb();
    }
}
