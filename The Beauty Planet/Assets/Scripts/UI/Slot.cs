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
    public GameObject itemToDrop;
    public GameObject holdingItem;
    public bool has_item = false;
    public bool hasHoldingItem = false;

    public TextMeshProUGUI quantityLabel;
    public int quantity = 0;
    public string item_name;

    void Update()
    {
        if (hasHoldingItem == true)
        {
            if (selected == false)
            {
                holdingItem.SetActive(false);
            }
            else
            {
                holdingItem.SetActive(true);
            }
        }
        //Change the quantity label
        quantityLabel.text = "x" + quantity.ToString();

        //Change the quantity label's visiblity based on the quanity if it is 0
        if (quantity <= 1)
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

        texture.sprite = ItemToAdd.GetComponent<IneractionItem>().icon;
        itemToDrop = Instantiate(itemToDrop, this.transform.position, this.transform.rotation);
        itemToDrop.SetActive(false);

        if (currentItem.GetComponent<IneractionItem>().hasHoldingItem == true)
        {
            GameObject item = currentItem.GetComponent<IneractionItem>().holdingItem.gameObject;
            holdingItem = Instantiate(item);
            hasHoldingItem = true;
            Debug.Log("Here is the Blaser game objcet " + item);
        }
        else{
            Debug.Log("No Holding Item");
        }
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
            hasHoldingItem = false;
            Destroy(itemToDrop.gameObject);
            Destroy(holdingItem.gameObject);
            itemToDrop = null;
        }
        else
        {
            quantity -= 1;
            
        }
    }
}
