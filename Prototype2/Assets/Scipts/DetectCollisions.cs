/*
 * (Kailie Otto)
 * (Prototype 2)
 * (destroys food and animal when they collide)
 */

//attach to food prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisions : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
