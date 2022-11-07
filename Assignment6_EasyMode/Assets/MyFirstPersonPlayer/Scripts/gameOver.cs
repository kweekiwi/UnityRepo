/*
 * (Kailie Otto)
 * (3D prototype)
 * (displays game over when player gets to the end)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    public Text gameOverText;

    private void OnTriggerEnter(Collider other)
    {
        gameOverText.text = "You Win!";
    }
}
