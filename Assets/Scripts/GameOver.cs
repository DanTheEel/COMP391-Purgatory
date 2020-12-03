using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{
    public Image customImage;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (DeadCount.deadCount == 3)
        {
            customImage.enabled = true;
        }
        else
        {
            customImage.enabled = false;
        }
    }
}
