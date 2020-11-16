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
		Jump(); // calls jump method every frame
		move(); // calls move method every frame
		direction(); // calls direction every frame
		//airDirection();
		landed(); // method to reset landed 
		if (directionx == true) //if direction is true then the character is facing to the right
		{
			mySpriteRenderer.flipX = true;
		}
		if (directionx == false) //if direction is false then the character is facing the left
		{
			mySpriteRenderer.flipX = false;
		}
		if (rb.velocity==new Vector2(0,0))	//if character isn't moving then animator doesn't play and character stops moving
		{
			GetComponent<Animator>().enabled = false;
		}
        else // otherwise play animator
        {
			GetComponent<Animator>().enabled = true;
		}		
		Debug.Log(airChange);
	}
	void landed()
	{
		if (isGrounded == true)
		{
			airChange = false;
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
			airChange = true;
			//Debug.Log(airChange);
		}
	}
	void move() // move method decides how the player moves
	{
		
		if (isGrounded == true) // moving while on the ground
		{
			moveInput = Input.GetAxis("Horizontal");
			rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		}
		else if (isGrounded == false) // moving while in the air *must fix it currently isn't working properly*
		{ // to fix in air movement we can allow the character to move normally unless a change in direction is seen
			
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
	/*void airDirection() //decides which direction the player is trying to face while in the air
	{
		if(isGrounded == false && Input.GetKey(KeyCode.A) && !Input.GetKey(moveRight) && !Input.GetKey(KeyCode.D) && !Input.GetKey(moveLeft)) // A key and make player face left
		{
			airChange = true;
			Debug.Log("hey you moved in the air");
		}
		else if(isGrounded == false && Input.GetKey(moveLeft) && !Input.GetKey(KeyCode.D) && !Input.GetKey(KeyCode.A) && !Input.GetKey(moveRight)) // left arrow and make player face left
		{
			airChange = true;
			Debug.Log("hey you moved in the air");

		}
		else if (isGrounded == false && Input.GetKey(KeyCode.D) && !Input.GetKey(moveLeft) && !Input.GetKey(KeyCode.A) && !Input.GetKey(moveRight)) // D key and make player face right
		{
			airChange = true;
			Debug.Log("hey you moved in the air");

		}
		else if (isGrounded == false && Input.GetKey(moveRight) && !Input.GetKey(KeyCode.A) && !Input.GetKey(moveLeft) && !Input.GetKey(KeyCode.D)) // right arrow and make player face right
		{
			airChange = true;
			Debug.Log("hey you moved in the air");

		}
	}*/
}
