using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public Door door;
    public GameObject boss;
    public GameObject bossbar;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            door.isOpen = false;
            boss.SetActive(true);
            bossbar.SetActive(true);
            boss.GetComponent<SeagulNado>().isFighting = true;
        }
    }
}
