using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class voidFall : MonoBehaviour
{
	public GameObject Camera;
	public GameObject Player;
	public GameObject deadCount;
    // Start is called before the first frame update
    void Start()
    {
        
    }
    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnTriggerEnter2D(Collider2D other)
    {
		deadCount.GetComponent<DeadCount>().endGame = true;
		Player.GetComponent<Movement2D>().endGame = true;
		Camera.GetComponent<FollowPlayer>().endGame = true;
    }
}