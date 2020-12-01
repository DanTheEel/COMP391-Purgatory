using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class mover : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;
    private float x;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
       rb.velocity = new Vector2(speed, 0.0f);
        // Previously, it was : if(this.transform.position.x<-20),
        // Changed it to -60 to accomodate the one level scene
        if (this.transform.position.x<-60)
        {
            Destroy(this.gameObject);
        }
    }
}
