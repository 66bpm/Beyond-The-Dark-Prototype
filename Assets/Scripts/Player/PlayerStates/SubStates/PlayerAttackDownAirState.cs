using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttackDownAirState : PlayerAttack
{
    public PlayerAttackDownAirState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName) : base(player, stateMachine, playerData, animBoolName)
    {
    }
}
