using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyState
{
    protected Enemy enemy;
    protected EnemyStateMachine stateMachine;
    protected EnemyData enemyData;
    protected float startTime;

    private string animBoolName;
    protected bool isAnimationFinished;

    public EnemyState(Enemy enemy, EnemyStateMachine stateMachine, EnemyData enemyData, string animBoolName)
    {
        this.enemy = enemy;
        this.stateMachine = stateMachine;
        this.enemyData = enemyData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoCheck();
        // enemy.animator.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = true; // When animation sprites are done set this to false;
    }

    public virtual void Exit()
    {
        // enemy.animator.SetBool(animBoolName, false);
    }

    public virtual void NormalUpdate()
    {
    }

    public virtual void PhysicsUpdate()
    {
        DoCheck();
    }

    public virtual void DoCheck()
    {
    }

    public virtual void AnimationTrigger() {}
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
