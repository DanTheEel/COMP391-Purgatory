using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class isHidden : MonoBehaviour
{
    public bool Hidden;
    private GameObject Checkpoint;
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
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
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }
}
