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
    public Enemy Enemy { get; private set; }
    public Rigidbody2D RB { get; private set; }
    #endregion

    #region Game Variable
    [SerializeField] private GameObject patrolPointsHolder;
    [SerializeField] private List<Transform> PatrolPoints;
    [SerializeField] private bool isLooped;

    private int currentPatrolPointIndex;
    public bool isDamaged => Enemy.damaged;
    #endregion

    #region Unity Callback
    private void Awake()
    {
        StateMachine = new CrawlerStateMachine();
    }

    private void Start()
    {
        RB = GetComponent<Rigidbody2D>();
        PatrolPoints = new List<Transform>();
        Enemy = GetComponent<Enemy>();

        foreach (Transform child in patrolPointsHolder.transform)
        {
            PatrolPoints.Add(child);
        }

        currentPatrolPointIndex = 0;
        // StateMachine.Initialize(SpawnState);
    }

    private void Update()
    {
        // StateMachine.CurrentState.NormalUpdate();
    }

    private void FixedUpdate()
    {
        // StateMachine.CurrentState.PhysicsUpdate();
    }
    #endregion
}
