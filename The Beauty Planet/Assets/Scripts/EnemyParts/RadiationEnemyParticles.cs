using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RadiationEnemyParticles : MonoBehaviour
{
    public int damage = 5;

    void OnParticleCollision(GameObject other)
	{
		if (other.gameObject.tag == "Player")
		{
			other.gameObject.GetComponent<PlayerHealth>().TakeDamage(damage);
		}
	}
}
