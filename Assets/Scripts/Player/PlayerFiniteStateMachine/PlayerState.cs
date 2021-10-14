using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected Player player;
    protected PlayerStateMachine stateMachine;
    protected PlayerData playerData;
    protected float startTime;

    private string animBoolName;
    protected bool isAnimationFinished;

    protected bool moveAgainstTheWall;
    protected Vector2 input;
    protected bool jumpInput;
    protected bool sneak;

    protected bool climbLedge;

    private bool lnml;
    private bool rnml;
    private bool lowl;
    private bool rowl;
    private bool mowl;
    private bool onAnyLedge => lnml || rnml || lowl || rowl;
    private bool onAnyNormalLedge => lnml || rnml;
    private bool onAnyOnewayLedge => lowl || rowl;

    public PlayerState(Player player, PlayerStateMachine stateMachine, PlayerData playerData, string animBoolName)
    {
        this.player = player;
        this.stateMachine = stateMachine;
        this.playerData = playerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoCheck();
        player.animator.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = true; // When animation sprites are done set this to false;
        Debug.Log(GetType());
    }

    public virtual void Exit()
    {
        player.animator.SetBool(animBoolName, false);
    }

    public virtual void NormalUpdate()
    {
        input = player.InputHandler.MovementInput;
        jumpInput = player.InputHandler.JumpInput;
        sneak = player.InputHandler.SneakInput;
        moveAgainstTheWall = ((input.x < 0f) && player.Collisions.onLeftWall) || ((input.x > 0f) && player.Collisions.onRightWall);
    }

    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck()
    {
    }

    public virtual void AnimationTrigger()
    {

    }

    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;

    protected void CheckLedge(float xDir)
    {
        lnml = player.Collisions.leftNormalLedgeTarget != null;
        rnml = player.Collisions.rightNormalLedgeTarget != null;
        lowl = player.Collisions.leftOnewayLedgeTarget != null;
        rowl = player.Collisions.rightOnewayLedgeTarget != null;
        mowl = player.Collisions.middleOnewayLedgeTarget != null;
        climbLedge = false;
        player.ledgeTarget = null;
        player.ledgeDirection = xDir;

        if (onAnyOnewayLedge && !onAnyNormalLedge) // Only one way platform
        {

            // If only hits on the side
            if (player.ledgeDirection < 0)
            {
                if (lowl && !mowl && !rowl)
                {
                    player.ledgeTarget = player.Collisions.leftOnewayLedgeTarget;
                    climbLedge = true;
                }
            }
            else if (player.ledgeDirection > 0)
            {
                if (!lowl && !mowl && rowl)
                {
                    player.ledgeTarget = player.Collisions.rightOnewayLedgeTarget;
                    climbLedge = true;
                }
            }
        }
        else if (onAnyNormalLedge) // Only normal platform
        {
            if (player.ledgeDirection < 0)
            {
                if (lnml)
                {
                    player.ledgeTarget = player.Collisions.leftNormalLedgeTarget;
                    climbLedge = true;
                }
            }
            else if (player.ledgeDirection > 0)
            {
                if (rnml)
                {
                    player.ledgeTarget = player.Collisions.rightNormalLedgeTarget;
                    climbLedge = true;
                }
            }
        }
        else if (onAnyNormalLedge && onAnyOnewayLedge && !mowl)
        {
            if (player.ledgeDirection < 0)
            {
                if (lnml && !lowl && !rnml && rowl)
                {
                    player.ledgeTarget = player.Collisions.leftNormalLedgeTarget;
                    climbLedge = true;
                }
                else if (!lnml && lowl && rnml && !rowl)
                {
                    player.ledgeTarget = player.Collisions.leftOnewayLedgeTarget;
                    climbLedge = true;
                }
            }
            else if (player.ledgeDirection > 0)
            {
                if (lnml && !lowl && !rnml && rowl) 
                {
                    player.ledgeTarget = player.Collisions.rightNormalLedgeTarget;
                    climbLedge = true;
                }
                else if (!lnml && lowl && rnml && !rowl) 
                {
                    player.ledgeTarget = player.Collisions.rightOnewayLedgeTarget;
                    climbLedge = true;
                }
            }
        }
    }
}
