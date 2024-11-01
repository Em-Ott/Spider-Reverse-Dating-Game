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

       private bool first = true;
        private int index = 0;
        public float textSpeed = 0.05f;
        private bool unread = true;
        private int inProgress = 0;
        private bool[] playerChoicesChosen = new bool[] {false, false, false, false, false};


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
                if (first == true)
                {
                    StartDialog();
                    first = false;
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Rodent"; 
                }
                if ((DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index]))
                {
                    if (((index + 1) == 1) || ((index+1) == 2) && (unread == true))
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[1] + "\n" + playerChoices[2];
                    } else if (((index + 1) == 5) && playerChoicesChosen[4] == false) 
                    {
                        index = 0;
                        unread = true;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                        first = true;
                    } else if (((index + 1) == 5) && playerChoicesChosen[1] == true)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[2] +
                        "\n" + playerChoices[4];
                        inProgress = 2;
                    }
                    else 
                    {
                        NextLine();
                    }
                } else 
                {
                    StopAllCoroutines();
                    DialogueManager.Instance.dialogue.dialogueText.text = initialDialogue[index];
                }
            } else if (inProgress == 1){
                 if(Input.GetKeyDown(oneKey))
                        {
                            index = 1;
                            unread = false;
                            inProgress = 0;
                            NextLine();
                            playerChoicesChosen[0] = true;
                        } else if (Input.GetKeyDown(twoKey))
                        {
                            index = 1;
                            unread = false;
                            inProgress = 0;
                            NextLine();
                            playerChoicesChosen[1] = true;
                        } else if (Input.GetKeyDown(threeKey))
                        {
                            index = 0;
                            unread = true;
                            DialogueManager.Instance.image.SetActive(false);
                            DialogueManager.Instance.characterImage.SetActive(false); 
                            inProgress = 0;
                            first = true;
                        }
            } else if (inProgress == 2){
                if (Input.GetKeyDown(oneKey))
                {
                    index = 0;
                    unread = true;
                    DialogueManager.Instance.image.SetActive(false);
                    DialogueManager.Instance.characterImage.SetActive(false); 
                    inProgress = 0;
                    first = true;
                } else if (Input.GetKeyDown(twoKey))
                {
                    inProgress = 0;
                    NextLine();
                    playerChoicesChosen[4] = true;
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
            first = true;
            DialogueManager.Instance.image.SetActive(false);
            DialogueManager.Instance.characterImage.SetActive(false);
            index = 0;
     }
    }
}
