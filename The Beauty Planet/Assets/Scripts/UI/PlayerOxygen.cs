using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{

    public int[] maxOxygen;
    public int currentOxygen;

    public int upgradeLevel = 0;

    public float shipBoundary = 170.0f;

    //Gets OxygenBar Script
    public Oxygenbar oxygenBar;
    public int Oxygenamount = 1;
    public float deprecationMultiplayer = 1;
    
    IEnumerator Start()
    {
        //Sets oxygen to max
        oxygenBar.SetMaxOxygen(maxOxygen[upgradeLevel]);
        resetOxegen();
        //Makes you lose oxygen every second

        while (true)
            {
                if (currentOxygen < 0)
                {   
                    currentOxygen = 0;
                }

                if (transform.position.x > shipBoundary)
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
    }

    void LoseOxygen(int amount)
    {
        currentOxygen -= amount;
        oxygenBar.SetOxygen(currentOxygen);
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

    public void upgradeOxygen()
    {
        oxygenBar.SetMaxOxygen(maxOxygen[upgradeLevel]);
        currentOxygen = maxOxygen[upgradeLevel];
        oxygenBar.SetOxygen(currentOxygen);
    }
}
