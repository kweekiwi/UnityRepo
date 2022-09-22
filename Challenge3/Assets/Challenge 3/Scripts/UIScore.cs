/*
 * (Kailie Otto)
 * (Challenge 3)
 * (Keeps track of score, sets UI elements, has the loss/win conditions, and the ability to restart the game)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class UIScore : MonoBehaviour
{
	public int score = 0;
	public Text scoreText;

	public PlayerControllerX playerControllerScript;

	public bool won = false;

	// Start is called before the first frame update
	void Start()
	{
		if (scoreText == null)
		{
			scoreText = FindObjectOfType<Text>();
		}
		if (playerControllerScript == null)
		{
			playerControllerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerControllerX>();
		}
		scoreText.text = "Score: 0";
	}

	// Update is called once per frame
	void Update()
	{
		//display score until game is over
		if (!playerControllerScript.gameOver)
		{
			scoreText.text = "Score: " + score;
		}

		//loss condition: Hit obstacle
		if (playerControllerScript.gameOver && !won)
		{
			scoreText.text = "You lose! Press R to try again!";
			}

		//win condition: 15 points
		if (score >= 15)
		{
			playerControllerScript.gameOver = true;
			won = true;
			//stop player from running

			scoreText.text = "You win! Press R to try again!";
		}

		//Press R to restart if game over
		if (playerControllerScript.gameOver && Input.GetKeyDown(KeyCode.R))
		{
            //reset gravity everytime the scene restarts, otherwise the value continues to change each time
            Physics.gravity /= 1.5f;

			SceneManager.LoadScene(SceneManager.GetActiveScene().name);
		}
	}
}
