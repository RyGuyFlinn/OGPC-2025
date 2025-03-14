using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class MainMenuEnemyMove : MonoBehaviour
{
    private Transform target;
    private GameObject[] targets;
    public int TeamNumber;
    private GameObject Enemy;

    UnityEngine.AI.NavMeshAgent agent;

    void Start()
    {
        agent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    void Update()
    {
        if (target != null)
        {
            agent.SetDestination(target.position);
        }
    }

    public void GetTarget()
    {
        targets = GameObject.FindGameObjectsWithTag("Enemy");
        Enemy = targets[Random.Range(0, targets.Length)];

        while (Enemy.GetComponent<MainMenuEnemyMove>().TeamNumber == TeamNumber)
        {
            Enemy = targets[Random.Range(0, targets.Length)];
            if (Enemy.GetComponent<MainMenuEnemyMove>().TeamNumber != TeamNumber)
            {
                target = Enemy.transform;
            }
        }
    }
}
