using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SableScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public int exisentialismPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                Debug.Log("Call Function");
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Play enter smth");
        if (collision.CompareTag("Player"))
        {
            inRange = true;
            Debug.Log("Player entered trigger area.");
     }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Debug.Log("Play exit smth");
        if (collision.CompareTag("Player"))
        {
            inRange = false;
            Debug.Log("Player exited trigger area.");
     }
    }
}
