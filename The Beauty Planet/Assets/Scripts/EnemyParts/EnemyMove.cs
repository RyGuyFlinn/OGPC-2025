using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Transform target;
    public float speed;
    public bool upAndDown;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        target = GameObject.Find("Player").transform;
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
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
    }
}
