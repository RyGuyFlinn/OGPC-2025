using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bob : MonoBehaviour
{
    public GameObject bullet;
    public int spawnAmount = 1;

    public bool isFighting = false;

    public int currentStage = 1;

    public GameObject[] lasers;
    public GameObject[] enemies;
    public GameObject dustDevil;

    enum State { Blaster, Lasers, GroundSmash, Idle, DustDevil, Minions, ShockWave }
    private State currentState;

    private GameObject spawnedBullet;
    private GameObject player;
    private float timer = 0f;

    private bool isAttacking = false;

    public float bulletSpeed = 1f;

    void Start()
    {
        currentState = State.Idle; // Start in Idle state
        player = GameObject.Find("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;

        switch (currentState)
        {
            case State.Idle:
                StartCoroutine(Idle());
                break;

            case State.Blaster:
                StartCoroutine(ShootBullet());
                currentState = State.Idle;
                isAttacking = false;
                break;

            case State.GroundSmash:
                SpawnEnemies();
                currentState = State.Idle;
                isAttacking = false;
                break;

            case State.Minions:
                SpawnEnemies();
                currentState = State.Idle;
                isAttacking = false;
                break;

            case State.Lasers:
                FireLasers();
                currentState = State.Idle;
                isAttacking = false;
                break;

            case State.DustDevil:
                ShockWave();
                currentState = State.Idle;
                isAttacking = false;
                break;

            case State.ShockWave:
                ShockWave();
                currentState = State.Idle;
                isAttacking = false;
                break;
        }
    }

    IEnumerator Idle()
    {
        if (isFighting == true)
        {
            if (isAttacking == false)
            {
                isAttacking = true;

                if (currentStage == 1)
                {
                    yield return new WaitForSeconds(Random.Range(3, 5));
                }
                else
                {
                    yield return new WaitForSeconds(Random.Range(2, 4));
                }

                SetRandomState();
            }
        }
    }

    void SetRandomState()
    {
        State[] weightedStates;

        if (currentStage == 1)
        {
            weightedStates = new State[]
            {
            State.Blaster, State.Blaster,
            State.GroundSmash, State.GroundSmash,
            State.Minions, State.Minions, State.Minions,
            State.Lasers, State.Lasers,
            State.ShockWave, State.ShockWave, State.ShockWave
            };
        }
        else
        {
            weightedStates = new State[]
            {
            State.Blaster, State.Blaster,
            State.DustDevil, State.DustDevil, State.DustDevil,
            State.GroundSmash, State.GroundSmash,
            State.Minions, State.Minions, State.Minions,
            State.Lasers, State.Lasers,
            State.ShockWave, State.ShockWave
            };
        }

        currentState = weightedStates[Random.Range(0, weightedStates.Length)];
    }

    IEnumerator GroundSmash()
    {

    }

    private void ShockWave()
    {
        if (currentStage == 1)
        {
            spawnAmount = 8;
        }
        else
        {
            spawnAmount = 12;
        }
        if (bullet)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                spawnedBullet.GetComponent<EnemyBullet>().speed = bulletSpeed;
                spawnedBullet.transform.rotation = transform.rotation *= Quaternion.Euler(0, 0, (360 / spawnAmount));
            }
        }
    }

    IEnumerator ShootBullet()
    {
        if (currentStage == 1)
        {
            spawnAmount = 5;
        }
        else
        {
            spawnAmount = 7;
        }

        if (bullet)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                Vector2 direction = player.transform.position - transform.position;

                spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                spawnedBullet.GetComponent<EnemyBullet>().speed = bulletSpeed;
                spawnedBullet.transform.rotation = Quaternion.FromToRotation(Vector3.up, direction) * Quaternion.Euler(0, 0, 90); ;

                yield return new WaitForSeconds(.75f);
            }
        }
    }

    private void FireLasers()
    {
        List<GameObject> selectedObjects = new List<GameObject>(lasers);

        if (currentStage == 1)
        {
            for (int i = 0; i < 1; i++)
            {
                int index = Random.Range(0, selectedObjects.Count);
                GameObject obj = selectedObjects[index];
                selectedObjects.RemoveAt(index);

                obj.GetComponent<Laser>().Fire();
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                int index = Random.Range(0, selectedObjects.Count);
                GameObject obj = selectedObjects[index];
                selectedObjects.RemoveAt(index);

                obj.GetComponent<Laser>().Fire();
            }
        }
    }

    private void SpawnEnemies()
    {
        if (currentStage == 1)
        {
            for (int i = 0; i < 1; i++)
            {
                Vector2 localPosition = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));
                Vector2 worldPosition = transform.TransformPoint(localPosition);

                Instantiate(enemies[Random.Range(0, enemies.Length)], worldPosition, Quaternion.identity);
            }
        }
        else
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 localPosition = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));
                Vector2 worldPosition = transform.TransformPoint(localPosition);

                Instantiate(enemies[Random.Range(0, enemies.Length)], worldPosition, Quaternion.identity);
            }
        }
    }

    private void SpawnDustDevil()
    {
        if (currentStage == 1)
        {
            for (int i = 0; i < 2; i++)
            {
                Vector2 localPosition = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));
                Vector2 worldPosition = transform.TransformPoint(localPosition);

                Instantiate(dustDevil, worldPosition, Quaternion.identity);
            }
        }
        else
        {
            for (int i = 0; i < 3; i++)
            {
                Vector2 localPosition = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));
                Vector2 worldPosition = transform.TransformPoint(localPosition);

                Instantiate(dustDevil, worldPosition, Quaternion.identity);
            }
        }
    }
}

