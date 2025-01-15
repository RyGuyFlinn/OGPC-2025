using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool selected = false;

    public Sprite unSelected;
    public Sprite Selected;

    void Update()
    {
        if (selected == false)
        {
            GetComponent<Image>().sprite = unSelected;
            
        }
        else
        {
            GetComponent<Image>().sprite = Selected;
        }
    }
}
