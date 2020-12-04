using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vision : MonoBehaviour
{
    GameObject respawnPoint, player;

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
        if (other.gameObject.tag == "Player" && Rock.hidden == false)
        {
            
            float newX, newY;
            newX = respawnPoint.transform.position.x;
            newY = respawnPoint.transform.position.y;

            player.transform.position = new Vector2(newX, newY);
            DeadCount.deadCount++;


        }
        
    }
}
