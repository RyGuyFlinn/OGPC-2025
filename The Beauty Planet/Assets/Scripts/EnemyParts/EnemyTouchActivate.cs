using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTouchActivate : MonoBehaviour
{
    public GameObject parent;
    public Sprite activeSprite;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            parent.GetComponent<EnemyDashMovement>().dashing = true;
            parent.GetComponent<SpriteRenderer>().sprite = activeSprite;
        }
    }
}
