using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public bool selected = false;

    public Sprite unSelected;
    public Sprite Selected;

    public Image texture;
    public GameObject currentItem;

    void Update()
    {

        // Changes Texture based on if the slot is selected or not
        if (selected == false)
        {
            GetComponent<Image>().sprite = unSelected;
            
        }
        else
        {
            GetComponent<Image>().sprite = Selected;
        }
    }

    public void AddItem(GameObject ItemToAdd)
    {
        
        var image = texture.GetComponent<Image>();
        var tempColor = image.color;
        tempColor.a = 1f;
        image.color = tempColor;
        
        currentItem = ItemToAdd;
        texture.sprite = ItemToAdd.GetComponent<IneractionItem>().icon;
    }
}
