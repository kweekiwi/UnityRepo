/*
 * (Kailie Otto)
 * (Prototype 1)
 * (notices if player falls off, sets game over)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;


//attach to player
public class LoseOnFall : MonoBehaviour
{
    //set this ref in the inspector
    

    // Update is called once per frame
    void Update()
    {
        //check loss condition
        if (transform.position.y < -1)
        {
            ScoreManager.gameOver = true;
        }
    }
}
