using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSneakState : PlayerGrounded
{
    public PlayerSneakState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if ((input.x == 0 && player.CurrentVelocity.x == 0)||moveAgainstTheWall)
        {
            stateMachine.ChangeState(player.IdleState);
        }
        else if (input.x != 0 && !sneak && player.InputHandler.CanControl)
        {
            stateMachine.ChangeState(player.MoveState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.DoSneak(input.x);
    }
}
