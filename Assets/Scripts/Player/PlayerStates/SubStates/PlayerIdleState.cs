using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIdleState : PlayerGrounded
{
    public PlayerIdleState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if (player.InputHandler.CanControl)
        {
            if (input.x != 0f && !sneak && !moveAgainstTheWall)
            {
                stateMachine.ChangeState(player.MoveState);
            }
            else if (input.x != 0f && sneak && !moveAgainstTheWall)
            {
                stateMachine.ChangeState(player.SneakState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
