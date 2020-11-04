using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class isHidden : MonoBehaviour
{
    public bool Hidden;
    private void Start()
    {
        Hidden = false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {           
           Hidden = true;
        }
        else if (other.gameObject.CompareTag("Vision") && Hidden == false)
        {
            Debug.Log("dead? maybe");
            //die? idk how we are gonna punish the player for failing
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {          
            Hidden = false;
        }
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Vision") && Hidden == false)
        {
            Debug.Log("dead? maybe");
            //die? idk how we are gonna punish the player for failing
        }
    }
}
