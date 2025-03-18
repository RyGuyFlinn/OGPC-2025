using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuEnemySpawner : MonoBehaviour
{
    public GameObject[] Enemies;

    private float time = 0.0f;
    public float interpolationPeriod =  1.0f;
    private GameObject enemy;

    void Update () {
        time += Time.deltaTime;

        if (time >= interpolationPeriod) {
            time = 0.0f;

            enemy = Instantiate(Enemies[Random.Range(0, Enemies.Length)], transform.position, Enemies[Random.Range(0, Enemies.Length)].transform.rotation);
                    
        }
    }
}
