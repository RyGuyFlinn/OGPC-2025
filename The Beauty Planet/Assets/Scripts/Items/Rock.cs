using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    public GameObject item;
    public GameObject label;

    private GameObject player;

    void Start()
    {
        label.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player != null)
            {
                player.GetComponent<PlayerController>().AddItem(item, this.gameObject);
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            label.SetActive(true);
            player = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            player = null;
            label.SetActive(false);
        }
    }
}
