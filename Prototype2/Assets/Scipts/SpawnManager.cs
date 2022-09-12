/*
 * (Kailie Otto)
 * (Prototype 2)
 * (controls spawning of animals with coroutine)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//attach to empty gam object
public class SpawnManager : MonoBehaviour
{
    public GameObject[] prefabsToSpawn;

    //step 3
    private float leftBound = -14;
    private float rightBound = 14;
    private float spawnPosZ = 20;

    public HealthSystem healthSystem;

    void Start()
    {
        //get ref to health system
        healthSystem = GameObject.FindGameObjectWithTag("HealthSystem").GetComponent<HealthSystem>();

        //InvokeRepeating("SpawnRandomPrefab", 2, 1.5f);

        StartCoroutine(SpawnRandomPrefabWithCoroutine());
    }

    IEnumerator SpawnRandomPrefabWithCoroutine()
    {
        //add 3 sec delay befroe first spawning objects
        yield return new WaitForSeconds(3f);

        while (!healthSystem.gameOver)
        {
            SpawnRandomPrefab();

            float RandomDelay = Random.Range(1.5f, 3.0f);

            yield return new WaitForSeconds(RandomDelay);
        }
    }


    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.S))
        {
            //Step 1:
            //Spawn 0th prefab at top of screen
            //Instantiate(prefabsToSpawn[0], new Vector3(0, 0, 20), prefabsToSpawn[0].transform.rotation);

            //Step 2:
            //Pick a random index btw 0 and array length
            //int prefabIndex = Random.Range(0, prefabsToSpawn.Length);
            //spawn randomly selected prefab
            //Instantiate(prefabsToSpawn[prefabIndex], new Vector3(0, 0, 20), prefabsToSpawn[prefabIndex].transform.rotation);


            //SpawnRandomPrefab();
            
        }
    }
    void SpawnRandomPrefab()
    {
        //generate index
        int prefabIndex = Random.Range(0, prefabsToSpawn.Length);

        //generate spawn position
        Vector3 spawnPos = new Vector3(Random.Range(leftBound, rightBound), 0, spawnPosZ);

        //Spawn animal
        Instantiate(prefabsToSpawn[prefabIndex], spawnPos, prefabsToSpawn[prefabIndex].transform.rotation);
    }
}
