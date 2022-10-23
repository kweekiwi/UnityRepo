/*
 * (Kailie Otto)
 * (3D prototype)
 * (allows targets to take damage and die)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
	public float health = 50f;

    public void TakeDamage(float amount)
	{
		health -= amount;
        if (health <= 0)
		{
			Die();
		}
	}

    void Die()
	{
		Destroy(gameObject);
	}
}
