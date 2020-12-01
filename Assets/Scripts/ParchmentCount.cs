using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ParchmentCount : MonoBehaviour
{
    public static int parchmentCount = 0;
    Text Count;

    // Start is called before the first frame update
    void Start()
    {
        Count = GetComponent<Text>(); 
    }

    // Update is called once per frame
    void Update()
    {
        Count.text = "Parchment: " + parchmentCount;
    }
}
