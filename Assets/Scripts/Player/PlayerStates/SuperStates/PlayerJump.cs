using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : PlayerState
{
    protected bool isJumpDone;

    public PlayerJump(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }


    public override void Enter()
    {
        base.Enter();
        isJumpDone = false;
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if (isJumpDone)
        {
            if (player.Collisions.onGround && player.CurrentVelocity.y <= 0)
            {
                stateMachine.ChangeState(player.IdleState);
            }
            else if (isAnimationFinished)
            {
                stateMachine.ChangeState(player.AiredState);
            }
        }
    }
}
