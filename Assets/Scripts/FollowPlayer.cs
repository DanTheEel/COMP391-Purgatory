using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }
    public Vector3 myPos;
    public Transform myPlay;

    // Update is called once per frame
    public void Update()
    {
        transform.position = myPlay.position + myPos;
    }

}
