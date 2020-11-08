using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed;
	public float jumpH;
	private float moveInput;
	public bool isGrounded = false;
	SpriteRenderer mySpriteRenderer;
	public bool directionx = false;
	public KeyCode moveLeft = KeyCode.LeftArrow;
	public KeyCode moveRight = KeyCode.RightArrow;	
    // Start is called before the first frame update
    void Start()
    {
		mySpriteRenderer = GetComponent<SpriteRenderer>();
		rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Jump();
		move();
		direction();
		if(isGrounded == true)
		{
			if (directionx == true)
			{
				mySpriteRenderer.flipX = true;
			}
			if (directionx == false)
			{
				mySpriteRenderer.flipX = false;
			}
		}
		Debug.Log(rb.velocity);
		if (rb.velocity==new Vector2(0,0))
		{
			GetComponent<Animator>().enabled = false;
		}
        else
        {
			GetComponent<Animator>().enabled = true;
		}		
    }
	void Jump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded == true)
		{
			var vel = rb.velocity;
			vel.y = 0.0f;
			rb.velocity = vel;
			rb.AddForce(new Vector2(0f, jumpH), ForceMode2D.Impulse);
		}
	}
	void move()
	{
		if (isGrounded == true)
		{
			moveInput = Input.GetAxis("Horizontal");
			rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
		}
	}
	void direction()
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
}
