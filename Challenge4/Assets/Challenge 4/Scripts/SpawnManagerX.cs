/*
 * (Kailie Otto)
 * (Challenge 4)
 * (spawns powerups/enemies, generates spawn positions, resets position
 * each round, displays instructions, counts wave number and enemy speed)
 */

using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    public bool gameOver;
    public bool gameOverBad;
    public Text waveCountText;
    public Text instructions;
    public bool instructionsActive;
    public int enteredGoal;
    private EnemyX enemyScript;
    public float enemySpeed = 10;

    private float spawnRangeX = 10;
    private float spawnZMin = 15; // set min spawn Z
    private float spawnZMax = 25; // set max spawn Z

    public int enemyCount;
    public int spawnedNum;
    public int waveCount = 1;


    public GameObject player;

    private void Start()
    {
        enteredGoal = 0;
        spawnedNum = 1;
        instructions.gameObject.SetActive(true);
        instructionsActive = true;
    }


    // Update is called once per frame
    void Update()
    {
        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;

        if (Input.GetKeyDown("space"))
        {
            instructions.gameObject.SetActive(false);
            instructionsActive = false;
        }

        if (waveCount == 10)
        {
            gameOver = true;
        }
        else if (enteredGoal == spawnedNum)
        {
            Debug.Log("thats a game over");
            gameOverBad = true;
        }
        else if (enemyCount == 0 && gameOver != true && instructionsActive == false && gameOverBad != true)
        {
            Debug.Log("Game not over, spawning more enemies");
            SpawnEnemyWave(waveCount);
        }

    }

    // Generate random spawn position for powerups and enemy balls
    Vector3 GenerateSpawnPosition ()
    {
        float xPos = Random.Range(-spawnRangeX, spawnRangeX);
        float zPos = Random.Range(spawnZMin, spawnZMax);
        return new Vector3(xPos, 0, zPos);
    }


    void SpawnEnemyWave(int enemiesToSpawn)
    {
        Vector3 powerupSpawnOffset = new Vector3(0, 0, -15); // make powerups spawn at player end
        spawnedNum = enemiesToSpawn;
        // If no powerups remain, spawn a powerup
        if (GameObject.FindGameObjectsWithTag("Powerup").Length == 0) // check that there are zero powerups
        {
            Instantiate(powerupPrefab, GenerateSpawnPosition() + powerupSpawnOffset, powerupPrefab.transform.rotation);
        }

        // Spawn number of enemy balls based on wave number
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
        waveCountText.text = "Wave: " + waveCount;
        waveCount++;
        ResetPlayerPosition(); // put player back at start
        enemySpeed++;
        //reset total
        enteredGoal = 0;

    }

    // Move player back to position in front of own goal
    void ResetPlayerPosition ()
    {
        player.transform.position = new Vector3(0, 1, -7);
        player.GetComponent<Rigidbody>().velocity = Vector3.zero;
        player.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;

    }

}
