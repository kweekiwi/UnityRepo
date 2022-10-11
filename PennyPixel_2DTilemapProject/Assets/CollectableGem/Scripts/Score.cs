/*
 * (Kailie Otto)
 * (Assignment 5A)
 * (Adds to score whenever the player collides with coins)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour
{
    private ScoreDisplay scoreDisplayScript;

    // Start is called before the first frame update
    void Start()
    {
        scoreDisplayScript = GameObject.FindGameObjectWithTag("Score").GetComponent<ScoreDisplay>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        scoreDisplayScript.score++;
    }
}
