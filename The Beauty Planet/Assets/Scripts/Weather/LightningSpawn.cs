using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class LightningSpawn : MonoBehaviour

{
    public Transform max1;
    public Transform max2;

    public float xmax;
    public float ymax;
    public float xmin;
    public float ymin;

    public bool canHurt;
    //Safelock stops lightning from doing damage multiple times in a row
    private bool safelock = false;
    //Pause makes a random time
    public float pause;
    public PlayerHealth health;

    private float time;
    private int itime;
    private int prevtime;

    private Animator animation;

    // Start is called before the first frame update
    void Start()
    {   pause = Random.Range(3, 13f);
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //Spawns lightning in random position every 3-13 seconds
        canHurt = false;
        xmax = max1.position.x;
        ymax = max1.position.y;
        xmin = max2.position.x;
        ymin = max2.position.y;
        time += Time.deltaTime;
        
        //itime = (int)time;
        if (pause <= time)
        {
            animation.Play("Lightnigh Spawn", 0, 0.25f);
            var position = new Vector3(Random.Range(xmax, xmin), Random.Range(ymax, ymin), 0);
            
            transform.position = position;
            safelock = false;
            pause = Random.Range(3, 13f);
            time = 0;
        }
        //prevtime = itime;
        
        

    }
    //Makes player take damage, safelock makes it so only the lightning will damage once.
    void OnTriggerStay2D(Collider2D collide)
    {
        if (collide.tag == "Player" && canHurt == true && safelock == false)
        {
            health.TakeDamage(30);
            safelock = true;
        }
    }
}
