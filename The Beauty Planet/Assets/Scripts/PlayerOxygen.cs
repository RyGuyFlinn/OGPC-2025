using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerOxygen : MonoBehaviour
{

    public int maxOxygen = 100;
    public int currentOxygen;

    //Gets OxygenBar Script
    public Oxygenbar oxygenBar;
    public int Oxygenamount = 1;
  
    IEnumerator Start()
    {
        //Sets oxygen to max
        currentOxygen = maxOxygen;
        oxygenBar.SetMaxOxygen(maxOxygen);
        //Makes you lose oxygen every second
        while (true)
        {
            yield return new WaitForSeconds(1f);
            LoseOxygen(Oxygenamount);

        }
        
        void LoseOxygen(int amount)
        {
            currentOxygen -= amount;
            oxygenBar.SetOxygen(currentOxygen);
        }
    }
}
