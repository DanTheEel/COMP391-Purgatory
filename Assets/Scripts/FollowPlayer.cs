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

    // Update is called once per frame
    public void Update()
    {
		lastGroundedPos = grounded.GetComponent<Grounded>().lastGrounded;
		float newX, newY ,newZ; //this will be our x position that we will be manipulating to stay at the same X as the player while not being at the same y
		newY = myPlay.position.y;
		if(newY <= lastGroundedPos - 3.0f)
		{
			Debug.Log("im in");
			transform.position = myPlay.position + myPos; // this takes the player position and adds -50 to the z and adds 0 to the y and x
		}
		else
		{
			newX = myPlay.position.x;
			newZ = myPos.z;
			transform.position = new Vector3(newX,lastGroundedPos,newZ);
		}
	}
}
