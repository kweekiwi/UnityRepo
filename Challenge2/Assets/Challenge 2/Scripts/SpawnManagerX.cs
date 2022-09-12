/*
 * (Kailie Otto)
 * (Challenge 2)
 * (Controls ball spawning, (delays, locations, colors))
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] ballPrefabs;

    private float spawnLimitXLeft = -22;
    private float spawnLimitXRight = 7;
    private float spawnPosY = 30;

    private float startDelay = 1.0f;
    private float spawnInterval = 4.0f;

    private HealthSystem healthSystemScript;
    // Start is called before the first frame update
    void Start()
    {
        //InvokeRepeating("SpawnRandomBall", startDelay, spawnInterval);
        healthSystemScript = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();
        StartCoroutine(SpawnWithCoroutine());
    }

    IEnumerator SpawnWithCoroutine()
    {
        //3 sec delay before start
        yield return new WaitForSeconds(3f);

        while (!healthSystemScript.gameOver)
        {
            SpawnRandomBall();
            //3-5 sec delay
            float randomDelay = Random.Range(3f, 5f);
            yield return new WaitForSeconds(randomDelay);
        }

    }

    // Spawn random ball at random x position at top of play area
    void SpawnRandomBall ()
    {
        // Generate random ball index and random spawn position
        int prefabIndex = Random.Range(0, ballPrefabs.Length);
        Vector3 spawnPos = new Vector3(Random.Range(spawnLimitXLeft, spawnLimitXRight), spawnPosY, 0);

        // instantiate ball at random spawn location
        Instantiate(ballPrefabs[prefabIndex], spawnPos, ballPrefabs[prefabIndex].transform.rotation);
    }

}
