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
        player.HighestPoint = player.transform.position.y;
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();

        VelocityFlipCheck();

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
            else if (attackInput)
            {
                player.InputHandler.UseAttackInput();
                player.AttackDirection = player.InputHandler.GetAttackDirection(!player.isFlipped);
                if (player.AttackDirection == Vector2.up)
                {
                    stateMachine.ChangeState(player.AttackUpState);
                }
                else if (player.AttackDirection == Vector2.down)
                {
                    stateMachine.ChangeState(player.AttackDownGroundState);
                }
                else if (player.AttackDirection == Vector2.left || player.AttackDirection == Vector2.right)
                {
                    if (player.AttackDirection == Vector2.left && !player.isFlipped || player.AttackDirection == Vector2.right && player.isFlipped) player.Flip();
                    stateMachine.ChangeState(player.AttackFrontState);
                }
            }
            else if (moveAgainstTheWall && input.y > 0 && player.Collisions.onWallClimbCheck)
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
