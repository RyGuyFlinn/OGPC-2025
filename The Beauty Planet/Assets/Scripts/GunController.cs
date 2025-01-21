using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunController : MonoBehaviour
{
    public GameObject projectile;
    public GameObject player;
    public SpriteRenderer sprite;

    // Update is called once per frame
    void Update()
    {
        transform.position = player.gameObject.transform.position;

        Vector3 dir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);

        if (Input.mousePosition.x < Camera.main.WorldToScreenPoint(transform.position).x)
        {
            sprite.flipY = true;
        }
        else
        {
            sprite.flipY = false;
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            Instantiate (projectile, transform.position, transform.rotation);
        }
    }
}
