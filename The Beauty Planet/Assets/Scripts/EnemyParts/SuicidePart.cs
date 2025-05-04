using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuicidePart : MonoBehaviour
{
    public int damage = 30;
    public GameObject particle;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "Player")
        {
            other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
            PlayAndDetachParticle();
            Destroy(gameObject.transform.parent.gameObject);
        }
    }

    void PlayAndDetachParticle()
    {
        particle.transform.parent = null; // Detach from parent
        particle.SetActive(true);

        ParticleSystem ps = particle.GetComponent<ParticleSystem>();
        if (ps != null)
        {
            ps.Play();
            Destroy(particle, ps.main.duration + ps.main.startLifetime.constant); // Destroy after playing
        }
    }
}
