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
	private float newX, newY ,newZ; //this will be our x position that we will be manipulating to stay at the same X as the player while not being at the same y
	//private int tracker = 0;
    // Update is called once per frame
    public void Update()
    {
		//if (tracker == 0)
		//{
			lastGroundedPos = grounded.GetComponent<Grounded>().lastGrounded;
		
			newY = myPlay.position.y; //current player position
			if(newY <= lastGroundedPos - 3.0f)
			{
				transform.position = myPlay.position + myPos; // this takes the player position and adds -50 to the z and adds 0 to the y and x
			}
			if (camOnExit - camOnEnter < -7.5)
			{
				transform.position = myPlay.position + myPos;
				/*Player.GetComponent<Movement2D>().movementEnabled = false;
				newX = myPlay.position.x;
				newZ = myPos.z;
				camOnExit = camOnExit + 0.11f;
				transform.position = new Vector3(newX,camOnExit,newZ);
				*/
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
			
		//}		
		//landed();
	}
	/*public void landed()
	{
		if (hasJumped == true) // if the character has jumped then execute this otherwise keep going (this will detect whether the player has jumped onto a new platform)
		{
			if (lastGroundedPosPlaceholder < lastGroundedPos - 1)
			{
				
				camOnExit = transform.position.y;
				if(camOnExit < lastGroundedPos) //this while loop is where we move the camera every frame towards the main character to reduce snapping
				{
					camOnExit = camOnExit + 0.1f;
					transform.position = new Vector3(newX,camOnExit,newZ);
					tracker++;
				}
				else
				{
					tracker = 0;
				}	
				
			}
			//lastGroundedPosPlaceholder = lastGroundedPos;
		}
		else
		{
			lastGroundedPosPlaceholder = lastGroundedPos; // this will create a temporary placeholder of the last grounded position as long as the the player hasn't recently jumped
		}*/
		
	//}
}
