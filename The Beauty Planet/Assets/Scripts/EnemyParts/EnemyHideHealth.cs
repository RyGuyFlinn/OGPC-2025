using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHideHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    private GameObject player;
    private GameObject seagullNado;

    public float timeSinceHit = 400;
    private SpriteRenderer renderer;
    public Sprite hidden;
    public Sprite peek;
    public Sprite open;

    public AudioClip hitSound;
    public AudioClip deathSound;
    AudioSource audio;
    AudioSource playerAudio;

    void Start()
    {
        renderer = GetComponent<SpriteRenderer>();
        seagullNado = GameObject.Find("SeagullNado");
        player = GameObject.Find("Player");
        health = maxHealth;
        audio = GetComponent<AudioSource>();
        playerAudio = player.gameObject.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //deathSound play
            playerAudio.clip = deathSound;
            playerAudio.Play();

            if (!(transform.position.x < 100 && Mathf.Abs(transform.position.y + 66) < 10))
            {
                GetComponent<EnemyDropSystem>().DropItems();
            }
            Destroy(this.gameObject);
        }

        //when too far away from player, despawn
        if (Vector3.Distance(transform.position, player.transform.position) > 80)
        {
            Destroy(gameObject);
        }
    }

    void FixedUpdate()
    {
        timeSinceHit += 1;
        if (timeSinceHit < 200)
        {
            renderer.sprite = hidden;
        }
        else if (timeSinceHit < 400)
        {
            renderer.sprite = peek;
        }
        else
        {
            renderer.sprite = open;
        }
    }

    public void takeDamage(int damage)
    {
        if (timeSinceHit > 400 || Vector3.Distance(transform.position, player.transform.position) <= 3.5f)
        {
            Debug.Log(Vector3.Distance(transform.position, player.transform.position) + " is less than 3.5");
            health -= damage;

            if (GetComponent<EnemyDashMovement>() != null)
            {
                GetComponent<EnemyDashMovement>().dashing = true;
                GetComponent<SpriteRenderer>().sprite = GetComponentInChildren<EnemyTouchActivate>().activeSprite;
            }

            //play hit sound
            audio.clip = hitSound;
            audio.Play();
        }

        timeSinceHit = 0;
    }
}
