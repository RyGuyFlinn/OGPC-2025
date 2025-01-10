using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //Gets HealthBar Script
    public Healthbar healthBar;
    public PlayerOxygen oxygen;
    public float time;
    public int prevtime;
    void Start()
    {
        //Sets health to max
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        
        oxygen.currentOxygen = 100;
    }


    void Update()
    {

        //Just testing if damage works
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }
        
        //Starts taking damage if oxygen is out
        if (oxygen.currentOxygen <= 0)
        {
            time += Time.deltaTime;
                  int itime = (int)time;
                    Debug.Log(itime);
            if (prevtime != itime)
            {
                TakeDamage(10);
            }
            prevtime = itime;

        }
        else
        {
            time = 0;
            prevtime = 0;
            
        }
    }
    //Takes health away
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    
}
