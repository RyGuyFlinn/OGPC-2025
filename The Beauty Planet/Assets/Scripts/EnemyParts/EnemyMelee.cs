using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public int damage = 10;

    private PlayerHealth health;

    void Start()
    {
        health = GameObject.Find("Player").GetComponent<PlayerHealth>();
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            health.TakeDamage(damage);
        }
    }
}
