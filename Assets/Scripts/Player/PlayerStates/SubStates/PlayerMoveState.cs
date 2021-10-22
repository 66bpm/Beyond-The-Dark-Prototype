using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveState : PlayerGrounded
{
    private float actionSoundCounter;
    public PlayerMoveState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        actionSoundCounter = playerData.runSoundPeriod;
        player.ActionSoundManager.SpawnActionSound(playerData.lowVolumeSoundRadius, playerData.lowVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition);
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if ((input.x == 0 && player.CurrentVelocity.x == 0) || moveAgainstTheWall)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (input.x != 0 && sneak && player.InputHandler.CanControl)
        {
            stateMachine.ChangeState(player.SneakState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        if (input.x != 0)
        {
            if (actionSoundCounter <= 0f)
            {
                actionSoundCounter = playerData.runSoundPeriod;
                player.ActionSoundManager.SpawnActionSound(playerData.lowVolumeSoundRadius, playerData.lowVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition);
            }
            else
            {
                actionSoundCounter -= Time.fixedDeltaTime;
            }
        }
        player.DoMove(input.x);
    }
}
