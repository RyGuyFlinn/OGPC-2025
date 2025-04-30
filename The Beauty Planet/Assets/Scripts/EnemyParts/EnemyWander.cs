using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyMove : MonoBehaviour
{
    private Gameobject target;
    public float speed;
    public float wobblyness;
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
        //move target a little bit
        target.transform.position += new Vector3(
        (wobblyness, -wobblyness), 
        (wobblyness, -wobblyness), 
        transform.position.Z);
        //keep target close to crab
        target.transform.position = new Vector3(
        (transform.position.x + target.transform.position.x) / 2, 
        (transform.position.y + target.transform.position.y) / 2, 
        transform.position.Z);
        
        agent.SetDestination(target.position);
        
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