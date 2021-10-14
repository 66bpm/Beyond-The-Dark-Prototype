using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : Enemy
{
    #region State
    public EnemyStateMachine StateMachine { get; private set; }
    #endregion

    #region Unity Component
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Unity Callback
    private void Awake()
    {
        StateMachine = new EnemyStateMachine();
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        // StateMachine.Initialize(PatrolState);
    }

    private void Update()
    {
        StateMachine.CurrentState.NormalUpdate();
    }

    private void FixedUpdate()
    {
        StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion
}
