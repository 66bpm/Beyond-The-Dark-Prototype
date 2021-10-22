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

    public override void Enter()
    {
        base.Enter();
        player.wallJumped = false;
        player.ActionSoundManager.SpawnActionSound(playerData.midVolumeSoundRadius, playerData.midVolumeSoundAnimationDecayTime, player.CurrentPosition, player.ActionSoundManager.BottomSoundPosition);
        player.DoJump(Vector2.up);
        isJumpDone = true;
    }

    public bool CanExtraJump()
    {
        if (extraJumpCount > 0) return true;
        return false;
    }
    public void ResetAmountOfExtraJump() => extraJumpCount = playerData.extreJumpAmount;
    public void DecreaseAmountOfExtraJump() => extraJumpCount--;
}
