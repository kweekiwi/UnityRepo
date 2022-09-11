/*
 * (Kailie Otto)
 * (Prototype 2)
 * (controls player movement)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float horizontalInput;
    public float speed = 10.0f;
    private float xRange = 14;
    

    // Update is called once per frame
    void Update()
    {
        //get horizontal input from right/left arrow keys or A and D keys
        horizontalInput = Input.GetAxis("Horizontal");

        //transform horizontally w/ input
        transform.Translate(Vector3.right * horizontalInput * Time.deltaTime * speed);

        //keep in bounds
        if (transform.position.x < -xRange)
        {
            transform.position = new Vector3(-xRange, transform.position.y, transform.position.z);
        }
        if (transform.position.x > xRange)
        {
            transform.position = new Vector3(xRange, transform.position.y, transform.position.z);
        }
    }
}
