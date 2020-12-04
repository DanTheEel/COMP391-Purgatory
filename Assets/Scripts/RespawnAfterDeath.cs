using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnAfterDeath : MonoBehaviour
{    static public void respawn(GameObject player, GameObject respawnPoint)//respawns player to position respawnPoint (inside a method to be called by other scripts)
    {
        DeadCount.deadCount++;        

        float newX, newY;
        newX = respawnPoint.transform.position.x;
        newY = respawnPoint.transform.position.y;

        player.transform.position = new Vector2(newX, newY);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            respawn(GameObject.FindGameObjectWithTag("Player"), GameObject.FindGameObjectWithTag("Respawn")); 
        }
    }
}
