using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagulNado : MonoBehaviour
{
    public GameObject bullet;
    public float bulletLife = 1f;
    public float bulletspeed = 1f;
    public float firingRate = 1f;
    public int spawnAmount = 1;

    public GameObject[] lasers;
    public GameObject[] enemies;
    public GameObject rocket;

    enum State { Idle, HomingSeagul, Rockets, Minions, Lasers }
    private State currentState;

    private GameObject spawnedBullet;
    private GameObject player;
    private float timer = 0f;

    private bool isAttacking = false;

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

            case State.HomingSeagul:
                if (timer >= firingRate)
                {
                    FireHomming();
                    timer = 0;
                }
                currentState = State.Idle;
                break;

            case State.Rockets:
                SpawnRockets();
                currentState = State.Idle;
                break;

            case State.Minions:
                SpawnEnemies();
                currentState = State.Idle;
                break;

            case State.Lasers:
                FireLasers();
                currentState = State.Idle;
                break;
        }
    }

    IEnumerator Idle()
    {
        if (isAttacking == false)
        {
            isAttacking = true;
            yield return new WaitForSeconds(Random.Range(1, 5));

            int randomState = Random.Range(0, System.Enum.GetValues(typeof(State)).Length);
            currentState = (State)randomState;
        }
    }

    private void FireHomming()
    {
        if (bullet)
        {
            for (int i = 0; i < spawnAmount; i++)
            {
                spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                spawnedBullet.transform.rotation = transform.rotation *= Quaternion.Euler(0, 0, (360 / spawnAmount));
            }
        }
    }

    private void FireLasers()
    {
        List<GameObject> selectedObjects = new List<GameObject>(lasers);

        for (int i = 0; i < 3; i++)
        {
            int index = Random.Range(0, selectedObjects.Count);
            GameObject obj = selectedObjects[index];
            selectedObjects.RemoveAt(index);

            obj.GetComponent<Laser>().Fire();
        }
    }

    private void SpawnEnemies()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector2 localPosition = new Vector2(Random.Range(-4, 4), Random.Range(-4, 4));
            Vector2 worldPosition = transform.TransformPoint(localPosition);

            Instantiate(enemies[Random.Range(0, enemies.Length)], worldPosition, Quaternion.identity);
        }
    }

    private void SpawnRockets()
    {
        for (int i = 0; i < 3; i++)
        {
            Vector2 localPosition = new Vector2(player.transform.position.x - Random.Range(-2, 2), player.transform.position.y - Random.Range(-2, 2));

            Instantiate(rocket, localPosition, Quaternion.identity);
        }
    }
}
