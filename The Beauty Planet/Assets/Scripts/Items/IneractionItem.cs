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
    public bool isInteractable;
    public bool hasHoldingItem;
    public GameObject holdingItem;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
