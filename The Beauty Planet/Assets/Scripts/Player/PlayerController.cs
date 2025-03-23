using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;
    Animator animator;
    AudioSource audio;

    float horizontal;
    float vertical;
    private float distance;
    
    public float acceleration = 20.0f;
    public float friction = 0.0f;
    public float runSpeed = 5.0f;

    public GameObject hotbar;
    private GameObject itemToDrop;

    public AudioClip itemPickup;
    public AudioClip itemDrop;
    public AudioClip walk;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        audio = GetComponent<AudioSource>();
    }

    private void FixedUpdate()
    {  
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        distance = Mathf.Sqrt(horizontal*horizontal + vertical*vertical);
        if(distance == 0)
        {
            distance = 1;
        }

        body.velocity = new Vector2(horizontal / distance * runSpeed, vertical / distance * runSpeed);
        body.velocity = new Vector2(Mathf.Clamp(body.velocity.x, -runSpeed, runSpeed), Mathf.Clamp(body.velocity.y, -runSpeed, runSpeed));
        
        if (horizontal == 0)
        {
            body.velocity = new Vector2(Mathf.Lerp(body.velocity.x, 0, friction), body.velocity.y);
        }
        if (vertical == 0)
        {
            body.velocity = new Vector2(body.velocity.x, Mathf.Lerp(body.velocity.y, 0, friction));
        }
        
        // Movement Animations
        animator.SetFloat("V_Speed", body.velocity.y);
        animator.SetFloat("H_Speed", body.velocity.x);
    }

    public void AddItem(GameObject ItemToAdd, GameObject ItemParent)
    {
        hotbar.GetComponent<hotbar>().AddItem(ItemToAdd, ItemParent.gameObject);

        //play audio clip
        audio.clip = itemPickup;
        audio.Play();
    }

    public void destroyItem(GameObject ItemParent)
    {
        Destroy(ItemParent.gameObject);
    }

    public void dropItem(GameObject dropItem)
    {
        if (dropItem != null)
        {
            itemToDrop = Instantiate(dropItem, new Vector2(this.transform.position.x, this.transform.position.y + 1), this.transform.rotation);
            itemToDrop.SetActive(true);

            //play audio clip
            audio.clip = itemDrop;
            audio.Play();
        }
    }
}
