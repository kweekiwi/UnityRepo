/*
 * (Kailie Otto)
 * (Assignment 6)
 * (superclass for target, sets up health, speed, death, and methods to be implemented)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{

    protected float speed;
    protected float health;

    //[SerializeField] protected Weapon weapon;

    protected virtual void Awake()
    {
        //weapon = gameObject.AddComponent<Weapon>();
        speed = 5f;
        health = 100f;
    }

    protected abstract void Attack(int amount);

    public abstract void TakeDamage(float amount);

    public abstract void Run();

    protected void Die()
    {
        Destroy(gameObject);
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
