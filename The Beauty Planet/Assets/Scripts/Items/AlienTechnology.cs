using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienTechnology : MonoBehaviour
{
    public GameObject item;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Collected Alien Technology!");
            collider.GetComponent<PlayerController>().AddItem(item);
            Destroy(gameObject);
        }
    }
}

