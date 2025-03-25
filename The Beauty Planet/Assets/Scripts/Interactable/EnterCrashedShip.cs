using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnterCrashedShip : MonoBehaviour
{
    private GameObject player;
    public GameObject label;
    public float Xpos;
    public float Ypos;

    public GameObject ship;
    private SpriteRenderer shipRenderer;
    public Sprite unselected;
    public Sprite selected;
    void Start()
    {
        shipRenderer = ship.gameObject.GetComponent<SpriteRenderer>();
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
            shipRenderer.sprite = selected;
            label.SetActive(true);
            player = collider.gameObject;
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {
        if (collider.tag == "Player")
        {
            shipRenderer.sprite = unselected;
            player = null;
            label.SetActive(false);
        }
    }
}