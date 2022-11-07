/*
 * (Kailie Otto)
 * (3D prototype, assignment 6)
 * (allows player to move, contains gravity and jumping, no chances since 3D prototype)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
	public CharacterController controller;
	public float speed = 12f;
	public Vector3 velocity;
	public float gravity = -9.81f;
	public float gravityMultiplier = 2f;

	//ground check variables
	public Transform groundCheck;
	public float groundDistance = 0.4f;
	public LayerMask groundMask;
	public bool isGrounded;

	public float jumpHeight = 3f;

    void Awake()
	{
		gravity *= gravityMultiplier;
	}

    // Update is called once per frame
    void Update()
    {
		//check if player on ground
		isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        if (isGrounded && velocity.y < 0)
		{
			velocity.y = -2f; //reset gravity to lower number
		}

		float x = Input.GetAxis("Horizontal");
		float z = Input.GetAxis("Vertical");

		Vector3 move = transform.right * x + transform.forward * z;
		controller.Move(move * speed * Time.deltaTime);

        //add before calcuating velocity
		if (Input.GetButtonDown("Jump") && isGrounded)
		{
			velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
		}

		//add gravity to velocity after
		velocity.y += gravity * Time.deltaTime;
		//multiply velocity by time again to simulate gravity accelerating in fall
		controller.Move(velocity * Time.deltaTime);
	}
}
