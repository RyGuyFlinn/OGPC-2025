using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LigtningActivate : MonoBehaviour
{
    public GameObject lightninglvl1;
    public GameObject lightninglvl2;
    public GameObject lightninglvl3;
    public float lvl;
    public bool inbiome;
    public float time;
    public float random;
    public GameObject player;
    // Start is called before the first frame update
    void Start()
    {
        random = Random.Range(20,60f);
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;

        if (inbiome == true) { 
            if (random <= time)
            {
                lvl = Random.Range(0, 3);
                time = 0;
                random = Random.Range(20, 60f);
                lightninglvl2.SetActive(false);
                lightninglvl3.SetActive(false);
            }
            if (lvl == 1)
            {
                lightninglvl2.SetActive(true);
            }
            if (lvl == 2)
            {
                lightninglvl2.SetActive(true);
                lightninglvl3.SetActive(true);
            }

        }
    }
    void OnTriggerEnter2D(Collider2D collide){
        if (collide.tag == "Player"){
          
        inbiome = true;
        lightninglvl1.SetActive(true);
        }
    }
    void OnTriggerExit2D(Collider2D collide){
        if (collide.tag == "Player"){
         
        inbiome = false;
        lightninglvl1.SetActive(false);
        lightninglvl2.SetActive(false);
            lightninglvl3.SetActive(false);
        }
    }
}
