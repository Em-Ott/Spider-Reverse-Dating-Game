using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellatrixScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public SableScript sableScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject sableObject = GameObject.Find("Sable");
        if (sableObject != null)
        {
            sableScript = sableObject.GetComponent<SableScript>();
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
