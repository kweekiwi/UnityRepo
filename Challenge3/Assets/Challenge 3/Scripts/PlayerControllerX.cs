using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerX : MonoBehaviour
{
    public bool gameOver;

    public float floatForce;
    private float gravityModifier = 1.5f;
    private bool lowEnough;
    //Vector3 m_NewForce = new Vector3(0.0f, 10.0f, 0.0f);
    private Rigidbody playerRb;

    private UIScore uIScore;

    public ParticleSystem explosionParticle;
    public ParticleSystem fireworksParticle;

    private AudioSource playerAudio;
    public AudioClip moneySound;
    public AudioClip explodeSound;
    public AudioClip bounce;


    // Start is called before the first frame update
    void Start()
    {
        //set ref to rigid body
        playerRb = GetComponent<Rigidbody>();

        Physics.gravity *= gravityModifier;
        playerAudio = GetComponent<AudioSource>();

        lowEnough = true;

        // Apply a small upward force at the start of the game
        playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);

        uIScore = GameObject.FindGameObjectWithTag("UI").GetComponent<UIScore>();

    }

    // Update is called once per frame
    void Update()
    {
        // While space is pressed and player is low enough, float up
        if (Input.GetKey(KeyCode.Space) && !gameOver)
        {
            if (transform.position.y > 15)
            {
                lowEnough = false;
                Debug.Log("cant jump");
            }
            else
            {
                lowEnough = true;
                playerRb.AddForce(Vector3.up * floatForce);
                Debug.Log("jump");
            }
        }
    }

    private void OnCollisionEnter(Collision other)
    {
        // if player collides with bomb, explode and set gameOver to true
        if (other.gameObject.CompareTag("Bomb"))
        {
            explosionParticle.Play();
            playerAudio.PlayOneShot(explodeSound, 1.0f);
            gameOver = true;
            Debug.Log("Game Over!");
            Destroy(other.gameObject);
        } 

        // if player collides with money, fireworks
        else if (other.gameObject.CompareTag("Money"))
        {
            fireworksParticle.Play();
            playerAudio.PlayOneShot(moneySound, 1.0f);
            uIScore.score++;
            Destroy(other.gameObject);

        }
        //if the balloon hits ground, upward impulse
        else if (other.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Hit ground");
            playerRb.AddForce(Vector3.up * 5, ForceMode.Impulse);
            playerAudio.PlayOneShot(bounce, 1.0f);
        }

    }

}
