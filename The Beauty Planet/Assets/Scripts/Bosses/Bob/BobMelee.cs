using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BobMelee : MonoBehaviour
{
    public int damage = 10;
    private bool attack;
    public Animator animator;

    public bool canAttack = false;

    void OnTriggerEnter2D(Collider2D other)
    {
        void OnTriggerEnter2D(Collider2D other)
        {
            if (other.tag == "Player")
            {
                Debug.Log("Attack");
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            }
        }
    }
}