using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Map : MonoBehaviour
{
    public Sprite mapOne;
    public Sprite mapTwo;
    private Image image;
    private bool mapUpgraded;
    void Start()
    {
        mapUpgraded = false;
        image = GetComponent<Image>();
    }

    void Update()
    {
        if (mapUpgraded)
        {
            image.sprite = mapTwo;
        }
        else
        {
            image.sprite = mapOne;
        }
    }
}
