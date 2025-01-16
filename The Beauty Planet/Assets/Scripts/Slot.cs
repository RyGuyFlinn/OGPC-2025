using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Slot : MonoBehaviour
{
    public bool selected = false;

    public Sprite unSelected;
    public Sprite Selected;

    public Image texture;
    public GameObject currentItem;
    public GameObject prefab;
    public bool has_item = false;

    public TextMeshProUGUI quantityLabel;
    public int quantity = 0;
    public string item_name;

    void Update()
    {
        //Change the quantity label
        quantityLabel.text = "x" + quantity.ToString();

        //Change the quantity label's visiblity based on the quanity if it is 0
        if (quantity <= 0)
        {
            quantityLabel.gameObject.SetActive(false);
        }
        else
        {
            quantityLabel.gameObject.SetActive(true);
        }

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
        has_item = true;
        quantity += 1;

        var interactionItem = ItemToAdd.GetComponent<IneractionItem>();
        GameObject prefab = interactionItem.prefab;
        Debug.Log(prefab);
        texture.sprite = ItemToAdd.GetComponent<IneractionItem>().icon;
    }

    public void RemoveItem()
    {
        if (quantity <= 1)
        {
            var image = texture.GetComponent<Image>();
            var tempColor = image.color;
            tempColor.a = 0f;
            image.color = tempColor;

            quantity = 0;
            currentItem = null;
            has_item = false;
            texture.sprite = null;
            //prefab = null;
        }
        else
        {
            quantity -= 1;
        }
    }
}
