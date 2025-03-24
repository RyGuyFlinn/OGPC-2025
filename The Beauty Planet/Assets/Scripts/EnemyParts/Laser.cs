using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour
{
    public Shake shake;
    public Sprite baseSprite;
    public Sprite warnSprite;
    public Sprite shootSprite;

    public Sprite laserWarnSprite;
    public Sprite laserFireSprite;

    public float warnTime;
    public float fireTime;

    public GameObject laser;

    private SpriteRenderer sprite;

    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    public void Fire()
    {
        StartCoroutine(Shoot());
    }

    IEnumerator Shoot()
    {
        sprite.sprite = warnSprite;
        laser.gameObject.SetActive(true);
        laser.gameObject.GetComponent<LaserBase>().canHurt = false;
        laser.gameObject.GetComponent<SpriteRenderer>().sprite = laserWarnSprite;

        yield return new WaitForSeconds(warnTime);

        shake.start = true;
        sprite.sprite = shootSprite;
        laser.gameObject.GetComponent<LaserBase>().canHurt = true;
        laser.gameObject.GetComponent<SpriteRenderer>().sprite = laserFireSprite;

        yield return new WaitForSeconds(fireTime);

        sprite.sprite = baseSprite;
        laser.gameObject.SetActive(false);
    }
}
