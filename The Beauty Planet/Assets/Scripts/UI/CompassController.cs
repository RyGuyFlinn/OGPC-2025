using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class CompassController : MonoBehaviour
{
    public Sprite[] directionSprites;
    public Sprite inShip;
    public Sprite compassItem;
    public hotbar hotbar;
    public GameObject target;

    public GameObject player;
    public GameObject renderer;
    private Image image;

    void Start()
    {
        image = renderer.gameObject.GetComponent<Image>();
        player = GameObject.Find("Player");
    }
    void FixedUpdate()
    {
        //check for and only display UI when compass is in player inventory
        renderer.SetActive(hotbar.HasItem(compassItem) > 0);
        
        if (player.transform.position.x > 170)
        {
           image.sprite = inShip;
        }
        else
        {
            int direction = (int)(Mathf.Round((Vector3.Angle(new Vector3(0, 1, 0), target.transform.position - player.transform.position)) / 22.5f));
            if (target.transform.position.x > player.transform.position.x)
            {
                image.sprite = directionSprites[(8 - direction + 8) % 16];
            }
            else
            {
                image.sprite = directionSprites[direction];
            }
        }
    }
}
