using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class MultiShotGunController1 : MonoBehaviour
{
    AudioSource audio;

    public GameObject projectile;
    public GameObject player;
    public Transform muzzle1;
    public Transform muzzle2;
    public Transform muzzle3;
    public AudioClip blastSound;
    private float secret;
    public float fireRate = 0.3f;
    private float nextFire;

    public SpriteRenderer sprite;

    public Vector2 offset;

    public bool crafting = false;

    void Start()
    {
        player = GameObject.Find("Player");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        crafting = GameObject.Find("WorkBenchCollider").gameObject.GetComponent<WorkBench>().crafting;
        
        transform.position = player.gameObject.transform.position + new Vector3(offset.x, offset.y, 0);

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.mousePosition.x < Camera.main.WorldToScreenPoint(transform.position).x)
        {
            sprite.flipY = true;
            offset.x = -Mathf.Abs(offset.x);
        }
        else if (Mathf.Abs(Input.mousePosition.x - Camera.main.WorldToScreenPoint(transform.position).x) > 50)
        {
            sprite.flipY = false;
            offset.x = Mathf.Abs(offset.x);
        }

        if (Input.GetMouseButtonDown(0) && Time.time > nextFire && crafting == false)
        {
            nextFire = Time.time + fireRate;

            Instantiate(projectile, muzzle1.position, muzzle1.transform.rotation);
            Instantiate(projectile, muzzle2.position, muzzle2.transform.rotation);
            Instantiate(projectile, muzzle3.position, muzzle3.transform.rotation);

            //play blast sound
            audio.clip = blastSound;
            audio.Play();
        }

        //Secret code, to help beat game faster when showcasing to judges.
        if (Input.GetKey(KeyCode.Mouse2))
        {
            if (secret == 3)
            {
                nextFire = Time.time + fireRate;

                Instantiate(projectile, muzzle1.position, muzzle1.transform.rotation);
                Instantiate(projectile, muzzle2.position, muzzle2.transform.rotation);
                Instantiate(projectile, muzzle3.position, muzzle3.transform.rotation);

                //play blast sound
                audio.clip = blastSound;
                audio.Play();
            }
        }
        if (Input.GetKeyDown(KeyCode.Y))
        {
            secret += 1;
        }
    }
}
