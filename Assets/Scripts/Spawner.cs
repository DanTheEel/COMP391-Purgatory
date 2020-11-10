using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour
{
    public GameObject spawn;//whats being spawned
    public float x,y;//x and y values of the objects transform
    private float timer = 0.0f;
	private float randomTimer = 10.0f;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(spawn, new Vector3(x, y, 0), Quaternion.identity);
    }

    // Update is scalled once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer>randomTimer)
        {
			randomTimer = Random.Range(8.0f, 15.0f);
            timer = 0;
            Instantiate(spawn, new Vector3(x, y, 0), Quaternion.identity);
			Debug.Log(randomTimer);
        }
    }
}
