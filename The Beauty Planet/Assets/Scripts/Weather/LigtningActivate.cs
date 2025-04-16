using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigtningActivate : MonoBehaviour
{
    public GameObject lightning;
 
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collide){
        if (collide.tag == "Player"){
          
        
        lightning.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collide){
        if (collide.tag == "Player"){
         
        
        lightning.SetActive(false);
        }
    }
}
