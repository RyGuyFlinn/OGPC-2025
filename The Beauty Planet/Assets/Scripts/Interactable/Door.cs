using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public GameObject hotbar;
    public Sprite keycard;
    public GameObject keycardItem;
    public GameObject templateitem;
    public bool isOpen = true;
    public GameObject parent;
    public GameObject label;

    private GameObject player;

    public AudioSource audio;
    public AudioClip openSound;
    public AudioClip closeSound;

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
                if (hotbar.GetComponent<hotbar>().HasItem(keycard) >= 1)
                {
                    //play open sound
                    audio.clip = openSound;
                    audio.Play();

                    isOpen = !isOpen;

                    hotbar.GetComponent<hotbar>().SubItem(keycardItem);
                    hotbar.GetComponent<hotbar>().AddItem(templateitem, null);
                }
            }
        }
    }

    void OnTriggerEnter2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            if (hotbar.GetComponent<hotbar>().HasItem(keycard) >= 1)
            {
                label.SetActive(true);
            }
            player = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            player = null;
            if (hotbar.GetComponent<hotbar>().HasItem(keycard) >= 1)
            {
                label.SetActive(false);
            }
        }
    }
}
