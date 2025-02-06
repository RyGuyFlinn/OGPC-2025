using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class Oxygenbar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void SetMaxOxygen(int oxygen)
    {
        slider.maxValue = oxygen;
        slider.value = oxygen;
    }
    public void SetOxygen(int oxygen)
    {
        slider.value = oxygen;
    }
}
