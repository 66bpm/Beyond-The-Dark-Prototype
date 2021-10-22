using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGrounded
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        if (player.hardLanded)
        {
            player.ActionSoundManager.SpawnActionSound(playerData.highVolumeSoundRadius, playerData.highVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition, "HighActionSound");
            player.hardLanded = false;
        }
        else
        {
            player.ActionSoundManager.SpawnActionSound(playerData.midVolumeSoundRadius, playerData.midVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition, "MidActionSound");
            input = player.InputHandler.MovementInput;
            sneak = player.InputHandler.SneakInput;
            moveAgainstTheWall = ((input.x < 0f) && player.Collisions.onLeftWall) || ((input.x > 0f) && player.Collisions.onRightWall);
            if (input.x != 0f && player.InputHandler.CanControl)
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
        }
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if (isAnimationFinished)
        {
            stateMachine.ChangeState(player.IdleState);
        }
    }
}
