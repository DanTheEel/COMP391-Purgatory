using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
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
        if (other.gameObject.tag == "Player")
        {
            GameObject player = GameObject.FindGameObjectWithTag("Player");
            GameObject portal = GameObject.FindGameObjectWithTag("Portal");
            
            float newX, newY;
            newX = portal.transform.position.x;
            newY = portal.transform.position.y;
            player.transform.position = new Vector2(newX, newY);

        }
    }
    
}
