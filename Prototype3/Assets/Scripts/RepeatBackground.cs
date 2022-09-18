/*
 * (Kailie Otto)
 * (Prototype 3)
 * (Makes background repeat endlessly)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RepeatBackground : MonoBehaviour
{
	private Vector3 startPosition;
	private float repeatWidth;

    // Start is called before the first frame update
    void Start()
    {
        //save starting pos of the background to vector3
		startPosition = transform.position;

		//set repeatWidth to half width of background using box collider
		repeatWidth = GetComponent<BoxCollider>().size.x / 2;
    }

    // Update is called once per frame
    void Update()
    {
        //if background is further to left than to repeatwidth, reset it to its start position
        if (transform.position.x < startPosition.x - repeatWidth)
		{
			transform.position = startPosition;
		}
    }
}
