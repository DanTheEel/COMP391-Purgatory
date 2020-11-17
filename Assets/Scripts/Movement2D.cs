using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed;
	public float jumpH;
	public float airSpeed;
	private float moveInput;
	public bool airDirection = false;
	public bool airChange = false;
	public bool isGrounded = false;
	SpriteRenderer mySpriteRenderer;
	public bool directionx = false;
	public KeyCode moveLeft = KeyCode.LeftArrow;
	public KeyCode moveRight = KeyCode.RightArrow;	
    // Start is called before the first frame update
    void Start()
    {
		mySpriteRenderer = GetComponent<SpriteRenderer>(); // instance of sprite renderer the visual
		rb = GetComponent<Rigidbody2D>(); // instance of the rigid body to control the character
    }

    // Update is called once per frame
    void Update()
    {
		Jump(); // jumping
		move(); // movement
		direction(); // which way the character is facing
		stopMotion(); // stopping the animator 
		directionAnimator(); // which direction the animator is facing
	}
	void Jump() // jump method decides how high the player jumps 
	{
		if (Input.GetButtonDown("Jump") && isGrounded == true) // if player is on the ground and presses jump he jumps
		{
			var vel = rb.velocity;
			vel.y = 0.0f;
			rb.velocity = vel;
			rb.AddForce(new Vector2(0f, jumpH), ForceMode2D.Impulse);
			airDirection = directionx;
		}
	}
	void move() // move method decides how the player moves
	{
		if (isGrounded == true) // moving while on the ground
		{
			moveInput = Input.GetAxis("Horizontal");
			rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		}
		else if (isGrounded == true && airDirection == directionx) // moving while on the ground
		{
			moveInput = Input.GetAxis("Horizontal");
			rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		}
		else if (isGrounded == false && airDirection != directionx) // moving while in the air
		{			
			moveInput = Input.GetAxis("Horizontal"); //moveinput gets a value of 1 or -1
			rb.velocity = new Vector2(moveInput * airSpeed, rb.velocity.y); // moveinput is 1 or -1 times airspeed which is less than regular movespeed this determines how fast you move while in the air
			airChange = true;
		}
		else if (isGrounded == false && airDirection == directionx && airChange == true) // this is to allow the player slight movement in air after changing directions twice
		{	
			moveInput = Input.GetAxis("Horizontal"); //moveinput gets a value of 1 or -1
			rb.velocity = new Vector2(moveInput * airSpeed, rb.velocity.y); // moveinput is 1 or -1 times airspeed which is less than regular movespeed this determines how fast you move while in the air
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
			GetComponent<Animator>().enabled = false;
		}
        else // otherwise play animator
        {
			GetComponent<Animator>().enabled = true;
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
