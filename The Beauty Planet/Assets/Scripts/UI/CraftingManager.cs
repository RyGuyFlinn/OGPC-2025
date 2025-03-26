using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class CraftingManager : MonoBehaviour
{
    public GameObject hotbar;
    public GameObject selectedButton;
    private GameObject player;

    public TextMeshProUGUI ItemName;
    public TextMeshProUGUI ItemDescription;

    public Image slotOneTexture;
    public Image slotTwoTexture;
    public Image slotThreeTexture;

    public TextMeshProUGUI slotOneQuantity;
    public TextMeshProUGUI slotTwoQuantity;
    public TextMeshProUGUI slotThreeQuantity;

    public AudioClip craftSound;

    void Start()
    {
        player = GameObject.Find("Player");
        SelectItem();
    }
    
    public int hasItem(Sprite Item, int quantity)
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
        //Check if player has items to craft
        if (hotbar.GetComponent<hotbar>().HasItem(slotOneTexture.sprite) >= int.Parse(slotOneQuantity.text))
        {
            if (hotbar.GetComponent<hotbar>().HasItem(slotTwoTexture.sprite) >= int.Parse(slotTwoQuantity.text))
            {
                Debug.Log("Craft");

                //play craft sound
                AudioSource playerAudio = player.gameObject.AddComponent<AudioSource>();
                playerAudio.clip = craftSound;
                playerAudio.Play();

                // subtract the items from the player inventory
                for (int i = 0; i <= int.Parse(slotOneQuantity.text); i++)
                {
                    hotbar.GetComponent<hotbar>().SubItem(selectedButton.GetComponent<CraftingButton>().craftingRecepieItems[0]);
                }

                for (int i = 0; i <= int.Parse(slotTwoQuantity.text); i++)
                {
                    hotbar.GetComponent<hotbar>().SubItem(selectedButton.GetComponent<CraftingButton>().craftingRecepieItems[1]);
                }

                if (hotbar.GetComponent<hotbar>().HasItem(null) == 0 
                && hotbar.GetComponent<hotbar>().HasItem(selectedButton.GetComponent<CraftingButton>().craftingRecepie[2]) == 0)
                {
                    player.GetComponent<PlayerController>().dropItem((selectedButton.GetComponent<CraftingButton>().Item).gameObject.GetComponent<IneractionItem>().prefab);
                }
                else
                {
                    hotbar.GetComponent<hotbar>().AddItem(selectedButton.GetComponent<CraftingButton>().Item.gameObject, null);
                }

            }
            else
            {
                player.gameObject.GetComponent<PlayerController>().FailSound();
            }
        }
        else
        {
            player.gameObject.GetComponent<PlayerController>().FailSound();
        }
    }

    
}
