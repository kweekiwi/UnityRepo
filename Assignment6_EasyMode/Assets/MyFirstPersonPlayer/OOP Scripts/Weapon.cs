/*
 * (no longer in use, for demo only)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public int damageBonus;
    public Enemy enemyHoldingWeapon;

    private void Awake()
    {
        enemyHoldingWeapon = gameObject.GetComponent<Enemy>();
        enemyEatsWeapon(enemyHoldingWeapon);
    }

    protected void enemyEatsWeapon(Enemy enemy)
    {
        Debug.Log("enemy eats weapon");
    }

    public void Recharge()
    {
        Debug.Log("Recharging weapon");
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
