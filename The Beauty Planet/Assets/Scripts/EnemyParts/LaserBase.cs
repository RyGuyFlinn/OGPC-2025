using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserBase : MonoBehaviour
{
    public float damage = 20;
    public bool canHurt = false;

    void OnTriggerStay2D(Collider2D col)
    {
        if (col.tag == "Player" && canHurt == true)
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
