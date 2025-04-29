using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IneractionItem : MonoBehaviour
{
    public string itemName;
    public int MaxStack = 16;
    public Sprite icon;
    public string description;
    public GameObject prefab;
    public int HealAmount;
    public int OxygenAmount;
    public int OxygenUpgrade;
    public bool hasHoldingItem;
    public bool hasHoldingItemWhenClicked;
    public GameObject holdingItem;
}
