using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    private GameObject player;

    public AudioClip hitSound;
    public AudioClip deathSound;
    AudioSource audio;
    AudioSource playerAudio;

    void Start()
    {
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

            GetComponent<EnemyDropSystem>().DropItems();
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

        //play hit sound
        audio.clip = hitSound;
        audio.Play();

    }
}
