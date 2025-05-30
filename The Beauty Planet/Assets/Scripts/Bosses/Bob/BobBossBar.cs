using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class BobBossBar : MonoBehaviour
{
    public Shake shake;
    public int StageOneMaxHealth = 100;
    public int StageTwoMaxHealth = 100;
    public int currentHealth;
    public int stage = 1;
    public Bob bob;
    public TMP_Text titleText;
    public Door door;
    public DoorClose doorClose;
    public GameObject bossBar;

    //Gets HealthBar Script
    public BossBar1 healthBar;

    void Start()
    {
        //Sets health to max
        currentHealth = StageOneMaxHealth;
        healthBar.SetMaxHealth(StageOneMaxHealth);
        titleText.text = "Bob";
    }

    void Update()
    {
        bob.currentStage = stage;
        if (currentHealth <= 0)
        {
            if (stage == 1)
            {
                stage = 2;
                bob.currentStage = 2;
                currentHealth = StageTwoMaxHealth;
                healthBar.SetMaxHealth(StageTwoMaxHealth);
                shake.start = true;
            }
            else if (stage == 2)
            {
                Die();
            }
        }
    }

    //Takes health away
    public void TakeDamage(int damage)
    {
        currentHealth -= damage;
        healthBar.SetHealth(currentHealth);
    }

    public void Die()
    {
        shake.start = true;
        GetComponent<EnemyDropSystem>().DropItems();
        door.isOpen = true;
        bob.isFighting = false;
        doorClose.beaten = true;
        bossBar.SetActive(false);
        Destroy(gameObject);
    }
}