/*
 * (Kailie Otto)
 * (Assignment 5A)
 * (Controls player moves, jumping)
 */
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPlatformerController : PhysicsObject {

    public float maxSpeed = 7;
    public float jumpTakeOffSpeed = 7;

    private SpriteRenderer spriteRenderer;
    private Animator animator;

    //add
    public bool invincible;
    public GameObject attackPrefab;
    private bool delay;


    // Use this for initialization
    void Awake () 
    {
        spriteRenderer = GetComponent<SpriteRenderer> (); 
        animator = GetComponent<Animator> ();

        //add
        invincible = false;
        delay = false;
    }

    protected override void ComputeVelocity()
    {
        Vector2 move = Vector2.zero;

        move.x = Input.GetAxis ("Horizontal");

        if (Input.GetButtonDown ("Jump") && grounded) {
            velocity.y = jumpTakeOffSpeed;
        } else if (Input.GetButtonUp ("Jump")) 
        {
            if (velocity.y > 0) {
                velocity.y = velocity.y * 0.5f;
            }
        }

        if(move.x > 0.01f)
        {
            if(spriteRenderer.flipX == true)
            {
                spriteRenderer.flipX = false;
            }
        } 
        else if (move.x < -0.01f)
        {
            if(spriteRenderer.flipX == false)
            {
                spriteRenderer.flipX = true;
            }
        }

        animator.SetBool ("grounded", grounded);
        animator.SetFloat ("velocityX", Mathf.Abs (velocity.x) / maxSpeed);
        animator.SetFloat("velocityY", velocity.y);//added with video

        targetVelocity = move * maxSpeed;
    }

    //add
    /*void Update()
    {
        while (invincible)
        {

        }
    }*/


    // Update is called once per frame
    void Update()
    {
        // On spacebar press, send dog
        if (Input.GetKeyDown(KeyCode.A) && !delay)
        {
            StartCoroutine(Attack());
        }
    }
    IEnumerator Attack()
    {
        delay = true;
        Instantiate(attackPrefab, transform.position, attackPrefab.transform.rotation);
        //3 sec delay before start
        yield return new WaitForSeconds(.5f);
        delay = false;


    }


}