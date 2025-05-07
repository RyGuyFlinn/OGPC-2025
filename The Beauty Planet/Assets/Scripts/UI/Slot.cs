using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using Unity.VisualScripting;

public class Slot : MonoBehaviour
{
    public bool selected = false;

    public int slotNumber;

    public Sprite unSelected;
    public Sprite Selected;

    public Image texture;
    public GameObject currentItem;
    public GameObject itemToDrop;
    public GameObject holdingItem;
    public bool has_item = false;
    public bool hasHoldingItem = false;
    public bool hasHoldingItemWhenClicked = false;

    public TextMeshProUGUI quantityLabel;
    public int quantity = 0;

    public float HealAmount;
    public int OxygenAmount;
    public int OxygenUpgrade;
    public bool HealthUpgrade;

    public string item_name;

    public bool crafting = false;

    void Update()
    {
        if (holdingItem != null)
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

            else if (hasHoldingItemWhenClicked == true)
            {
                if (selected == false)
                {
                    holdingItem.SetActive(false);
                }
                else
                {
                    if (Input.GetMouseButton(0))
                    {
                        holdingItem.SetActive(true);
                    }
                    else
                    {
                        holdingItem.SetActive(false);
                    }
                }
            }
        }

        crafting = GameObject.Find("WorkBenchCollider").gameObject.GetComponent<WorkBench>().crafting;

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

            if (Input.GetMouseButtonDown(0))
            {
                if (crafting == false)
                {
                    if (HealAmount > 0)
                    {
                        GameObject.Find("Player").GetComponent<PlayerHealth>().RaiseHealth(HealAmount);
                        RemoveItem();
                    }
                    if (OxygenAmount > 0)
                    {
                        GameObject.Find("Player").GetComponent<PlayerOxygen>().RaiseOxygen(OxygenAmount);
                        RemoveItem();
                    }
                    if (OxygenUpgrade > GameObject.Find("Player").GetComponent<PlayerOxygen>().upgradeLevel)
                    {
                        GameObject.Find("Player").GetComponent<PlayerOxygen>().upgradeLevel = OxygenUpgrade;
                        GameObject.Find("Player").GetComponent<PlayerOxygen>().upgradeOxygen();
                    }
                    if (HealthUpgrade)
                    {
                        GameObject.Find("Player").GetComponent<PlayerHealth>().HealthUpgrade = HealthUpgrade;
                        GameObject.Find("Player").GetComponent<PlayerHealth>().UpgradeHealth();
                    }
                }
            }
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
        gameObject.GetComponent<Window>().itemText = ItemToAdd.GetComponent<IneractionItem>().itemName;

        HealAmount = ItemToAdd.GetComponent<IneractionItem>().HealAmount;
        OxygenAmount = ItemToAdd.GetComponent<IneractionItem>().OxygenAmount;
        OxygenUpgrade = ItemToAdd.GetComponent<IneractionItem>().OxygenUpgrade;
        HealthUpgrade = ItemToAdd.GetComponent<IneractionItem>().HealthUpgrade;

        itemToDrop = Instantiate(itemToDrop, this.transform.position, this.transform.rotation);
        itemToDrop.SetActive(false);

        if (currentItem.GetComponent<IneractionItem>().hasHoldingItem == true)
        {
            GameObject item = currentItem.GetComponent<IneractionItem>().holdingItem.gameObject;
            holdingItem = Instantiate(item);
            hasHoldingItem = true;
        }
        if (currentItem.GetComponent<IneractionItem>().hasHoldingItemWhenClicked == true)
        {
            GameObject item = currentItem.GetComponent<IneractionItem>().holdingItem.gameObject;
            holdingItem = Instantiate(item);
            holdingItem.SetActive(false);
            hasHoldingItemWhenClicked = true;
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
            HealAmount = 0;
            OxygenAmount = 0;
            has_item = false;
            texture.sprite = null;

            gameObject.GetComponent<Window>().itemText = "";

            if (itemToDrop != null)
            {
                Destroy(itemToDrop.gameObject);
                itemToDrop = null;
            }

            if (holdingItem != null)
            {
                Destroy(holdingItem.gameObject);
                holdingItem = null;
            }

            hasHoldingItem = false;
        }
        else
        {
            quantity -= 1;
        }
    }

    public void OnButtonPressed()
    {
        GameObject.Find("HotBar").gameObject.GetComponent<hotbar>().selected = slotNumber;
    }
}
