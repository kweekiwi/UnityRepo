/*
 * (Kailie Otto)
 * (Prototype 1)
 * (increases score when triggerzone detects player, but only once)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to triggerzone
public class TriggerZoneAddScoreOnce : MonoBehaviour
{
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
