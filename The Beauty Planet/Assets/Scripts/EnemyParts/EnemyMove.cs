using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform target;
    private Vector3 prevPos;
    public bool upAndDown;
    //private Animator animator;
    private SpriteRenderer renderer;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //animator = GetComponent<Animator>();
        renderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        agent.SetDestination(target.position);
        
        if (upAndDown == true)
        {

        }
        else
        {
            if (prevPos.x > transform.position.x + 0.05f)
            {
                renderer.flipX = true;
            }
            
            if (prevPos.x < transform.position.x - 0.05f)
            {
                renderer.flipX = false;
            }
        }

        //prevpos sets to the current position for the next update
        prevPos = transform.position;
    }
}
