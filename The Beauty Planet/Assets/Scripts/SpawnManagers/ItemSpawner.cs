using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class itemSpawner : MonoBehaviour
{
    private Collider2D[] itemColliders;
    private CircleCollider2D collider;
    public LayerMask myLayerMask;
    private int colliderCount;
    private int itemCount;
    public GameObject item;
    public float itemMin;
    void Start()
    {
        collider = GetComponent<CircleCollider2D>();
    }

    void Update()
    {
        itemColliders = new Collider2D[50];
        int colliderCount = Physics2D.OverlapCircleNonAlloc(collider.transform.position, 
         collider.radius, 
         itemColliders, 
         myLayerMask, 
         -Mathf.Infinity, 
         Mathf.Infinity);

        itemCount = 0;
        for (int i = 0; i < colliderCount; i++)
        {
            if (itemColliders[i].gameObject.tag == "Item")
            {
                itemCount++;
            }
        }

        if (itemCount < itemMin)
        {
            Instantiate(item, new Vector2(collider.transform.position.x, collider.transform.position.y) + Random.insideUnitCircle * collider.radius, item.transform.rotation);
        }
    }
}
