using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallClimbState : PlayerWalled
{
    public PlayerWallClimbState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
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
            else if (moveAgainstTheWall)
            {
                if (input.y > 0f)
                {
                    if (player.Collisions.onWallClimbCheck && !climbLedge && player.Collisions.hitCeiling)
                    {
                        stateMachine.ChangeState(player.WallHangState);
                    }
                }
                else if (input.y == 0f)
                {
                    stateMachine.ChangeState(player.WallSlideState);
                }
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
        player.DoWallClimb();
    }
}
