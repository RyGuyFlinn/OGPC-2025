using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public GameObject hotbar;
    public GameObject selectedButton;

    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;

    public Image slotOneTexture;
    public Image slotTwoTexture;
    public Image slotThreeTexture;

    public TextMeshProUGUI slotOneQuantity;
    public TextMeshProUGUI slotTwoQuantity;
    public TextMeshProUGUI slotThreeQuantity;

    public int hasItem(GameObject Item, int quantity)
    {
        int ItemQuantity = hotbar.GetComponent<hotbar>().HasItem(Item);
        return ItemQuantity;
    }

    public void SelectItem()
    {
        slotOneTexture.sprite = selectedButton.GetComponent<CraftingButton>().craftingRecepie[0];
        slotTwoTexture.sprite = selectedButton.GetComponent<CraftingButton>().craftingRecepie[1];
        slotThreeTexture.sprite = selectedButton.GetComponent<CraftingButton>().craftingRecepie[2];
    
        slotOneQuantity.text = selectedButton.GetComponent<CraftingButton>().craftingRecepieQuantities[0].ToString();
        slotTwoQuantity.text = selectedButton.GetComponent<CraftingButton>().craftingRecepieQuantities[1].ToString();
        slotThreeQuantity.text = selectedButton.GetComponent<CraftingButton>().craftingRecepieQuantities[2].ToString();
    
        ItemName.text = selectedButton.GetComponent<CraftingButton>().name.ToString();
        ItemDescription.text = selectedButton.GetComponent<CraftingButton>().description.ToString();
    }

    public void CraftItem()
    {
        hotbar.GetComponent<hotbar>().AddItem(selectedButton.GetComponent<CraftingButton>().Item.gameObject, null);
    }

    void Start()
    {
        SelectItem();
    }
}
