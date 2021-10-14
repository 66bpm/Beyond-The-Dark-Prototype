using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerWalled
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
        if (player.Collisions.onWallClimbCheck && moveAgainstTheWall && player.InputHandler.CanMove)
        {
            stateMachine.ChangeState(player.WallClimbState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.DoWallSlide();
    }
}
