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
        if (this.transform.position.x<-20)
        {
            Destroy(this.gameObject);
        }
    }
}
