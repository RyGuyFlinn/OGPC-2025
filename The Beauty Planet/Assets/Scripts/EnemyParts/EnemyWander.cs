using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyWander : MonoBehaviour
{
    public float wobble;
    private float wobbleAcceleration;
    private float direction;
    public bool upAndDown;
    public bool isBoss;
    //private Animator animator;
    private SpriteRenderer renderer;
    private Vector3 prevPos;
    private EnemyHideHealth health;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        if (!isBoss)
        {
            health = GetComponent<EnemyHideHealth>();
            renderer = GetComponent<SpriteRenderer>();
        }
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
        //animator = GetComponent<Animator>();
    }

    void Update()
    {
        //change the direction acceleration by a small amount and then dampen it
        wobbleAcceleration = (wobbleAcceleration + Random.Range(wobble, -wobble)) * 0.95f;

        direction = (direction + wobbleAcceleration) % 360;
        
        if (isBoss)
        {
            float radians = direction * Mathf.Deg2Rad;
            agent.SetDestination(transform.position + 5 * new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), transform.position.z));
        }
        else if (health.timeSinceHit > 400)
        {
            float radians = direction * Mathf.Deg2Rad;
            agent.SetDestination(transform.position + 5 * new Vector3(Mathf.Cos(radians), Mathf.Sin(radians), transform.position.z));
        }
        else
        {
            agent.SetDestination(transform.position);
        }
        
        if (upAndDown == true)
        {

        }
        else if (isBoss)
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