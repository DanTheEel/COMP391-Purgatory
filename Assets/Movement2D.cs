using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement2D : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed;
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
    }
	void Jump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded == true)
		{
			rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
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
		if(Input.GetKeyDown(KeyCode.A))
		{
			directionx = false;
		}
		if(Input.GetKey(moveLeft))
		{
			directionx = false;
		}
		if (Input.GetKeyDown(KeyCode.D))
		{
			directionx = true;
		}
		if (Input.GetKey(moveRight))
		{
			directionx = true;
		}
	}
}
