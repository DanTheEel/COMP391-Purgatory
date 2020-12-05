using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JumpingTrigger : MonoBehaviour
{

    public GameObject ui;
    // Start is called before the first frame update
    void Start()
    {
        ui.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ui.SetActive(true);
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            ui.SetActive(false);
        }
    }
}