using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DeadCount : MonoBehaviour
{
    public static int deadCount = 0;
    Text death;
	public bool endGame = false;
    // Start is called before the first frame update
    void Start()
    {
        death = GetComponent<Text>();
    }

    // Update is called once per frame
    void Update()
    {
		if (endGame == false)
		{
			death.text = "Death Count: " + deadCount;
		}
	}
}
