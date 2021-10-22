using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWallJumpState : PlayerJump
{
    public PlayerWallJumpState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }

    public override void Enter()
    {
        base.Enter();
        Vector3 targetSoundLocalPosition = Vector3.zero;
        if (player.Collisions.onLeftWall && !player.Collisions.onRightWall) targetSoundLocalPosition = player.ActionSoundManager.BottomSoundPosition + Vector3.left * playerData.characterDimension.x / 2;
        else if (!player.Collisions.onLeftWall && player.Collisions.onRightWall) targetSoundLocalPosition = player.ActionSoundManager.BottomSoundPosition + Vector3.right * playerData.characterDimension.x / 2;
        else if (player.Collisions.onLeftWall && player.Collisions.onRightWall) targetSoundLocalPosition = player.ActionSoundManager.BottomSoundPosition;
        player.ActionSoundManager.SpawnActionSound(playerData.midVolumeSoundRadius, playerData.midVolumeSoundAnimationDecayTime, player.CurrentPosition, targetSoundLocalPosition, "MidActionSound");
        player.DoWallJump();
        isJumpDone = true;
    }
}
