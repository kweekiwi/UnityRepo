/*
 * (Kailie Otto)
 * (Prototype 1)
 * (Now unused, formally used to increase score when trigger zone is passed)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to player
public class PlayerEnterTrigger : MonoBehaviour
{
    

    //when player ends trigger zone tagged finish
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("TriggerZone"))
        {
            ScoreManager.score++;
            
        }
    }
}
