using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Crawler : MonoBehaviour
{
    #region State
    public CrawlerStateMachine StateMachine { get; private set; }
    #endregion

    #region Unity Component
    [SerializeField] public Animator animator;
    [SerializeField] private SpriteRenderer spriteRenderer;
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Unity Callback
    private void Awake()
    {
        StateMachine = new CrawlerStateMachine();
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
