using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{

    public int maxOxygen = 100;
    public int currentOxygen = 100;

    //Gets OxygenBar Script
    public Oxygenbar oxygenBar;
    public int Oxygenamount = 1;
    public float deprecationMultiplayer = 1;
    
    IEnumerator Start()
    {
        //Sets oxygen to max
        currentOxygen = maxOxygen;
        oxygenBar.SetMaxOxygen(maxOxygen);
        //Makes you lose oxygen every second
        
            while (true)
            {
                if (currentOxygen < 0)
            {
                currentOxygen = 0;
            }

                yield return new WaitForSeconds(deprecationMultiplayer);
                LoseOxygen(Oxygenamount);

            }
        
        void LoseOxygen(int amount)
        {
            currentOxygen -= amount;
            oxygenBar.SetOxygen(currentOxygen);
        } 
    }

    public void resetOxegen()
    {
        currentOxygen = maxOxygen;
        oxygenBar.SetOxygen(currentOxygen);
    }
}
