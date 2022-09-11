/*
 * (Kailie Otto)
 * (Prototype 2)
 * (destroys prefab objects when they go out of bounds)
 */

//attach to food and animal prefabs
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
	public float topBound = 20;
	public float bottomBound = -10;

    // Update is called once per frame
    void Update()
    {
        //seperating food from animals out of bounds
        //if food goes out of bounds
        if (transform.position.z > topBound)
		{
			Destroy(gameObject);
		}
        //animals out of bounds
        if (transform.position. z < bottomBound)
		{
			Debug.Log("Game Over!");
			Destroy(gameObject);
		}
    }
}
