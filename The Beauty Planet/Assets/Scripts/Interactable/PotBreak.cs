using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotBreak : MonoBehaviour
{
    public GameObject break_1;
    public GameObject break_2;
    public GameObject break_3;
    public GameObject break_4;
    public GameObject pot;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D Collide){
    if (Collide.tag == "Player"){
        if (Input.GetKey(KeyCode.E)){
            break_1.SetActive(true);
            break_2.SetActive(true);
            break_3.SetActive(true);
            break_4.SetActive(true);
            
            pot.GetComponent<BoxCollider2D>().enabled = false;
            pot.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(Wait());
        } }
    if (Collide.tag == "Bullet"){
        print("Bullet Collide!");
        Destroy(Collide);
            break_1.SetActive(true);
            break_2.SetActive(true);
            break_3.SetActive(true);
            break_4.SetActive(true);
            
            pot.GetComponent<BoxCollider2D>().enabled = false;
            pot.GetComponent<SpriteRenderer>().enabled = false;
            StartCoroutine(Wait());
    }
    }
     
     IEnumerator Wait(){
        yield return new WaitForSeconds(1);
        Destroy(pot);
     } }

