using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 5;
    public int damage = 25;
    public int peircingLevel = 1;

    // Update is called once per frame
    void Update()
    {
        transform.position += transform.right * Time.deltaTime * speed;

        if (peircingLevel <= 0)
        {
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Enemy")
        {
            if (col.GetComponent<EnemyHealth>() == null)
            {
                col.GetComponent<EnemyHideHealth>().takeDamage(damage);
                peircingLevel--;
            }
            else
            {
                col.GetComponent<EnemyHealth>().takeDamage(damage);
                peircingLevel--;
            }
        }
        if (col.tag == "Enviroment")
        {
            Destroy(this.gameObject);
        }
        if (col.tag == "Boss")
        {
            col.gameObject.GetComponent<BossBar>().TakeDamage(damage);
            peircingLevel--;
        }
        if (col.tag == "Bob")
        {
            col.gameObject.GetComponent<BobBossBar>().TakeDamage(damage);
            peircingLevel--;
        }
    }
}
