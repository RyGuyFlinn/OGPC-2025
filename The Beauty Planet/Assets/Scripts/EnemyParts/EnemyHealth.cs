using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int maxHealth;
    public int health;

    public AudioClip hitSound;
    public AudioClip deathSound;
    AudioSource audio;

    void Start()
    {
        health = maxHealth;
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if (health <= 0)
        {
            //deathSound sound
            audio.clip = deathSound;
            audio.Play();

            GetComponent<EnemyDropSystem>().DropItems();
            Destroy(this.gameObject);
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
