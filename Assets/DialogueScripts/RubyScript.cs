using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public LunaScript lunaScript; 
    public SableScript sableScript;

    // Start is called before the first frame update
    void Start()
    {
        GameObject lunaObject = GameObject.Find("Luna");
        if (lunaObject != null)
        {
            lunaScript = lunaObject.GetComponent<LunaScript>();
            //READS SUCCESSFULLY YAYYYY
        }

        GameObject sableObject = GameObject.Find("Sable");
        if (sableObject != null)
        {
            sableScript = sableObject.GetComponent<SableScript>();
            //READS SUCCESSFULLY YAYYYY
        }
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
