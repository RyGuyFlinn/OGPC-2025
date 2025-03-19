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

    enum State { Idle, HomingSeagul, Rockets, Minions, Lasers }
    private State currentState;

    private GameObject spawnedBullet;
    private GameObject player;
    private float timer = 0f;

    void Start()
    {
        currentState = State.Idle; // Start in Idle state
        player = GameObject.Find("Player");
    }

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetKeyDown("space"))
        {
            currentState = State.Lasers;
        }

        switch (currentState)
        {
            case State.Idle:
                
                break;

            case State.HomingSeagul:
                if (timer >= firingRate)
                {
                    FireHomming();
                    timer = 0;
                }
                StartCoroutine(goToIdle());
                break;

            case State.Rockets:
                
                break;

            case State.Minions:

                break;

            case State.Lasers:
                FireLasers();
                StartCoroutine(goToIdle());
                break;
        }
    }

    private IEnumerator goToIdle()
    {
        yield return new WaitForSeconds(1f); // Adjust delay if needed
        currentState = State.Idle;
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
}
