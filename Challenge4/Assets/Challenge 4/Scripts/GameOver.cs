/*
 * (Kailie Otto)
 * (Challenge 4)
 * (handles game overs, restarting the game)
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    private Text gameOverText;
    private SpawnManagerX spawnManagerScript;

    // Start is called before the first frame update
    void Start()
    {
        gameOverText = gameObject.GetComponent<Text>();
        spawnManagerScript = GameObject.FindGameObjectWithTag("SpawnManager").GetComponent<SpawnManagerX>();
        spawnManagerScript.gameOver = false;
        spawnManagerScript.gameOverBad = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (spawnManagerScript.gameOverBad)
        {
            gameOverText.text = "You Lose! Press R to Restart!";
        }
        if (spawnManagerScript.gameOver)
        {
            gameOverText.text = "You Win! Press R to Restart";
        }

        if (Input.GetKeyDown("r") && spawnManagerScript.gameOverBad || spawnManagerScript.gameOver)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }


    }
}
