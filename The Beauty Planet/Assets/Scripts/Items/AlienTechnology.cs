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
            collider.GetComponent<PlayerController>().AddItem(item, this.gameObject);
        }
    }
}

