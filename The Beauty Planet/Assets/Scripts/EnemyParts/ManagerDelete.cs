using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerDelete : MonoBehaviour
{
    public GameObject horcrux;
    void Update()
    {
        if (horcrux == null)
        {
            Destroy(gameObject);
        }
    }
}
