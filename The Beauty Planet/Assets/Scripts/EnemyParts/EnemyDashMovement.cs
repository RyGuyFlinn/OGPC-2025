using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDashMovement : MonoBehaviour
{
    public float dashWaitTime = 3;
    public int dashForce = 5;
    public bool dashing = true;
    public int damage = 20;

    private GameObject player;
    private Rigidbody2D rgbd;

    private Vector3 dir;


    void Start()
    {
        player = GameObject.Find("Player");
        rgbd = GetComponent<Rigidbody2D>();

        StartCoroutine(Dash());
    }


    IEnumerator Dash()
    {
        while (dashing)
        {
            yield return new WaitForSeconds(dashWaitTime);

            dir = player.transform.position - transform.position;
            dir = dir.normalized;
            rgbd.AddForce(dir * dashForce, ForceMode2D.Impulse);
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
