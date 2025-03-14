using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEnemySpawner : MonoBehaviour
{
    public int SpawnNumber = 1;
    public GameObject[] Enemies;
    public int TeamNumber = 1;

    private GameObject Enemy;

    void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {
            for (int i = 0; i < SpawnNumber; i++)
            {
                Enemy = Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform.position, Enemies[Random.Range(0, Enemies.Length)].transform.rotation);
                Enemy.GetComponent<MainMenuEnemyMove>().GetTarget();
                Enemy.GetComponent<MainMenuEnemyMove>().TeamNumber = TeamNumber;
            }
            yield return new WaitForSeconds(2);
        }
    }
}
