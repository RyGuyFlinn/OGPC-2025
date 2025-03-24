using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using System.Security.Cryptography.X509Certificates;
public class DrillScript : MonoBehaviour
{
    public GameObject label;
    public GameObject hotbar;
    public GameObject alienitem;
    public GameObject Batteryitem;
    public GameObject part1visual;
    public GameObject part2visual;
    public GameObject[] Ore;
    public GameObject enemy;

    public Sprite alientech;
    public Sprite Battery;
    public Animator Animator;
    public Transform Orespawn;
    public Transform[] enemySpawn;

    private float piece1;
    private float piece2;
    public bool enter = false;
    public float spawnrange;
    public float waitseconds;
    private float pause = 0;

    // Start is called before the first frame update
    void Start()
    {
        label.SetActive(false);
        piece1 = 0;
        piece2 = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (enter == true)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                if (piece1 == 0)
                {
                    if (hotbar.GetComponent<hotbar>().HasItem(alientech) >= 1)
                    {
                        hotbar.GetComponent<hotbar>().SubItem(alienitem);
                        piece1 = 1;
                        part1visual.SetActive(false);
                    }
                }
                if (piece2 == 0)
                {
                    if (hotbar.GetComponent<hotbar>().HasItem(Battery) >= 1)
                    {
                        part2visual.SetActive(false);
                        hotbar.GetComponent<hotbar>().SubItem(Batteryitem);
                        piece2 = 1;
                    }
                }

            }
            if (piece1 + piece2 == 2)
            {
                if (pause == 0)
                {
                    label.SetActive(true);
                }
                if (Input.GetKeyDown(KeyCode.E))
                {
                    Animator.SetBool("Interact", true);
                    
                    Debug.Log("Good");
                    
                    if (pause == 0)
                    {
                        label.SetActive(false);
                        StartCoroutine(wait());
                        StartCoroutine(Spawnore());
                        
                        
                    }
                    
                }
            }
        }

    }
    void OnTriggerEnter2D(Collider2D collider)
    {
        
        if (collider.tag == "Player")
        {enter = true;

            if (piece1 == 0)
            {
                part1visual.SetActive(true);
            }
            if (piece2 == 0)
            {
                part2visual.SetActive(true);
            }
                }
    }
    void OnTriggerExit2D(Collider2D collider)
    {

        if (collider.tag == "Player")
        {
            enter = false;
            part2visual.SetActive(false);
            part1visual.SetActive(false);
            if (piece1 + piece2 == 2)
            {
                label.SetActive(false);


            }
        }
    }
        IEnumerator wait()
        {
        if (pause == 0)
        {
            pause = 1;
            yield return new WaitForSeconds(waitseconds);
            Animator.SetBool("Interact", false);
            pause = 0;
        }
        }
    IEnumerator Spawnore()
    {
        //spawn enemy at a random point along circumfrence of circle
        float angleRadians = Random.Range(0, 360) * Mathf.Deg2Rad;
        int randomSpawn = Random.Range(0, enemySpawn.Length);
        Vector3 enemyPosition = new Vector3(enemySpawn[randomSpawn].position.x + spawnrange * angleRadians,
        enemySpawn[randomSpawn].position.y + spawnrange * angleRadians,
        0);
        Instantiate(enemy, enemyPosition, enemy.transform.rotation);

        //wait and then spawn ore
        yield return new WaitForSeconds(2);
        var oreposition = new Vector3(Orespawn.position.x + Random.Range(-spawnrange, spawnrange), 
        Orespawn.position.y + Random.Range(-spawnrange,spawnrange), 
        0);
        Instantiate(Ore[Random.Range(0, Ore.Length)], oreposition, Orespawn.rotation);
    }
    
}
