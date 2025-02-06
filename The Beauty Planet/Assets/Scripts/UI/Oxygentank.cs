using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oxygentank : MonoBehaviour
{
    public PlayerOxygen oxygen;
    public int Oxygengain = 20;
    //public Oxygenbar oxygenBar;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D player)
    {
        if (player.tag == "Player")
        {
            oxygen.currentOxygen += Oxygengain;
            if (oxygen.currentOxygen > oxygen.maxOxygen)
            {
                oxygen.currentOxygen = oxygen.maxOxygen;
                
            }
            oxygen.oxygenBar.SetOxygen(oxygen.currentOxygen);
            Destroy(gameObject);
        }
        Debug.Log("Collided");
    }
}
