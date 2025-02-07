using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using UnityEngine.UI;
public class Radiation : MonoBehaviour
{
    public float time;
    public int prevtime;
    public PlayerHealth health;
    public GameObject Warning;
    public float flash;

    public int locks = 0;
    public int itime;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerStay2D(Collider2D collide)
    {
        if (collide.tag == "Player")
        {
            time += Time.deltaTime;
             itime = (int)time;
            
            //Debug.Log(itime);

            if (prevtime != itime)
            {
                if (itime >= 10)
                {
                    health.TakeDamage(10);

                   
                    
                }
                if (itime < 10)
                {
                    flash -= 0.05f;
                }
            }
            prevtime = itime;
            //Keeps the flashing consistent
            if (locks == 0)
            {
                if (itime < 10) { 
                StartCoroutine(Radiationwarn());
            }
            }
            if (itime >= 10) { 
            Warning.SetActive(true);
            }
        }
       

    }
    //Just resets values
    void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.tag == "Player")
        {
            time = 0;
            prevtime = 0;
            Color imagecolor = Warning.GetComponent<Image>().color;
  
            Warning.SetActive(false);
            flash = 0.5f;
            itime = 0;
            Debug.Log("Exit");
        }
    }
    //Code for flashing the radiation symbol
    IEnumerator Radiationwarn()
    {

        Color imagecolor = Warning.GetComponent<Image>().color;
        locks = 1;
    
        Warning.SetActive(true);
        yield return new WaitForSeconds(flash);
      
        Warning.SetActive(false);
        yield return new WaitForSeconds(flash);
        locks = 0;
        
    }
    
}
