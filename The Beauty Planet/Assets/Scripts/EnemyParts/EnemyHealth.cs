using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    void Start()
    {
        health = maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            GetComponent<EnemyDropSystem>().DropItems();
            Destroy(this.gameObject);
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }
}
