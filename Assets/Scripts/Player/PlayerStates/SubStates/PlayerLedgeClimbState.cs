using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLedgeClimbState : PlayerWalled
{
    private Vector3 newPosition;
    public PlayerLedgeClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.StartLedgeClimb();
    }

    public override void Exit()
    {
        base.Exit();
        player.CompleteLedgeClimb();
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if (isAnimationFinished)
        {
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
            else
            {
                stateMachine.ChangeState(player.IdleState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }

}
