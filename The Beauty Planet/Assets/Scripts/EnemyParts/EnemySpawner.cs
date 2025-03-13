using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int SpawnNumber = 1;
    public GameObject[] Enemies;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            StartCoroutine(SpawnEnemy());
        }
    }

    IEnumerator SpawnEnemy()
    {
        for (int i = 0; i < SpawnNumber; i++)
        {
            yield return new WaitForSeconds(Random.Range(0, 1.5f));
            Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform.position, Enemies[Random.Range(0, Enemies.Length)].transform.rotation);
        }
    }
}
