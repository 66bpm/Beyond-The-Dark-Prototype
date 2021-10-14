using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallSlideState : PlayerWalled
{
    public PlayerWallSlideState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
        if (player.InputHandler.CanControl)
        {
            CheckLedge(input.x);
            if (climbLedge && input.y > 0f)
            {
                stateMachine.ChangeState(player.LedgeClimbState);
            }
            else if (player.Collisions.onWallClimbCheck && moveAgainstTheWall && input.y > 0f)
            {
                stateMachine.ChangeState(player.WallClimbState);
            }
        }
        
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.DoWallSlide();
    }
}
