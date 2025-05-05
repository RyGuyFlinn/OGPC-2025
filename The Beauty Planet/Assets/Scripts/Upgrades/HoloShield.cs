using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoloShield : MonoBehaviour
{
    void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("collided with" + other + ", " + other.tag);
        if (other.tag == "EnemyBullet")
        {
            Destroy(other.gameObject);
        }
    }
}
