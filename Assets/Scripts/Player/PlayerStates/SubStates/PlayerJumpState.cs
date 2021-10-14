using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpState : PlayerJump
{
    protected int extraJumpCount;
    public PlayerJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
        extraJumpCount = playerData.extreJumpAmount;
    }

    public override void DoCheck()
    {
        base.DoCheck();
    }

    public override void Enter()
    {
        base.Enter();
        player.wallJumped = false;
        player.DoJump(Vector2.up);
        isJumpDone = true;
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void NormalUpdate()
    {
        base.NormalUpdate();
    }

    public override void PhysicsUpdate()
    {
        base.PhysicsUpdate();
    }
    public bool CanExtraJump()
    {
        if (extraJumpCount > 0) return true;
        return false;
    }
    public void ResetAmountOfExtraJump() => extraJumpCount = playerData.extreJumpAmount;
    public void DecreaseAmountOfExtraJump() => extraJumpCount--;
}
