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
    private void OnTriggerStay2D(Collider2D other)
    {
        Debug.Log("stay2d");
        if (other.gameObject.CompareTag("Bush"))
        {           
           Hidden = true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Bush"))
        {          
            Hidden = false;
        }
    }
}
