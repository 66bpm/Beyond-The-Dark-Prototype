using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public bool damaged;
    public Vector2 forceDirection;
    private void Start()
    {
        forceDirection = new Vector2();
    }

    public void Damaged (Vector2 direction)
    {
        damaged = true;
        forceDirection = direction;
    }

    public void Recovered()
    {
        damaged = false;
    }
}
