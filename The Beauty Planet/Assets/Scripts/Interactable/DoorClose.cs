using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorClose : MonoBehaviour
{
    public Door door;
    public GameObject boss;
    public GameObject bossbar;
    public bool bob;

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            //play slam sound
            door.audio.clip = door.closeSound;
            door.audio.Play();

            door.isOpen = false;
            boss.SetActive(true);
            bossbar.SetActive(true);
            if (bob)
            {
                boss.GetComponent<Bob>().isFighting = true;
            }
            else
            {
                boss.GetComponent<SeagulNado>().isFighting = true;
            }
        }
    }
}
