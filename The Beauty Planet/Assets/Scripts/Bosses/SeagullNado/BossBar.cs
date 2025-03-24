using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossBar : MonoBehaviour
{
    public Shake shake;
    public int StageOneMaxHealth = 100;
    public int StageTwoMaxHealth = 100;
    public int currentHealth;
    public int stage = 1;
    public SeagulNado seagulNado;

    //Gets HealthBar Script
    public BossBar1 healthBar;

    void Start()
    {
        //Sets health to max
        currentHealth = StageOneMaxHealth;
        healthBar.SetMaxHealth(StageOneMaxHealth);
    }

    void Update()
    {
        seagulNado.currentStage = stage;
        if (currentHealth <= 0)
        {
            if (stage == 1)
            {
                stage = 2;
                seagulNado.currentStage = 2;
                currentHealth = StageTwoMaxHealth;
                healthBar.SetMaxHealth(StageTwoMaxHealth);
                shake.start = true;
            }
            else if (stage == 2)
            {
                SceneManager.LoadScene("WishlistScreen");
            }
        }
    }

    //Takes health away
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }
    
}
