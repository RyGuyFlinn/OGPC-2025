using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{

    public int[] maxOxygen;
    public int currentOxygen = 100;

    public int upgradeLevel = 0;

    //Gets OxygenBar Script
    public Oxygenbar oxygenBar;
    public int Oxygenamount = 1;
    public float deprecationMultiplayer = 1;
    
    IEnumerator Start()
    {
        //Sets oxygen to max
        currentOxygen = maxOxygen[upgradeLevel];
        oxygenBar.SetMaxOxygen(maxOxygen[upgradeLevel]);
        //Makes you lose oxygen every second
        
            while (true)
            {
                if (currentOxygen < 0)
                {   
                    currentOxygen = 0;
                }

                if (transform.position.x > 170)
                {
                    yield return new WaitForSeconds(0.5f);
                    resetOxegen();
                }
                else
                {
                    yield return new WaitForSeconds(deprecationMultiplayer);
                    LoseOxygen(Oxygenamount);
                }

            }
        
        void LoseOxygen(int amount)
        {
            currentOxygen -= amount;
            oxygenBar.SetOxygen(currentOxygen);
        } 
    }

    public void RaiseOxygen(int amount)
    {
        currentOxygen += amount;
        oxygenBar.SetOxygen(currentOxygen);
    }

    public void resetOxegen()
    {
        currentOxygen = maxOxygen[upgradeLevel];
        oxygenBar.SetOxygen(currentOxygen);
    }
}
