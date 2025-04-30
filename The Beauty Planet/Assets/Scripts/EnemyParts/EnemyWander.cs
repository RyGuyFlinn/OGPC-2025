using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWander : MonoBehaviour
{
    public float speed;
    public float wobble;
    private float wobbleAcceleration;
    private float direction;
    public bool upAndDown;
    //private Animator animator;
    private SpriteRenderer renderer;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        //change the direction acceleration by a small amount and then dampen it
        wobbleAcceleration = (wobbleAcceleration + Random.Range(wobble, -wobble)) * 0.95;

        direction += wobbleAcceleration;
        
        agent.SetDestination(transform.position);
        
        if (upAndDown == true)
        {
            speed = GetComponent<Rigidbody2D>().velocity.y;
        }
        else
        {
            speed = GetComponent<Rigidbody2D>().velocity.x;
        }

        //animator.SetFloat("speed", speed);
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