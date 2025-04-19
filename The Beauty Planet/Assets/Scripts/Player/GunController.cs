using System.Collections;
using System.Collections.Generic;
//using UnityEditor.Tilemaps;
using UnityEngine;

public class GunController : MonoBehaviour
{
    AudioSource audio;

    public GameObject projectile;
    public GameObject player;
    public Transform muzzle;
    public AudioClip blastSound;
    private float secret;
    public float fireRate = 0.3f;
    private float nextFire;

    public SpriteRenderer sprite;

    public Vector2 offset;

    void Start()
    {
        player = GameObject.Find("Player");
        audio = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
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

        if (Input.GetMouseButtonDown(0) && Time.time > nextFire)
        {
            nextFire = Time.time + fireRate;

            Instantiate (projectile, muzzle.position, transform.rotation);

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

                Instantiate(projectile, muzzle.position, transform.rotation);

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
