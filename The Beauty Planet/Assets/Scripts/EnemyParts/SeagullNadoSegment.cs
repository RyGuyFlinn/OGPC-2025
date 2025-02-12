using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeagullNadoSegment : MonoBehaviour
{
    public float speed = 2.0f;

    void Update()
    {
        var rotation = Time.deltaTime * speed;

        transform.Rotate(new Vector3(0, 0, rotation));
    }
}
