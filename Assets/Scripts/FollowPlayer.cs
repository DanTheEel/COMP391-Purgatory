using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
	public GameObject Player;
	public GameObject grounded;
    public Vector3 myPos;
    public Transform myPlay;
	public float lastGroundedPos;
	public float lastGroundedPosPlaceholder;
	public bool hasJumped;
	public float camOnExit;
	public float camOnEnter;
	public float newX, newY ,newZ; //this will be our x position that we will be manipulating to stay at the same X as the player while not being at the same y
	public bool endGame = false;
	public GameObject CameraResize; // 
									//private int tracker = 0;
									// Update is called once per frame
	public void Update()
	{
		if (endGame == false)
		{
			lastGroundedPos = grounded.GetComponent<Grounded>().lastGrounded;

			newY = myPlay.position.y; //current player position
			if (newY <= lastGroundedPos - 3.0f)
			{
				transform.position = myPlay.position + myPos; // this takes the player position and adds -50 to the z and adds 0 to the y and x
			}
			else if (camOnExit - camOnEnter < -7.5)
			{
				transform.position = myPlay.position + myPos;
			}
			else if (camOnExit < camOnEnter)//&& !(camOnExit - camOnEnter < -5))
			{
				Player.GetComponent<Movement2D>().movementEnabled = true;
				newX = myPlay.position.x;
				newZ = myPos.z;
				camOnExit = camOnExit + 0.01f;
				transform.position = new Vector3(newX, camOnExit, newZ);
			}
			else
			{
				newX = myPlay.position.x;
				newZ = myPos.z;
				transform.position = new Vector3(newX, lastGroundedPos, newZ);
			}
		}
		else if (endGame == true)
		{
			float y = transform.position.y;
			float x = transform.position.x;
			Player.GetComponent<Movement2D>().movementEnabled = false;
			if (x < 155.0f)
			{
				x = x + 0.01f;
			}
			float camsize = CameraResize.GetComponent<Camera>().orthographicSize;
			if (camsize < 9.0f)
			{
				camsize = camsize * 1.0003f;
				CameraResize.GetComponent<Camera>().orthographicSize = camsize;
			}
			if (y > -33.0f)
			{
				y = y - 0.01f;
			}
			transform.position = new Vector3(x, y, -10.0f);
		}
	}
}