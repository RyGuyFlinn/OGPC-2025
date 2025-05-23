using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shake : MonoBehaviour
{
    public bool start = false;
    public AnimationCurve curve;
    public float duration = 1f;

    private GameObject player;
    
    void Start()
    {
        player = GameObject.Find("Player");
    }
    void Update()
    {
        if (start)
        {
            start = false;
            StartCoroutine(Shaking());
        }
    }

    IEnumerator Shaking()
    {
        Vector3 startPosition = new Vector3(player.transform.position.x, player.transform.position.y, -50);
        float elapsedTime = 0f;

        while (elapsedTime < duration)
        {
            elapsedTime += Time.deltaTime;
            float strength = curve.Evaluate(elapsedTime / duration);
            transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -50) + Random.insideUnitSphere * strength;

            yield return null;
        }

        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, -50);
    }
}
