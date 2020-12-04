using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LastScript : MonoBehaviour
{
    public GameObject congratulationParchment, youFailedParchment;
    

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
        if (other.gameObject.tag == "Player" && ParchmentCount.parchmentCount == 5)
        {
            float x, y, z;
            x = 123.88f;
            y = -18.35f;
            z = 0f;

            Instantiate(congratulationParchment, new Vector3(x, y, z), Quaternion.identity);
        }
        else if (other.gameObject.tag == "Player" && ParchmentCount.parchmentCount <5)
        {
            float x1, y1, z1;
            x1 = 123.88f;
            y1 = -18.35f;
            z1 = 0f;

            Instantiate(youFailedParchment, new Vector3(x1, y1, z1), Quaternion.identity);
        }
    }
}
