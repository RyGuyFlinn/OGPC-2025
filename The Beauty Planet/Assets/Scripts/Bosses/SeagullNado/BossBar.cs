using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class BossBar : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;

    //Gets HealthBar Script
    public Healthbar healthBar;

    public GameObject hurtOverlay;
    
    //Time Variables for health deprectiation
    public float time;
    public int prevtime;

    void Start()
    {
        //Sets health to max
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    //Takes health away
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    
}
