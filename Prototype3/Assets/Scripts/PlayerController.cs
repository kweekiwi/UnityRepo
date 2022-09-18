/*
 * (Kailie Otto)
 * (Prototype 3)
 * (Controls player jumping, animations, soound effects, particle effects, collisions)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public Animator playerAnimator;
    //set ref in inspector
    public ParticleSystem explosionParticle;
    public ParticleSystem dirtParticle;

    public AudioClip jumpSound;
    public AudioClip crashSound;

    private AudioSource playerAudio;

    private Rigidbody rb;
	public float jumpForce;
	public ForceMode jumpForceMode;
	public float gravityModifier;

	public bool isOnGround = true;
	public bool gameOver = false;

    // Start is called before the first frame update
    void Start()
    {
		//set ref variables to components
		rb = GetComponent<Rigidbody>();
        //set ref to animator
        playerAnimator = GetComponent<Animator>();

        //set audio ref
        playerAudio = GetComponent<AudioSource>();

        //start run animation
        playerAnimator.SetFloat("Speed_f", 1.0f);

        jumpForceMode = ForceMode.Impulse;

		//modify gravity
        if (Physics.gravity.y > -10)
        {
            Physics.gravity *= gravityModifier;
        }
    }

    // Update is called once per frame
    void Update()
    {
        //press spacebar to jump
        if (Input.GetKeyDown(KeyCode.Space) && isOnGround && !gameOver)
		{
			rb.AddForce(Vector3.up * jumpForce, jumpForceMode);
			isOnGround = false;

            //set trigger to play jump animation
            playerAnimator.SetTrigger("Jump_trig");

            //stop playing dirt on jump
            dirtParticle.Stop();

            //play jump sound effect
            playerAudio.PlayOneShot(jumpSound, 1.0f);
		}
    }

    private void OnCollisionEnter (Collision collision)
	{
        if (collision.gameObject.CompareTag("Ground"))
		{
			isOnGround = true;
            //play dirt again when on ground
            dirtParticle.Play();
		}
        else if (collision.gameObject.CompareTag("Obstacle") && !gameOver)
        {
            Debug.Log("Game Over!");
            gameOver = true;

            //play death animation
            playerAnimator.SetBool("Death_b", true);
            playerAnimator.SetInteger("DeathType_int", 1);

            //play explosion particle
            explosionParticle.Play();

            //stop dirt on death
            dirtParticle.Stop();

            //play crash sound effect
            playerAudio.PlayOneShot(crashSound, 1.0f);
        }
	}
}
