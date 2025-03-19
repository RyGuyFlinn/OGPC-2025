using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterNewArea : MonoBehaviour
{
    private GameObject player;
    public GameObject label;
    public float Xpos;
    public float Ypos;
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
                // Teleport Player to specified location
                player.transform.position = new Vector3(Xpos, Ypos, player.transform.position.z);
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
