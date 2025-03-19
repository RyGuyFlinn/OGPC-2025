using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Temperature : MonoBehaviour
{
    public TMP_Text canvasText;
    public float temp = 465;
    // Start is called before the first frame update
    void Start()
    {
        canvasText.text = temp.ToString() + " C";
    }

    // Update is called once per frame
    void Update()
    {
        temp += 1;
        canvasText.text = temp.ToString() + " C";
    }
}
