using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDropSystem : MonoBehaviour
{
    public int spawnAmount = 1;
    public GameObject[] drops;

    public void DropItems()
    {
        for (int i = 0; i < spawnAmount; i++)
        {
            Instantiate(drops[Random.Range(0, drops.Length)], transform.position, drops[Random.Range(0, drops.Length)].transform.rotation);
        }
    }
}
