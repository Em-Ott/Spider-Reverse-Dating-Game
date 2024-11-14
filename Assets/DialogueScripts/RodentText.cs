using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RodentText : MonoBehaviour
{
    public KeyCode interactKey = KeyCode.E;
    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
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
       "But you can't even scold yourself for your stupidity because you're already dead.",
       "The rodent continues to sob.",
       "The rodent looks at the cheese in your hand cautiously and then looks at you eagerly.",
        "When you hand it to the cheese it begins to cry further and goes on some monologue about how the cheese reminds them " +
        "of their dearest friend and all the good times they spent with them.",
        "You don't really care.",
        "Eventually the rodent walks through the wall and into the human's side of the world and you can follow, leaving this place behind forever."
    };
    private string[] playerChoices = new string[]
    {
        "Excuse me?",
        "Move.",
        "Walk away.",
        "I told you to move.",
        "Bite it."
    };

       private bool first = true;
       private bool unread = true;
        private int index = 0;
        public float textSpeed = 0.05f;
        private int inProgress = 0;
        private bool[] playerChoicesChosen = new bool[] {false, false, false, false, false};
        private bool stuck = false;


    // Start is called before the first frame update
    void Start()
    {
    }

    void Update()
    {
        if (DialogueManager.Instance.rubyScript.violinPlayed == true)
        {
            Destroy(gameObject);
        }
        if (inRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                
                if (first == true)
                {
                    StartDialog(); //This causes line 0 to be played
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Rodent"; 
                    first = false;
                } else if ((DialogueManager.Instance.scarletScript.hasCheese == true) && (stuck == false))
                {
                    index = 10;
                    stuck = true;
                } else if (unread == false)
                {
                    index = 9;
                    StartDialog();
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Rodent"; 
                }
                if (DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index])
                {
                    //If it does finish reading through text it goes to the next line
                    //We do not want this for 0, 1, 3, and 4. We only want 5 to trigger 
                    //If playerChoicesChosen[4] = true
                    //If playerChoicesChosen[2] = true then reset scene
                    //Rundown:
                    /*
                    Dialogue 0 -> Choices: 0, 1, 2
                    Choice 0 -> Dialogue 1 -> Choices: 1, 2
                    Choice 1 -> Dialogue 2, 3 -> Choices: 2, 3, 4
                    Choice 2 -> Reset
                    Choice 3 -> Dialogue 4 -> Choice 2, 4
                    Choice 4 -> Dialogue 5-8
                    If (first == false) Dialogue 9
                    If (cheese == true) (check before first == false) play remaining dialogue and have
                    rodent disappear
                    */
                    /*
                    How to code this:
                    If (index == 0)
                    Show text for options and set inProgress to true (see inProgress function)
                    */
                    if (index == 0)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[1] + "\n" + playerChoices[2];
                    } else if (index == 1){
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[1] 
                        + "\n" + playerChoices[2];
                    } else if (index == 3){
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[2] 
                        + "\n" + playerChoices[3] + "\n" + playerChoices[4];
                    } else if (index == 4){
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[2] 
                        + "\n" + playerChoices[4];
                    } else if (index == 8)
                    {
                        KilledEnding();
                    } else if (index == 9)
                    {
                        //This isn't hiding it I don't know why but it isn't too big
                        //of an issue so I'm not going to worry about it for now
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                    }else if (index == 13)
                    {
                        NextLine();
                        CheeseEnding();
                    } else{
                        //Continues reading to the next line if a choice isn't being made
                        NextLine();
                    }
                } else 
                {
                    StopAllCoroutines();
                    DialogueManager.Instance.dialogue.dialogueText.text = initialDialogue[index];
                }
            } else if (inProgress == 1){
                //This function will check for if oneKey, twoKey, or threeKey is pressed down
                //If they are pressed down then playerChoicesChosen[#] == true
                //# is determined through current dialogue which they are on
                //Index is set to the appropriate dialogue which will be dialogue before next dialogue
                //NextLine() is immediately called (index gets one added to it and next dialogue is called)
                //inProgress is set to 0
                 if(Input.GetKeyDown(oneKey))
                 {
                    if (index == 0)
                    {
                        NextLine();
                        //Sends to appropriate dialogue
                    } else if (index == 1)
                    {
                        NextLine();
                    } else if (index == 3)
                    {
                        ResetEncounter();
                    } else if (index == 4)
                    {
                        unread = false;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                    }
                 } else if(Input.GetKeyDown(twoKey))
                 {
                    if (index == 0)
                    {
                        index = 1;
                        NextLine();
                        //Sends to appropriate dialogue
                    } else if (index == 1)
                    {
                        ResetEncounter();
                    } else if (index == 3)
                    {
                        NextLine();
                    } else if (index == 4)
                    {
                        NextLine();
                    }
                 } else if(Input.GetKeyDown(threeKey))
                 {
                    if (index == 0)
                    {
                        ResetEncounter();
                        //Sends to appropriate dialogue
                    } else if (index == 3)
                    {
                        index = 4;
                        NextLine();
                    }
                 }
            }
        }
    }
    void StartDialog()
    {
        DialogueManager.Instance.image.SetActive(true);
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Type each character 1 by 1
        foreach(char c in initialDialogue[index].ToCharArray())
        {
            DialogueManager.Instance.dialogue.dialogueText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    //Adds one to the index and goes to the line after the current line 
    void NextLine()
    {
        if (index < initialDialogue.Length - 1)
        {
            index++;
            DialogueManager.Instance.dialogue.dialogueText.text = string.Empty;
            StartCoroutine(TypeLine());
        } else 
        {
            DialogueManager.Instance.image.SetActive(false);
            DialogueManager.Instance.characterImage.SetActive(false); 
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
            DialogueManager.Instance.image.SetActive(false);
            DialogueManager.Instance.characterImage.SetActive(false);
            index = 0;
     }
    }

    private void ResetEncounter()
    {
        index = 0;
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        inProgress = 0;
        first = true;
    }

    private void KilledEnding()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        DialogueManager.Instance.endingScript.endingScreen.SetActive(true);
        DialogueManager.Instance.endingScript.endingText.text = "Ending One:" + "\n" + "DEATH" 
        + "\n" + "You bit off more than you could chew.";
    }
    private void CheeseEnding()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        DialogueManager.Instance.endingScript.endingScreen.SetActive(true);
        DialogueManager.Instance.endingScript.endingText.text = "Ending Seven:" + "\n" + "Cheese" 
        + "\n" + "Top 3 Cheeses 2024:" + "\n 1. Mozzarella \n 2. Sriracha Gouda \n 3. Munster" 
        + "\n Congratulations! You won and lived for like another month! Yay spiders!";
    }
}
