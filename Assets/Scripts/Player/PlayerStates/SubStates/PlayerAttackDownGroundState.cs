using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDownGroundState : PlayerAttack
{
    public PlayerAttackDownGroundState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
}
