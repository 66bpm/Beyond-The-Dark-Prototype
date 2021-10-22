using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrawlerStateMachine
{
    public CrawlerState CurrentState { get; private set; }

    public void Initialize(CrawlerState startingState)
    {
        CurrentState = startingState;
        CurrentState.Enter();
    }

    public void ChangeState(CrawlerState newState)
    {
        CurrentState.Exit();
        CurrentState = newState;
        CurrentState.Enter();
    }
}
