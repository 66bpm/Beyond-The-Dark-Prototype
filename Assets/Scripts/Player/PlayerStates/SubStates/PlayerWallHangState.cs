using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallHangState : PlayerWalled
{
    public PlayerWallHangState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if (moveAgainstTheWall && input.y == 0f && player.InputHandler.CanControl)
        {
            stateMachine.ChangeState(player.WallSlideState);
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.DoWallClimb();
    }
}
