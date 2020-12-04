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
	//private int tracker = 0;
    // Update is called once per frame
    public void Update()
    {
		if (endGame == false)
		{
			lastGroundedPos = grounded.GetComponent<Grounded>().lastGrounded;
		
				newY = myPlay.position.y; //current player position
			if(newY <= lastGroundedPos - 3.0f)
			{
				transform.position = myPlay.position + myPos; // this takes the player position and adds -50 to the z and adds 0 to the y and x
			}
			else if (camOnExit - camOnEnter < -7.5)
			{
				transform.position = myPlay.position + myPos;
			}
			else if(camOnExit < camOnEnter)//&& !(camOnExit - camOnEnter < -5))
			{
				Player.GetComponent<Movement2D>().movementEnabled = true;
				newX = myPlay.position.x;
				newZ = myPos.z;
				camOnExit = camOnExit + 0.01f;
				transform.position = new Vector3(newX,camOnExit,newZ);
			}
			else
			{
				newX = myPlay.position.x;
				newZ = myPos.z;
				transform.position = new Vector3(newX,lastGroundedPos,newZ);
			}
		}
	}
}
