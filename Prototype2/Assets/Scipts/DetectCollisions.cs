/*
 * (Kailie Otto)
 * (Prototype 2)
 * (destroys food and animal when they collide, adds to score)
 */

//attach to food prefab
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class DetectCollisions : MonoBehaviour
{
    private DisplayScore displayScoreScript;

    private void Start()
    {
        displayScoreScript = GameObject.FindGameObjectWithTag("DisplayScoreText").GetComponent<DisplayScore>();
    }

    private void OnTriggerEnter(Collider other)
    {
        displayScoreScript.score++;
        Destroy(other.gameObject);
        Destroy(gameObject);
    }
}
