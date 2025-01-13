using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightningSpawn : MonoBehaviour

{
    public Transform max1;
    public Transform max2;
    public float xmax;
    public float ymax;
    public float xmin;
    public float ymin;
    private float time;
    private int itime;
    private int prevtime;
    public PlayerHealth health;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        xmax = max1.position.x;
        ymax = max1.position.y;
        xmin = max2.position.x;
        ymin = max2.position.y;
        time += Time.deltaTime;
        itime = (int)time;
        if (prevtime != itime)
        {
            var position = new Vector3(Random.Range(xmax, xmin), Random.Range(ymax, ymin), 0);
            transform.position = position;
        }
        prevtime = itime;


    }
    void OnTriggerEnter2D(Collider2D collide)
    {
        if (collide.tag == "Player")
        {
            health.TakeDamage(30);
        }
    }
}
