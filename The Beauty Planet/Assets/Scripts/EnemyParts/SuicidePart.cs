using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicidePart : MonoBehaviour
{
    public int damage = 30;


    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            Destroy(gameObject.transform.parent.gameObject);
        }
        if (other.tag == "Enemy")
        {
            other.gameObject.GetComponent<EnemyHealth>().takeDamage(damage);
            Destroy(gameObject.transform.parent.gameObject);
        }
    }
}
