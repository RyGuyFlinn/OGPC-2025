using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public int damage = 25;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag != "Player")
        {
            if (col.tag != "Item")
            {
                if (col.tag == "Enemy")
                {
                    col.GetComponent<EnemyHealth>().takeDamage(damage);
                    Destroy(this.gameObject);
                }

                Destroy(this.gameObject);
            }
        }
    }
}
