using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public int currentHealth;
    //Gets HealthBar Script
    public Healthbar healthBar;
    public PlayerOxygen oxygen;
    void Start()
    {
        //Sets health to max
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
        StartCoroutine(OxygenDamage());
    }


    void Update()
    {
        //Just testing if damage works
        if (Input.GetKeyDown(KeyCode.Space))
        {
            TakeDamage(20);
        }

      
    }
    //Takes health away
    void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    IEnumerator OxygenDamage()
    {
        while (true)
        {
            if (oxygen.currentOxygen <= 0)
            {

                yield return new WaitForSeconds(1.0f);
                TakeDamage(10);
            }
        }
    }
}
