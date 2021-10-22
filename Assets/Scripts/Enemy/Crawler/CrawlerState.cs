using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerState
{
    protected Crawler crawler;
    protected CrawlerStateMachine stateMachine;
    protected NormalEnemyData crawlerData;
    protected float startTime;

    private string animBoolName;
    protected bool isAnimationFinished;

    public CrawlerState(Crawler crawler, CrawlerStateMachine stateMachine, NormalEnemyData crawlerData, string animBoolName)
    {
        this.crawler = crawler;
        this.stateMachine = stateMachine;
        this.crawlerData = crawlerData;
        this.animBoolName = animBoolName;
    }

    public virtual void Enter()
    {
        DoCheck();
        crawler.animator.SetBool(animBoolName, true);
        startTime = Time.time;
        isAnimationFinished = true; // When animation sprites are done set this to false;
    }

    public virtual void Exit()
    {
        crawler.animator.SetBool(animBoolName, false);
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

    public virtual void AnimationTrigger() { }
    public virtual void AnimationFinishTrigger() => isAnimationFinished = true;
}
