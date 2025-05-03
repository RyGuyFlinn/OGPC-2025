using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMelee : MonoBehaviour
{
    public int damage = 10;
    private float attack;
    private Animator animator;

    public bool canAttack = true;

    void Start()
    {
        animator = gameObject.transform.parent.gameObject.GetComponent<Animator>();
    }

    void Update()
    {
        animator.SetFloat("attack", attack);
        if (attack > 0)
        {
            attack += -0.05f;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            if (canAttack == true)
            {
                other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
                attack = 1;
            }
        }
    }
}
