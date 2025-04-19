using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    // Start is called before the first frame update
    public float random;
    public GameObject Storm;
    public bool InBiome;
    public GameObject player;
    public float time;
    private bool Stormactive;
    void Start()
    {
        random = Random.Range(10, 30);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
         if (InBiome == true)
        {
            if (random <= time)
            {
                if (Stormactive == false)
                {
                    Storm.SetActive(true);
                    Stormactive = true;
                }
                else if (Stormactive == true)
                {
                    Storm.SetActive(false);
                    Stormactive=false;
                }
                random = Random.Range(10, 30);
                time = 0;
            }
        }
           

        
    }
    void OnTriggerEnter2D(Collider2D collide){
        if (collide.tag == "Player"){
            InBiome = true;
            Debug.Log("In plains!");
        
        
        }
    }
    void OnTriggerExit2D(Collider2D collide){
        if (collide.tag == "Player"){
            InBiome = false;
            Debug.Log("In plains!");
        
        Storm.SetActive(false);
        Stormactive = false;
        }
    }
}
