using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    Rigidbody2D body;

    float horizontal;
    float vertical;
    
    public float acceleration = 20.0f;
    public float friction = 0.0f;
    public float runSpeed = 7.0f;

    public GameObject hotbar;

    void Start ()
    {
        body = GetComponent<Rigidbody2D>(); 
    }

    private void FixedUpdate()
    {  

        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical"); 

        body.AddForce(new Vector2(horizontal, vertical) * acceleration, ForceMode2D.Force);
        body.velocity = new Vector2(Mathf.Clamp(body.velocity.x, -runSpeed, runSpeed), Mathf.Clamp(body.velocity.y, -runSpeed, runSpeed));
        
        if (horizontal == 0)
        {
            body.velocity = new Vector2(Mathf.Lerp(body.velocity.x, 0, friction), body.velocity.y);
        }
        if (vertical == 0)
        {
            body.velocity = new Vector2(body.velocity.x, Mathf.Lerp(body.velocity.y, 0, friction));
        }
        
        //Sprinting
        if (Input.GetKey(KeyCode.LeftShift))
        {
            runSpeed = 12.0f;
           // Debug.Log("Down");
        }
        else
        {
            runSpeed = 7.0f;
           // Debug.Log("Up");
        }
        //Debug.Log("Velocity: " + body.velocity);
    }

    public void AddItem(GameObject ItemToAdd)
    {
        hotbar.GetComponent<hotbar>().AddItem(ItemToAdd);
    }
}
