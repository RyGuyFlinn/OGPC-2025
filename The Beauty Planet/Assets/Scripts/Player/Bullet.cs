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
        if (col.tag == "Enemy")
        {
            if (col.GetComponent<EnemyHealth>() == null)
            {
                col.GetComponent<EnemyHideHealth>().takeDamage(damage);
                Destroy(this.gameObject);
            }
            else
            {
                col.GetComponent<EnemyHealth>().takeDamage(damage);
                Destroy(this.gameObject);
            }
        }
        if (col.tag == "Enviroment")
        {
            Destroy(this.gameObject);
        }
        if (col.tag == "Boss")
        {
            col.gameObject.GetComponent<BossBar>().TakeDamage(damage);
            Destroy(this.gameObject);
        }
        //Changed the tag so players bullets don't collde with each other.
        if (col.tag == "EnemyBullet")
        {
            Destroy(col.gameObject);
            Destroy(this.gameObject);
        }
    }
}
