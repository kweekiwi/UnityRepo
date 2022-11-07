/*
 * (Kailie Otto)
 * (3D prototype, assignment 6)
 * (displays game over when player gets to the end, no changes since 3d prototype)
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
