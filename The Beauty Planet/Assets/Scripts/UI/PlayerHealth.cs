using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
    public float currentHealth;
    public bool HealthUpgrade;

    //Gets HealthBar Script
    public Healthbar healthBar;
    public PlayerOxygen oxygen;
    public GameObject deathScreen;

    public GameObject hurtOverlay;
    
    //Time Variables for health deprectiation
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
        //if (Input.GetKeyDown(KeyCode.Space))
        //{
        //    TakeDamage(20);
        //}
        if (currentHealth <= 0)
        {
            deathScreen.SetActive(true);
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
        
        if (HealthUpgrade)
        {
            maxHealth = 250;
        }
        else
        {
            maxHealth = 100;
        }
    }

    IEnumerator hurt()
    {

        Color imagecolor = hurtOverlay.GetComponent<Image>().color;

        hurtOverlay.GetComponent<Image>().color = new Color(imagecolor.r, imagecolor.g, imagecolor.b, Mathf.Lerp(imagecolor.a, 0.5f, 0.75f));
        yield return new WaitForSeconds(0.5f);
        hurtOverlay.GetComponent<Image>().color = new Color(imagecolor.r, imagecolor.g, imagecolor.b, Mathf.Lerp(imagecolor.a, 0.0f, 0.75f));
    }

    //Takes health away
    public void TakeDamage(float damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);

        StartCoroutine(hurt());
    }

    public void RaiseHealth(float amount)
    {
        currentHealth += amount;
        healthBar.SetHealth(currentHealth);
    }

    public void resetHealth()
    {
        currentHealth = maxHealth;
        healthBar.SetHealth(currentHealth);
    }

}
