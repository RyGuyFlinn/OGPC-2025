using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hotbar : MonoBehaviour
{

    public GameObject[] inventory;
    public GameObject[] slots;

    public int selected = 1;

    // Update is called once per frame
    void Update()
    {

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
            slots[1].GetComponent<Slot>().selected = true;
       } else {
            slots[1].GetComponent<Slot>().selected = false;
       }

       if (selected == 2) {
            slots[2].GetComponent<Slot>().selected = true;
       } else {
            slots[2].GetComponent<Slot>().selected = false;
       }

       if (selected == 3) {
            slots[3].GetComponent<Slot>().selected = true;
       } else {
            slots[3].GetComponent<Slot>().selected = false;
       }

       if (selected == 4) {
            slots[4].GetComponent<Slot>().selected = true;
       } else {
            slots[4].GetComponent<Slot>().selected = false;
       }

       if (selected == 5) {
            slots[5].GetComponent<Slot>().selected = true;
       } else {
            slots[5].GetComponent<Slot>().selected = false;
       }

       if (selected == 6) {
            slots[6].GetComponent<Slot>().selected = true;
       } else {
            slots[6].GetComponent<Slot>().selected = false;
       }
    }
}
