using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dust : MonoBehaviour
{
    // Start is called before the first frame update
    private int on = 0;
    public GameObject Storm;
 
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         
           

        
    }
    void OnTriggerEnter2D(Collider2D collide){
        if (collide.tag == "Player"){
            Debug.Log("In plains!");
        
        Storm.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collide){
        if (collide.tag == "Player"){
            Debug.Log("In plains!");
        
        Storm.SetActive(false);
        }
    }
}
