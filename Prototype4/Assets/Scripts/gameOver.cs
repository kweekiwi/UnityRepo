/*
 * (Kailie Otto)
 * (Prototype 4)
 * (Controls game over text display and restarting)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class gameOver : MonoBehaviour
{
    private Text gameOverText;
    private PlayerController playerControllerScript;
    private SpawnManager spawnManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText = gameObject.GetComponent<Text>();
        playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerController>();
        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if (playerControllerScript.gameOver)
        {
            gameOverText.text = "You Lose! Press R to Restart!";
        }
        if (spawnManagerScript.waveNumber == 10)
        {
            gameOverText.text = "You Win! Press R to Restart";
        }

        if (Input.GetKeyDown("r") && playerControllerScript.gameOver || spawnManagerScript.waveNumber == 10)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }


    }
}
