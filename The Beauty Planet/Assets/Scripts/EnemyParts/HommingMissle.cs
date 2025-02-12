using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HommingMissle : MonoBehaviour
{
    private GameObject Player;
    public float Lag;
    public float speed;
    public float Sensitivity;

    void Start () {
        Player = GameObject.Find("Player");
    }

    void Update () {
        StartCoroutine(RotateObj(transform, Player.transform.position));

        transform.position += (transform.right * Time.deltaTime * speed);
    }

    IEnumerator RotateObj(Transform obj, Vector3 playerpos) {
        yield return new WaitForSeconds(Lag);
        float oreantation = Mathf.Rad2Deg * Mathf.Atan2(obj.position.y - playerpos.y ,transform.position.x - playerpos.x);
        transform.rotation = Quaternion.Euler(0, 0, oreantation + 180);
    }
}
