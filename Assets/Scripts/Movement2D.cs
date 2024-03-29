﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed;
	public float jumpH;
	public float airSpeed;
	private float moveInput;
	public bool airDirection;
	public bool airChange = false;
	public bool isGrounded = false;
	SpriteRenderer mySpriteRenderer;
	public bool directionx = false;
	public KeyCode moveLeft = KeyCode.LeftArrow;
	public KeyCode moveRight = KeyCode.RightArrow;
	public bool movementEnabled = true;
    private object other;
	public GameObject Gate;
	public GameObject Button;
	public bool endGame = false;

	// Start is called before the first frame update
	void Start()
    {
		mySpriteRenderer = GetComponent<SpriteRenderer>(); // instance of sprite renderer the visual
		rb = GetComponent<Rigidbody2D>(); // instance of the rigid body to control the character
    }

    // Update is called once per frame
    void Update()
    {
		if (movementEnabled == true)
		{
			Jump(); // jumping
			move(); // movement
			direction(); // which way the character is facing
			directionAnimator(); // which direction the animator is facing
		}
		stopMotion(); // stopping the animator 

		// Added a line of code to inscrease the dead count when the player dies
		if (this.gameObject.transform.position.y < -31)
		{
			DeadCount.deadCount++;
		}
	}
	void Jump() // jump method decides how high the player jumps 
	{
		if (Input.GetButtonDown("Jump") && isGrounded == true) // if player is on the ground and presses jump he jumps
		{
			var vel = rb.velocity;
			vel.y = 0.0f;
			rb.velocity = vel;
			rb.AddForce(new Vector2(0f, jumpH), ForceMode2D.Impulse);
			
			// give the camera has jumped variable the status of true
			
		}
	}
	void move() // move method decides how the player moves
	{
		if (isGrounded == true) // moving while on the ground
		{
			moveInput = Input.GetAxis("Horizontal");
			rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
			if (airDirection == directionx) // moving while on the ground
			{
				moveInput = Input.GetAxis("Horizontal");
				rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
			}
		}
		else if (isGrounded == false) // detecting first air change
		{	
			if(airDirection != directionx)
			{
				moveInput = Input.GetAxis("Horizontal"); //moveinput gets a value of 1 or -1
				rb.velocity = new Vector2(moveInput * airSpeed, rb.velocity.y); // moveinput is 1 or -1 times movespeed this determines how fast you move while in the air at first jump
				airChange = true;
			}
			else if (airDirection == directionx && airChange == true)
			{
				moveInput = Input.GetAxis("Horizontal"); //moveinput gets a value of 1 or -1
				rb.velocity = new Vector2(moveInput * airSpeed, rb.velocity.y); // moveinput is 1 or -1 times airspeed which is less than regular movespeed this determines how fast you move while in the air
			}
		}
	}
	void direction() //decides which way to face the character based on which key is being pressed (AD, LeftRight)
	{
		if(Input.GetKey(KeyCode.A) && !Input.GetKey(moveRight) && !Input.GetKey(KeyCode.D) && !Input.GetKey(moveLeft)) // A key and make player face left
		{
			directionx = false;
		}
		else if(Input.GetKey(moveLeft) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(moveRight)) // left arrow and make player face left
		{
			directionx = false;
		}
		else if (Input.GetKey(KeyCode.D) && !Input.GetKey(moveLeft) && !Input.GetKey(KeyCode.A) && !Input.GetKey(moveRight)) // D key and make player face right
		{
			directionx = true;
		}
		else if (Input.GetKey(moveRight) && !Input.GetKey(KeyCode.A) && !Input.GetKey(moveLeft) && !Input.GetKey(KeyCode.D)) // right arrow and make player face right
		{
			directionx = true;
		}
	}
	void stopMotion()
	{
		if (rb.velocity==new Vector2(0,0))	//if character isn't moving then animator doesn't play and character stops moving
		{
			if (endGame == false)
			{
				GetComponent<Animator>().enabled = false;
				GetComponent<AudioSource>().enabled = false; // Audiosource not playing when movement stops
			}
		}
        else // otherwise play animator
        {
			if (endGame == false)
			{
				GetComponent<Animator>().enabled = true;
				GetComponent<AudioSource>().enabled = true; // Audiosource is playing when there is movement
			}
		}
	}
	void directionAnimator()
	{
		if (directionx == true) //if direction is true then the character is facing to the right
		{
			mySpriteRenderer.flipX = true;
		}
		else if (directionx == false) //if direction is false then the character is facing the left
		{
			mySpriteRenderer.flipX = false;
		}
	}

  
}
