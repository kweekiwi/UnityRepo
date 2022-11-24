using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    private Rigidbody targetRB;
    private float minSpeed = 12;
    private float maxSpeed = 16;
    private float maxTorque = 10;
    private float xRange = 4;
    private float ySpawnPos = -6;


    // Start is called before the first frame update
    void Start()
    {
        targetRB = GetComponent<Rigidbody>();

        //add force upwards at a randomized speed
        targetRB.AddForce(RandomForce(), ForceMode.Impulse);

        //add a torque (rotational force) with randomized xyz values
        targetRB.AddTorque(Random.Range(-10, 10), Random.Range(-10, 10), Random.Range(-10, 10), ForceMode.Impulse);

        //set the position with a randomized X value
        transform.position = new Vector3(Random.Range(-4, 4), -6);
    }


    private Vector3 RandomForce()
    {
        return Vector3.up * Random.Range(minSpeed, maxSpeed);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
