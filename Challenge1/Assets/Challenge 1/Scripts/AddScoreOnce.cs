/*
 * (Kailie Otto)
 * (Challenge 1)
 * (adds 1 to score when player passes through)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AddScoreOnce : MonoBehaviour
{
    // add to trigger zone

    private bool triggered = false;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && !triggered)
        {
            triggered = true;
            ScoreManager.score++;
        }
    }
}
