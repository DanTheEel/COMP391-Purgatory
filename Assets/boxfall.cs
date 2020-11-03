using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxfall : MonoBehaviour
{
	private Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "groundcheck")
		{
			Debug.Log("Player");
			rb.bodyType = RigidbodyType2D.Dynamic;
		}
	}
}
