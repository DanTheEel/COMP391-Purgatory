using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boxfall : MonoBehaviour
{
	private Rigidbody2D rb;
	public GameObject Box;
    // Start is called before the first frame update
    void Start()
    {
		Box = gameObject.transform.parent.gameObject;
        rb = Box.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if (collision.collider.tag == "groundcheck")
		{
			rb.bodyType = RigidbodyType2D.Dynamic;
		}
	}
}
