using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraChanger : MonoBehaviour
{
	private Rigidbody2D rb;
	public GameObject CameraResize;
	public GameObject Player;
	private float timer = 0f;
    private float waitTime = 5.0f;
	private bool startTimer = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = Player.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (startTimer == true)
		{
			timer += Time.deltaTime;
			if (timer >= waitTime) // player is allowed to move
			{
				Player.GetComponent<Movement2D>().movementEnabled = true;
				CameraResize.GetComponent<Camera>().orthographicSize = 5f;
			}
			if (timer < waitTime && Player.GetComponent<Movement2D>().isGrounded == true) // player can't move
			{
				Player.GetComponent<Movement2D>().movementEnabled = false;
				var vel = rb.velocity;
				vel.x = 0.0f;
				rb.velocity = vel;
				CameraResize.GetComponent<Camera>().orthographicSize = 15f;
			}
		}
    }
	private void OnTriggerEnter2D(Collider2D other)
    {
		startTimer = true;
    }
}
