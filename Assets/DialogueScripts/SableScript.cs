using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SableScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public VennaScript vennaScript; 
    public int exisentialismPoints = 0;
    // Start is called before the first frame update
    void Start()
    {
        GameObject vennaObject = GameObject.Find("Venna");
        if (vennaObject != null)
        {
            vennaScript = vennaObject.GetComponent<VennaScript>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
            }
        }

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = true;
     }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            inRange = false;
     }
    }
}
