/*
 * (Kailie)
 * (prototype5)
 * (Controls object spawning, title screen, game over/restarting, updates score)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class GameManager : MonoBehaviour
{

    public List<GameObject> targets;
    private float spawnRate = 1.0f;

    public TextMeshProUGUI scoreText;

    public TextMeshProUGUI gameOverText;

    private int score;

    public bool isGameActive;

    public Button restartButton;

    public GameObject titleScreen;

    public void StartGame(int difficulty)
    {
        spawnRate /= difficulty;
        isGameActive = true;
        StartCoroutine(SpawnTarget());
        score = 0;
        UpdateScore(0);
        titleScreen.gameObject.SetActive(false);
    }


    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }


    // Start is called before the first frame update
    void Start()
    {

    }

    public void GameOver()
    {
        gameOverText.gameObject.SetActive(true);
        restartButton.gameObject.SetActive(true);
        isGameActive = false;
    }

    public void UpdateScore(int scoreToAdd)
    {
        score += scoreToAdd;
        scoreText.text = "Score: " + score;
    }


    IEnumerator SpawnTarget()
    {
        while (isGameActive)
        {
            //wait 1 second
            yield return new WaitForSeconds(spawnRate);

            //pick a random index between 0 and the number of prefabs
            int index = Random.Range(0, targets.Count);

            //spawn the prefab at the randomly selected index
            Instantiate(targets[index]);
        }
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
