using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int SpawnNumber = 1;
    public GameObject[] Enemies;
    private bool active = true;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        if (active)
        {
            active = false;
            for (int i = 0; i < SpawnNumber; i++)
            {
                Instantiate(Enemies[Random.Range(0, Enemies.Length)], 
                transform.position, 
                Enemies[Random.Range(0, Enemies.Length)].transform.rotation);
                yield return new WaitForSeconds(Random.Range(0, 1.5f));
                
            }
            StartCoroutine(Cooldown());
        }
    }

    IEnumerator Cooldown()
    {
        yield return new WaitForSeconds(120);
        active = true;
    }
}
