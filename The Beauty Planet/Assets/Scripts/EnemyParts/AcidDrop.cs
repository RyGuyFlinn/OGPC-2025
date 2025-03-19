using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidDrop : MonoBehaviour
{
    public int damage = 25;
    public bool canHurt = false;
    public GameObject drop;
    public GameObject rain;
    
    private Animator animator;

    void Start()
    {
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        AnimatorStateInfo stateInfo = animator.GetCurrentAnimatorStateInfo(0);

        if (stateInfo.normalizedTime >= 1f)
        {
            StartCoroutine(destroy());
        }
    }

    IEnumerator destroy()
    {
        GetComponent<SpriteRenderer>().enabled = false;
        rain.SetActive(false);
        drop.SetActive(true);
        yield return new WaitForSeconds(1);

        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player" && canHurt == true)
        {
            col.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
        }
    }

    
}
