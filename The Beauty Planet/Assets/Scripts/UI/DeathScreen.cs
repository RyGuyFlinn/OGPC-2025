using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject player;
    public SeagulNado seagulNado;
    public Bob bob;
    public GameObject bossbar;
    public GameObject seagullBoss;
    public GameObject bobBoss;

    private GameObject[] enemies;

    void Start()
    {
        Debug.Log("Death");
        seagulNado.isFighting = false;
        bob.isFighting = false;
        seagullBoss.SetActive(false);
        bobBoss.SetActive(false);
        bossbar.SetActive(false);
        bobBoss.GetComponent<BobBossBar>().bossBar.SetActive(false);
        Time.timeScale = 0;

        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }
    }

    public void Respawn()
    {
        player.gameObject.GetComponent<PlayerHealth>().resetHealth();
        player.gameObject.GetComponent<PlayerOxygen>().resetOxegen();
        player.transform.position = new Vector2(204, 64);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
