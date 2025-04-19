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
    public float lvl = 10;
    public float randomlvl;
    public int locks = 0;
    public int itime;
    // Start is called before the first frame update
    void Start()
    {
        flash = 0.5f * (lvl / 10f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == "Player")
        {
            
            randomlvl = Random.Range(0, 3);
            if (randomlvl == 0)
            {
                lvl = 60;
            }
            if (randomlvl == 1)
            {
                lvl = 30;
            }
            if (randomlvl == 2)
            {
                lvl = 10;
            }
            flash = 0.5f * (lvl / 10f);
        }
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
                if (itime >= lvl)
                {
                    health.TakeDamage(10);

                   
                    
                }
                if (itime < lvl)
                {
                    flash -= 0.05f;
                }
            }
            prevtime = itime;
            //Keeps the flashing consistent
            if (locks == 0)
            {
                if (itime < lvl) { 
                StartCoroutine(Radiationwarn());
            }
            }
            if (itime >= lvl) { 
            Warning.SetActive(true);
            }
        }
       

    }
    //Just resets values
    void OnTriggerExit2D(Collider2D collide)
    {
        if (collide.tag == "Player")
        {
            locks = 0;
            time = 0;
            prevtime = 0;
            Color imagecolor = Warning.GetComponent<Image>().color;
  
            Warning.SetActive(false);
            flash = 0.5f * (lvl / 10f);
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
