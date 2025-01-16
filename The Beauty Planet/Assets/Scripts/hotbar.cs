using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotbar : MonoBehaviour
{

    public GameObject[] slots;
    public GameObject player;

    public GameObject ItemPrefab;

    public int selected = 1;

    private bool added_item = false;

    public void AddItem(GameObject ItemToAdd, GameObject ItemParent)
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (added_item == false)
            {
                if (slots[i].GetComponent<Slot>().has_item == false)
                {
                    slots[i].GetComponent<Slot>().AddItem(ItemToAdd);
                    added_item = true;
                }
                else
                {
                    if (slots[i].GetComponent<Slot>().quantity < ItemToAdd.GetComponent<IneractionItem>().MaxStack)
                    {

                        if (slots[i].GetComponent<Slot>().texture.sprite == ItemToAdd.GetComponent<IneractionItem>().icon)
                            if (slots[i].GetComponent<Slot>().quantity < ItemToAdd.GetComponent<IneractionItem>().MaxStack)
                                {
                                slots[i].GetComponent<Slot>().AddItem(ItemToAdd);
                                added_item = true;
                            }
                    }
                }
            }   
        }
        if (added_item == true)
        {
            player.GetComponent<PlayerController>().destroyItem(ItemParent.gameObject);
        }
        added_item = false;
    }

    public void DropItem()
    {
        for (int i = 0; i < slots.Length; i++)
        {
            if (slots[i].GetComponent<Slot>().selected == true)
            {
                ItemPrefab = slots[i].GetComponent<Slot>().prefab;
                Debug.Log(ItemPrefab);
                slots[i].GetComponent<Slot>().RemoveItem();
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            DropItem();
        }

        //Changing what slot is selected with keyboard
        if (Input.GetKeyDown("1"))
        {
            selected = 1;
        }
        if (Input.GetKeyDown("2"))
        {
            selected = 2;
        }
        if (Input.GetKeyDown("3"))
        {
            selected = 3;
        }
        if (Input.GetKeyDown("4"))
        {
            selected = 4;
        }
        if (Input.GetKeyDown("5"))
        {
            selected = 5;
        }
        if (Input.GetKeyDown("6"))
        {
            selected = 6;
        }

        //Changing what slot is selected with mouse wheel
        if (Input.GetAxis("Mouse ScrollWheel") > 0f ) // forward
        {
            if (selected == 6)
            {
                selected = 1;
            }
            else
            {
                selected += 1;
            }
            
        }
        else if (Input.GetAxis("Mouse ScrollWheel") < 0f ) // backwards
        {
            if (selected == 1)
            {
                selected = 6;
            }
            else
            {
                selected -= 1;
            }
        }


        // Selection Detection
       if (selected == 1) {
            slots[0].GetComponent<Slot>().selected = true;
       } else {
            slots[0].GetComponent<Slot>().selected = false;
       }

       if (selected == 2) {
            slots[1].GetComponent<Slot>().selected = true;
       } else {
            slots[1].GetComponent<Slot>().selected = false;
       }

       if (selected == 3) {
            slots[2].GetComponent<Slot>().selected = true;
       } else {
            slots[2].GetComponent<Slot>().selected = false;
       }

       if (selected == 4) {
            slots[3].GetComponent<Slot>().selected = true;
       } else {
            slots[3].GetComponent<Slot>().selected = false;
       }

       if (selected == 5) {
            slots[4].GetComponent<Slot>().selected = true;
       } else {
            slots[4].GetComponent<Slot>().selected = false;
       }

       if (selected == 6) {
            slots[5].GetComponent<Slot>().selected = true;
       } else {
            slots[5].GetComponent<Slot>().selected = false;
       }
    }
}
