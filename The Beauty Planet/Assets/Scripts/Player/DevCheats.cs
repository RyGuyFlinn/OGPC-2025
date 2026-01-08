using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DevCheats : MonoBehaviour
{
    public float secret;
    public PlayerHealth health;
    public PlayerOxygen oxygen;
    public PlayerController controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (secret == 3)
        {
            if (Input.GetKey(KeyCode.R))
            {
                health.TakeDamage(-30);
                oxygen.currentOxygen += 10;
            }
            if (Input.GetKey(KeyCode.LeftShift))
            {
                controller.runSpeed = 15.0f;
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                controller.runSpeed = 6.0f;
            }


        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            secret += 1;
        }
    }
}
