using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionSound : MonoBehaviour
{
    private float radius;
    private CircleCollider2D coll;
    private ParticleSystem ps;
    public float startTime;

    public void Initialize(float radius, Vector3 position)
    {
        coll = GetComponent<CircleCollider2D>();
        ps = GetComponent<ParticleSystem>();
        
        this.radius = radius;
        coll.radius = this.radius;
        transform.position = position;

        var main = ps.main;
        main.startSize = radius * 2f;
        startTime = Time.time;
        ps.Play();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
