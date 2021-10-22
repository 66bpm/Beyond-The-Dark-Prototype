using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerWalled
{
    private float actionSoundCounter;
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.ActionSoundManager.SpawnActionSound(playerData.lowVolumeSoundRadius, playerData.lowVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition);
        actionSoundCounter = playerData.wallSlideSoundPeriod;
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        WallSlideFlipCheck();
        if (player.InputHandler.CanControl)
        {
            CheckLedge(input.x);
            if (climbLedge && input.y > 0f)
            {
                stateMachine.ChangeState(player.LedgeClimbState);
            }
            else if (player.Collisions.onWallClimbCheck && moveAgainstTheWall && input.y > 0f)
            {
                stateMachine.ChangeState(player.WallClimbState);
            }
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (moveAgainstTheWall)
        {
            if (actionSoundCounter <= 0f)
            {
                actionSoundCounter = playerData.wallSlideSoundPeriod;
                player.ActionSoundManager.SpawnActionSound(playerData.lowVolumeSoundRadius, playerData.lowVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition);
            }
            else
            {
                actionSoundCounter -= Time.fixedDeltaTime;
            }
        }
        player.DoWallSlide();
    }

    private void WallSlideFlipCheck()
    {
        if (player.InputHandler.CanControl && player.InputHandler.CanMove && (player.isFlipped && input.x < 0f || !player.isFlipped && input.x > 0f))
        {
            player.Flip();
        }
    }
}
