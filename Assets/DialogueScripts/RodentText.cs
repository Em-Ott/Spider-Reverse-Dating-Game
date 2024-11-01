using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodentText : MonoBehaviour
{
     public KeyCode interactKey = KeyCode.E;
    private bool inRange;
    private string[] initialDialogue = new string[]
    {
       "The pathetic thing is crying. And more annoyingly, blocking the exit out of here.",
       "The rodent continues to cry.",
       "Leave me alone! The rodent squeaks pitifully. It's a miserable thing and you're half tempted to do as it says just to get away from the horrid noise it produces.",
       "You don't bother to question why you're able to understand what the rat says.",
       "It continues to sob. Maybe you'd be best off trying to find another exit? Or maybe you can make it move? The other spiders might have some knowledge too.",
       "You lunge at the rodent, biting it.",
       "Unfortunately, the male Latrodectus hasselti is weaker than its female counterpart. Its venom isn't even half as strong, and it's smaller.",
       "Even the female Australian Redback Spider would rarely be able to beat a rat in a fight, not that they would ever care to attack it.",
       "But you can't even scold yourself for your stupidity because you're already dead."
    };
    private string[] playerChoices = new string[]
    {
        "Excuse me?",
        "Move.",
        "Walk away.",
        "I told you to move.",
        "Bite it."
    };
    private string[] futureInteractionA = new string[] { "The rodent continues to sob." };
    private string[] futureInteractionB = new string[]
    {
        "The rodent looks at the cheese in your hand cautiously and then looks at you eagerly.",
        "When you hand it to the cheese it begins to cry further and goes on some monologue about how the cheese reminds them " +
        "of their dearest friend and all the good times they spent with them.",
        "You don't really care.",
        "Eventually the rodent walks through the wall and into the human's side of the world and you can follow, leaving this place behind forever."
    };

    // Start is called before the first frame update
    void Start()
    {
        
    }

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
