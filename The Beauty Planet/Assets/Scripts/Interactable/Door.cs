using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public bool isOpen = true;
    public GameObject parent;
    public GameObject label;

    private GameObject player;

    void Update()
    {
        parent.GetComponent<Animator>().SetBool("isOpen", isOpen);
        
        if (isOpen)
        {
            parent.GetComponent<BoxCollider2D>().enabled = false;
        }
        else
        {
            parent.GetComponent<BoxCollider2D>().enabled = true;
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player != null)
            {
                isOpen = !isOpen;
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
