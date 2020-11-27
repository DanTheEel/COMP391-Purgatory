using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Runtime.InteropServices;
using UnityEngine;

public class Grounded : MonoBehaviour
{
	public GameObject Player;
	public Transform myPlay;
	public float lastGrounded;
    // Start is called before the first frame update
    void Start()
    {
		
        Player = gameObject.transform.parent.gameObject;
		lastGrounded = myPlay.position.y;
	}

    // Update is called once per frame
    void Update()
    {
		
	}
	
	private void OnCollisionEnter2D(Collision2D collision)
	{
		
		if (collision.collider.tag == "Ground")
		{
			//lastGrounded = myPlay.position.y; //this is an attempt to reset the last grounded when the player lands
			Player.GetComponent<Movement2D>().airDirection = false;
		}
	}
	private void OnCollisionExit2D(Collision2D collision)
	{
		if (collision.collider.tag == "Ground")
		{
			//lastGrounded = myPlay.position.y;
			Player.GetComponent<Movement2D>().isGrounded = false;
			Player.GetComponent<Movement2D>().airDirection = Player.GetComponent<Movement2D>().directionx;
		}
	}
	private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.collider.tag == "Ground")
        {
			lastGrounded = myPlay.position.y;
            Player.GetComponent<Movement2D>().isGrounded = true;
			Player.GetComponent<Movement2D>().airChange = false;
        }
    }
}
