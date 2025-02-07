using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CraftingButton : MonoBehaviour
{
    public string name = "";
    public string description = "";
    public Sprite[] craftingRecepie;
    public int[] craftingRecepieQuantities;

    public GameObject Item;

    private CraftingManager craftingManager;
    
    void Start()
    {
        craftingManager = GameObject.Find("CraftingUI").GetComponent<CraftingManager>();
    }

    public void OnPress()
    {
        craftingManager.selectedButton = this.gameObject;
        craftingManager.SelectItem();
    }

}
