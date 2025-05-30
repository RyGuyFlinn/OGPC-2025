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

    private bool canDash = true;
    private Vector3 prevPos;
    private SpriteRenderer renderer;


    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        player = GameObject.Find("Player");
        rgbd = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (dashing == true && canDash == true)
        {
            StartCoroutine(Dash());
        }

        if (prevPos.x > transform.position.x + 0.05f)
        {
            renderer.flipX = true;
        }

        if (prevPos.x < transform.position.x - 0.05f)
        {
            renderer.flipX = false;
        }

        prevPos = transform.position;
    }

    IEnumerator Dash()
    {
        canDash = false;
        yield return new WaitForSeconds(dashWaitTime);
        canDash = true;

        dir = player.transform.position - transform.position;
        dir = dir.normalized;
        rgbd.AddForce(dir * dashForce, ForceMode2D.Impulse);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }
}
