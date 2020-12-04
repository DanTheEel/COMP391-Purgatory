using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenGate : MonoBehaviour
{
    //public GameObject Gate1;

    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        GameObject gate = GameObject.FindGameObjectWithTag("Gate");
        if (other.gameObject.tag == "Player")
        {
            Destroy(gate);
        }
    }

    
}
