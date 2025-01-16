using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject item;

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            Debug.Log("Collected a Rock!");
            collider.GetComponent<PlayerController>().AddItem(item);
            Destroy(gameObject);
        }
    }
}
