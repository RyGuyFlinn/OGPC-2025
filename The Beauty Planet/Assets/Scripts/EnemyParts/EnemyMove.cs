using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform target;
    public float speed;
    public bool upAndDown;
    private Animator animator;
    private SpriteRenderer renderer;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
        
        if (upAndDown == true)
        {
            speed = GetComponent<Rigidbody2D>().velocity.y;
        }
        else
        {
            speed = GetComponent<Rigidbody2D>().velocity.x;
        }

        animator.SetFloat("speed", speed);
        if (speed < 0)
        {
            renderer.flipX = true;
        }
        else
        {
            renderer.flipX = false;
        }
    }
}
