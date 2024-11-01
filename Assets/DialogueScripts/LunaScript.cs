using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public bool violinHint; 
    public SableScript sableScript;
    private string[] initialDialogue = new string[]
    {
    "The spider in front of you was sleeping until you landed on her web.", 
    "Now, Luna, looks at you, still clearly half-asleep and waits for you to either explain your purpose or leave.", 
    "She nods and points to the right with one of her appendages.", 
    "“That other spider with the violin,” she pauses to yawn before continuing, “can play very loudly, to the point it can wake me up.”", 
    "“It has a very high pitch to the point it may hurt the thing’s ears,” She explains further before covering her eyes with her leg again.", 
    "She nods again.", 
    "She doesn’t uncover her eyes and only simply responds, “There’s no point in that.”",
    "She remains silent too and after a moment falls back asleep.",
    "You’re not much of a threat even if you attacked her while she was sleeping.",
    "It’s not much of a competition at all, the female Australian Redback is both larger and more venomous than the male.",
    "Luna remains asleep. It wouldn’t be nice to bother her."
    };

    private string[] playerChoices = new string[]{
        "“Excuse me? Can you help me get the rodent to move?”",
	    "Remain there silently, until she talks first.",
	    "Leave",
        "“Thank you!”",
	    "“Is that it? You aren’t going to try and date me or kill me or anything?”",
        "Fight her for no particular reason other than wanting to fight"
    };

    // Start is called before the first frame update
    void Start()
    {
        GameObject sableObject = GameObject.Find("Sable");
        if (sableObject != null)
        {
            sableScript = sableObject.GetComponent<SableScript>();
        }
        violinHint = false;
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
