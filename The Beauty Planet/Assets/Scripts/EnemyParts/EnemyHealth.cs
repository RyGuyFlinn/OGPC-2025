using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    private GameObject player;
    private GameObject seagullNado;

    public AudioClip hitSound;
    public AudioClip deathSound;
    AudioSource audio;
    AudioSource playerAudio;

    void Start()
    {
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

    public void takeDamage(int damage)
    {
        health -= damage;

        if (GetComponentInChildren<EnemyTouchActivate>() != null)
        {
            GetComponent<EnemyDashMovement>().dashing = true;
            GetComponent<SpriteRenderer>().sprite = GetComponentInChildren<EnemyTouchActivate>().activeSprite;
        }

        //play hit sound
        audio.clip = hitSound;
        audio.Play();

    }
}
