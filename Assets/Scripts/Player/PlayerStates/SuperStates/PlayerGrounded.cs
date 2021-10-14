using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerGrounded : PlayerState
{
    public PlayerGrounded(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        player.JumpState.ResetAmountOfExtraJump();
        player.extraJumped = false;
        player.wallJumped = false;
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();

        

        if (!player.Collisions.onGround && !moveAgainstTheWall)
        {
            stateMachine.ChangeState(player.AiredState);
        }
        else if (player.InputHandler.CanControl)
        {
            CheckLedge(input.x);
            if (climbLedge && input.y > 0)
            {
                stateMachine.ChangeState(player.LedgeClimbState);
            }
            else if (jumpInput)
            {
                player.InputHandler.UseJumpInput();
                if (player.isDroppingFromPlatform)
                {
                    player.JumpState.DecreaseAmountOfExtraJump();
                    player.extraJumped = true;
                }
                stateMachine.ChangeState(player.JumpState);
            }
            else if (moveAgainstTheWall && input.y > 0 && player.InputHandler.CanControl && player.Collisions.onWallClimbCheck)
            {
                stateMachine.ChangeState(player.WallClimbState);
            }
        }
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
}
