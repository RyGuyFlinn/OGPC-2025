using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    // Start is called before the first frame update
    private int on = 0;
    public GameObject Storm;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (on == 0)
            {
                Storm.SetActive(true);
                on = 1;
            }
            else if (on == 1)
            {
                Storm.SetActive(false);
                on = 0;
            }

        }
    }
}
