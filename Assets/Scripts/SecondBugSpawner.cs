using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SecondBugSpawner : MonoBehaviour
{
    public GameObject bug, bugspawner;
    private float timer = 0f;
    private float waitTime = 7.0f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= waitTime)
        {
            Instantiate(bug, bugspawner.transform.position, bugspawner.transform.rotation);
            timer = 0.0f;
        }
    }
}
