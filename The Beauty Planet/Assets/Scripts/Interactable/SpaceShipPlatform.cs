using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;
using UnityEngine.SceneManagement;

public class SpaceShipPlatform : MonoBehaviour
{
    public GameObject label;
    public GameObject hotbar;
    
    [Space]

    public GameObject engineItem;
    public GameObject batteryItem;
    public GameObject glassItem;
    public GameObject panelItem;
    public GameObject finItem;

    [Space]

    public GameObject part1visual;
    public GameObject part2visual;
    public GameObject part3visual;
    public GameObject part4visual;
    public GameObject part5visual;

    [Space]

    public Sprite engine;
    public Sprite battery;
    public Sprite glass;
    public Sprite panel;
    public Sprite fin;

    [Space]

    public Sprite[] platformProgress;

    private SpriteRenderer parentSprite;

    [Space]

    private bool piece1;
    private bool piece2;
    private bool piece3;
    private bool piece4;
    private bool piece5;

    [Space]

    public bool enter = false;
    private float pause = 0;

    // Start is called before the first frame update
    void Start()
    {
        parentSprite = this.transform.parent.gameObject.GetComponent<SpriteRenderer>();
        label.SetActive(false);
        piece1 = false;
        piece2 = false;
        piece3 = false;
        piece4 = false;
        piece5 = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (enter == true)
        {
            if (Input.GetKey(KeyCode.E))
            {
                if (piece1 == false)
                {
                    if (hotbar.GetComponent<hotbar>().HasItem(engine) >= 1)
                    {
                        piece1 = true;
                        hotbar.GetComponent<hotbar>().SubItem(engineItem);
                        part1visual.SetActive(false);
                    }
                }
                if (piece2 == false)
                {
                    if (hotbar.GetComponent<hotbar>().HasItem(battery) >= 1)
                    {
                        piece2 = true;
                        part2visual.SetActive(false);
                        hotbar.GetComponent<hotbar>().SubItem(batteryItem);
                    }
                }
                if (piece3 == false)
                {
                    if (hotbar.GetComponent<hotbar>().HasItem(glass) >= 1)
                    {
                        piece3 = true;
                        hotbar.GetComponent<hotbar>().SubItem(glassItem);
                        part3visual.SetActive(false);
                    }
                }
                if (piece4 == false)
                {
                    if (hotbar.GetComponent<hotbar>().HasItem(panel) >= 1)
                    {
                        piece4 = true;
                        part4visual.SetActive(false);
                        hotbar.GetComponent<hotbar>().SubItem(panelItem);
                    }
                }
                if (piece5 == false)
                {
                    if (hotbar.GetComponent<hotbar>().HasItem(fin) >= 1)
                    {
                        piece5 = true;
                        hotbar.GetComponent<hotbar>().SubItem(finItem);
                        part5visual.SetActive(false);
                    }
                }

            }

            if (piece1 && piece2 && piece3 && piece4 && piece5)
            {
                if (pause == 0)
                {
                    label.SetActive(true);
                }

                if (Input.GetKeyDown(KeyCode.E))
                {
                    SceneManager.LoadScene("Credits");
                }
            }
        }
        int progress = 0;
        if (piece1)
        {
            progress++;
        }
        if (piece2)
        {
            progress++;
        }
        if (piece3)
        {
            progress++;
        }
        if (piece4)
        {
            progress++;
        }
        if (piece5)
        {
            progress++;
        }
        Debug.Log(parentSprite.sprite);
        parentSprite.sprite = platformProgress[progress];
    }
    void OnTriggerEnter2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            enter = true;

            if (piece1 == false)
            {
                part1visual.SetActive(true);
            }
            if (piece2 == false)
            {
                part2visual.SetActive(true);
            }
            if (piece3 == false)
            {
                part3visual.SetActive(true);
            }
            if (piece4 == false)
            {
                part4visual.SetActive(true);
            }
            if (piece5 == false)
            {
                part5visual.SetActive(true);
            }
        }
    }
    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            enter = false;
            part2visual.SetActive(false);
            part1visual.SetActive(false);
            part3visual.SetActive(false);
            part4visual.SetActive(false);
            part5visual.SetActive(false);

            if (piece1 && piece2)
            {
                label.SetActive(false);
            }
        }
    }
}

