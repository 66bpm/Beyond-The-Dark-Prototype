using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWalled : PlayerState
{
    public PlayerWalled(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if (player.Collisions.onGround)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (!moveAgainstTheWall && !player.Collisions.onGround && !jumpInput)
        {
            stateMachine.ChangeState(player.AiredState);
        }
        else if (!player.Collisions.onGround && jumpInput && player.Collisions.onWall)
        {
            player.InputHandler.UseJumpInput();
            stateMachine.ChangeState(player.WallJumpState);
        }
    }
}
