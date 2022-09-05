/*
 * (Kailie Otto)
 * (Challenge 1)
 * (controls player movement, I edited to make plane go forward slower,
 * tilt on player input)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public float speed;
    public float rotationSpeed;
    public float verticalInput;

    // Start is called before the first frame update
    void Update()
    {
        if (transform.position.y > 80 || transform.position.y < -51)
        {
            ScoreManager.gameOver = true;
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // get the user's vertical input
        verticalInput = Input.GetAxis("Vertical");

        // move the plane forward at a constant rate
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // tilt the plane up/down based on up/down arrow keys, had to do .left
        //as I discovered Vector3.right flopped the W and S inputs
        transform.Rotate(Vector3.left * rotationSpeed * Time.deltaTime * verticalInput);
    }
}
