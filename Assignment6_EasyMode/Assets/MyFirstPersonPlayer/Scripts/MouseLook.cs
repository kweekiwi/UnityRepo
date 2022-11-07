/*
 * (Kailie Otto)
 * (3D prototype)
 * (Allows player to look around, locks cursor)
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MouseLook : MonoBehaviour
{

	public float mouseSensitivity = 100f;
	public GameObject player;
	private float verticalLookRotation = 0f;

	private void OnApplicationFocus(bool focus)
	{
		Cursor.lockState = CursorLockMode.Locked;
	}


	// Update is called once per frame
	void Update()
    {
		//get mouse input and assign to two floats
		float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
		float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;

		//rotate player gameobject w/ horizontal mouse input
		player.transform.Rotate(Vector3.up * mouseX);

		//rotate camera around the x axis w/ vertical mouse input
		verticalLookRotation -= mouseY;
		//clamp rotation so player doesn't over rotate and look behind upside down
		verticalLookRotation = Mathf.Clamp(verticalLookRotation, -99f, 90f);
		//apply rotation based on clamped input
		transform.localRotation = Quaternion.Euler(verticalLookRotation, 0f, 0f);
	}
}
