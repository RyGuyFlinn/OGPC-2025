using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerIcon : MonoBehaviour
{
    private GameObject player;
    private RectTransform rectTransform;
    void Start()
    {
        player = GameObject.Find("Player");
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        if (player.transform.position.x > 150f)
        {
            rectTransform.anchoredPosition = new Vector2(
                -12f / 23f,
                -60f / 23f);
        }
        else
        {
            rectTransform.anchoredPosition = new Vector2(
                player.transform.position.x * (6f / 23f),
                player.transform.position.y * (6f / 23f));
        }
    }
}
