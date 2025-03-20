using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathScreen : MonoBehaviour
{
    public GameObject player;

    void Start()
    {
        Time.timeScale = 0;
    }

    public void Respawn()
    {
        player.gameObject.GetComponent<PlayerHealth>().resetHealth();
        player.gameObject.GetComponent<PlayerOxygen>().resetOxegen();
        player.transform.position = new Vector2(0, 0);
        gameObject.SetActive(false);
        Time.timeScale = 1;
    }
}
