using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WorkBench : MonoBehaviour
{
    private GameObject player;

    public GameObject CraftingUI;
    public GameObject label;

    void Start()
    {
        label.SetActive(false);
        CraftingUI.SetActive(false);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if (player != null)
            {
                // Open Crafting UI
                CraftingUI.SetActive(!CraftingUI.active);
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
