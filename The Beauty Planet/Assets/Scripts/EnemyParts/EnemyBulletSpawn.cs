using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBulletSpawn : MonoBehaviour
{
    enum SpawnerType { Straight, Spin }


    [Header("Bullet Attributes")]
    public GameObject bullet;
    public float bulletLife = 1f;
    public float speed = 1f;


    [Header("Spawner Attributes")]
    [SerializeField] private SpawnerType spawnerType;
    [SerializeField] private float firingRate = 1f;
    [SerializeField] private float speedSpeed = 1f;
    [SerializeField] private int spawnAmount = 1;

    private GameObject spawnedBullet;
    private GameObject player;
    private float timer = 0f;
    // Start is called before the first frame update
    void Start()
    {
       player = GameObject.Find("Player");
    }


    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if(spawnerType == SpawnerType.Spin) transform.eulerAngles = new Vector3(0f,0f,transform.eulerAngles.z+speedSpeed);
        
        if(spawnerType == SpawnerType.Straight)
        {
            Vector2 direction = player.transform.position - transform.position;
            transform.rotation = Quaternion.FromToRotation(Vector3.up, direction);
            transform.rotation *= Quaternion.Euler(0, 0, 90);
        }

        if(timer >= firingRate) {
            FireHomming();
            timer = 0;
        }
    }


    private void Fire() {
        if(bullet) {
            for (int i = 0; i < spawnAmount; i++)
            {
                spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                spawnedBullet.GetComponent<EnemyBullet>().speed = speed;
                spawnedBullet.GetComponent<EnemyBullet>().bulletLife = bulletLife;
                spawnedBullet.transform.rotation = transform.rotation  *= Quaternion.Euler(0, 0, (360 / spawnAmount));
            }      
        }
    }

    private void FireHomming() {
        if(bullet) {
            for (int i = 0; i < spawnAmount; i++)
            {
                spawnedBullet = Instantiate(bullet, transform.position, Quaternion.identity);
                spawnedBullet.transform.rotation = transform.rotation  *= Quaternion.Euler(0, 0, (360 / spawnAmount));
            }      
        }
    }
}

