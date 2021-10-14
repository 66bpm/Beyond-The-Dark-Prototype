using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLandState : PlayerGrounded
{
    public PlayerLandState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
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
