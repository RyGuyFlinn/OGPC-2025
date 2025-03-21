using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject player;
    public SeagulNado seagulNado;
    public GameObject bossbar;
    public GameObject boss;

    private GameObject[] enemies;

    void Start()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        for (int i = 0; i < enemies.Length; i++)
        {
            Destroy(enemies[i].gameObject);
        }

        Time.timeScale = 0;
        seagulNado.isFighting = false;
        boss.SetActive(false);
        bossbar.SetActive(false);
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
