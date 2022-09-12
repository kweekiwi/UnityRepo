/*
 * (Kailie Otto)
 * (Challenge 2)
 * (Detects collision btw dog and ball, increases score, destroys both)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectCollisionsX : MonoBehaviour
{
    public ScoreManager scoreManagerScript;
    private void Start()
    {
        scoreManagerScript = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreManager>();
    }

    private void OnTriggerEnter(Collider other)
    {
        scoreManagerScript.score++;
        Destroy(gameObject);
    }
}
