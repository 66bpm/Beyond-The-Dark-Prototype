using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackFrontState : PlayerAttack
{
    public PlayerAttackFrontState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
}
