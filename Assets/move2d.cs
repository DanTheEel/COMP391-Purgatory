using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move2D : MonoBehaviour
{
	private Rigidbody2D rb;
	public float speed;
	private float moveInput;
	public bool isGrounded = false;

	
	
	
    // Start is called before the first frame update
    void Start()
    {
			rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
		Jump();
        moveInput = Input.GetAxis("Horizontal");
		rb.velocity = new Vector2(moveInput * speed, rb.velocity.y);
    }
	void Jump()
	{
		if (Input.GetButtonDown("Jump") && isGrounded == true)
		{
			rb.AddForce(new Vector2(0f, 5f), ForceMode2D.Impulse);
		}
	}
}
