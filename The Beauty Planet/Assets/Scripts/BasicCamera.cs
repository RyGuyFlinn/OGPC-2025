using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicCamera : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject player;
    private float playerx;
    private float playery;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        playerx = player.transform.position.x;
        playery = player.transform.position.y;
        transform.position = new Vector3(playerx, playery, -10);
    }
}
