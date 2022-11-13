/*
 * (Kailie Otto)
 * (Prototype 4)
 * (Controls enemies and powerups spawning at random locations, displays
 * instructions, wave number)
 */


using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpawnManager : MonoBehaviour
{

    public GameObject enemyPrefab;
    public GameObject powerupPrefab;
    private float spawnRange = 9;
    public int enemyCount;
    public int waveNumber = 1;
    public Text waveNum;
    public Text instructions;
    public bool instructionsActive;

    // Start is called before the first frame update
    void Start()
    {
        instructions.gameObject.SetActive(true);
        instructionsActive = true;
        //SpawnPowerup(1);
        //SpawnEnemyWaves(waveNumber);
        waveNum.text = "Wave Number: " + waveNumber;
    }

    private void SpawnEnemyWaves(int enemiesToSpawn)
    {
        for (int i = 0; i < enemiesToSpawn; i++)
        {
            //instantiate enemy in the random position
            Instantiate(enemyPrefab, GenerateSpawnPosition(), enemyPrefab.transform.rotation);
        }
    }

    private void SpawnPowerup(int powerupToSpawn)
    {
        for (int i = 0; i < powerupToSpawn; i++)
        {
            //instantiate prefab in the random position
            Instantiate(powerupPrefab, GenerateSpawnPosition(), powerupPrefab.transform.rotation);
        }
    }

    private Vector3 GenerateSpawnPosition()
    {
        //generating a random position on the platform
        float spawnPosX = Random.Range(-spawnRange, spawnRange);
        float spawnPosZ = Random.Range(-spawnRange, spawnRange);
        Vector3 randomPos = new Vector3(spawnPosX, 0, spawnPosZ);
        return randomPos;
    }

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            instructions.gameObject.SetActive(false);
            instructionsActive = false;
        }

        enemyCount = GameObject.FindGameObjectsWithTag("Enemy").Length;
        if (enemyCount == 0 && instructionsActive == false)
        {
            waveNumber++;
            SpawnEnemyWaves(waveNumber);
            SpawnPowerup(1);
        }
        waveNum.text = "Wave Number: " + waveNumber;
    }

}
