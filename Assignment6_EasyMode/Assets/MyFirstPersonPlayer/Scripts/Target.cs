/*
 * (Kailie Otto)
 * (Assignment 6)
 * (allows targets to take damage and die, implements abstract methods of Enemy class )
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class Target : Enemy
{
    public Rigidbody rb;
    // Start is called before the first frame update
    protected override void Awake()
    {
        base.Awake();
        health = 50f;
        rb = this.GetComponent<Rigidbody>();
        //GameManager.Instance.score = +5;
    }

    //public float health = 50f;

    protected override void Attack(int amount)
    {
        Debug.Log("Cube attacks");
    }

    public override void TakeDamage(float amount)
    {
        Debug.Log("Cube took " + amount + " points of damage");
        health -= amount;

        if (health <= 0)
        {
            Die();
        }
        else
        {
            //cube runs a short distance away
            Run();
        }
    }

    //runs away costantly if almost dead
    private void Update()
    {
        if (health < 15f)
        {
            Run();
        }    
    }

    public override void Run()
    {
        if (health < 50f)
        {
            Debug.Log("Cube tries to run");
            rb.velocity = new Vector3(10, 10, -10);
        }
    }

    //in enemy
    //   void Die()
    //{
    //	Destroy(gameObject);
    //}
}
