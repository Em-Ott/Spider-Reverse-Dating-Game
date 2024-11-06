using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellatrixScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
    public SableScript sableScript;
    public string currentString;
    private string[] initialDialogue = new string[]
    {
    "In front of you are two spiders, one alive and one dead.",
    "You recognize them, Bellatrix and Scraps.",
    "They’re from the same egg sac as you, everyone here is.",
    "Most of your two hundred or so siblings were eaten, and most of those that weren’t left here.",
    "You wished that you left too.",
    "Since Bellatrix is currently eating it probably won’t hurt to talk to her– you probably won’t die.",
    "The spider turns to you, “Is there something you need?”",
    "She doesn’t seem angry but two of her legs move up and down impatiently. It’d be better to be quick so she can get back to her meal.",
    "Bellatrix looks at you like you’re crazy and lets out a laugh.",
    "Can spiders even laugh?",
    "It doesn’t make sense that spiders can even talk to each other, in fact you don’t remember talking to anyone else before today.",
    "“Are you serious?” She asks incredulously, pausing for a moment before decisively declining, “No.”",
    "“Is there anything else?”",
    "In the past you didn’t really communicate with your siblings.",
    "In fact you stayed far away from them.",
    "But you remember that when you did have to communicate with them you used vibrations through the cob webs, or pheromones were used.",
    "It was strange how you could suddenly communicate so clearly with them but you don’t question it much more, at least for now.",
    "“So that’s what that insufferable noise is. I don’t know for sure but I can guess.”",
    "“Recently, the human bought a few rat traps. Based on the awful scent plaguing these walls I can only guess that’s one of its friends.”",
    "“I’d ask Venna about it though, she left the walls a few days ago. I’m sure she’s back by now.”",
    "“Anything else?”",
    "“I’m not too sure where she is right now but she tends to like being high up.”",
    "“Now scram. You’re interrupting my dinner.”",
    "You’re not sure if it can even be called dinner, you don’t know what time of day it is or if spiders have separate meals.",
    "But you’re not going to point that out to her, something tells you that if you do you’ll end up dying.",
    "Bellatrix is busy eating. You’re not dumb enough to interrupt her any further."
    };

    private string[] playerChoices = new string[] 
    {
    "“Excuse me, Bellatrix?”",
    "“Bellatrix.”",
    "Walk Away",
    "“Could you kill the rodent that’s blocking the exit for me?”",
    "“Do you know why that rodent is crying?”",
    "“No, sorry.”",
    "Contemplate why spiders can’t talk.",
    "“Where’s Venna?”"
    };

        private bool first = true;
       private bool unread = true;
        private int index = 0;
        public float textSpeed = 0.05f;
        private int inProgress = 0;
        private bool[] playerChoicesChosen = new bool[] {false, false, false, false, false};


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
                if (first == true)
                {
                    StartDialog();
                    first = false;
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Bellatrix"; 
                } else if (unread == false)
                {
                    index = 25;
                    StartDialog();
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Bellatrix"; 
                }
                if (DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index])
                {
                    /*
                    Dialogue 5 -> Choice 0, 1, 2
                    Choice 0, 1 -> Dialogue 6-7
                    Dialogue 7 -> Choices 3, 4, 5
                    Choice 3 -> Dialogue 8-12 -> Choices 6, 4, 5
                    Choice 6 -> Dialogue 13-16 -> Choices 4, 5
                    Choice 4 -> 17-20 -> Choice 7, 5
                    Choice 7 -> Dialogue 21
                    */
                    if (index == 5)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[1] + "\n" + playerChoices[2];
                    } else if (index == 7)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[3]
                        + "\n" + playerChoices[4] + "\n" + playerChoices[5];
                    } else if (index == 12)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[6]
                        + "\n" + playerChoices[4] + "\n" + playerChoices[5];
                    } else if (index == 16)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[4] 
                        + "\n" + playerChoices[5];
                    } else if (index == 20)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[7] 
                        + "\n" + playerChoices[5];
                    } else
                    {
                        NextLine();
                    }
                } else 
                {
                    StopAllCoroutines();
                    DialogueManager.Instance.dialogue.dialogueText.text = initialDialogue[index];
                }
                //DialogueManager.Instance.dialogue.dialogueText.text 
            } else if (inProgress == 1)
            {
                if(Input.GetKeyDown(oneKey))
                {
                    if (index == 12)
                    {
                        sableScript.exisentialismPoints += 1;
                    }
                    NextLine();
                    
                } else if (Input.GetKeyDown(twoKey))
                {
                    if (index == 5)
                    {
                        NextLine();
                    } else if (index == 7)
                    {
                        index = 16;
                        NextLine();
                    } else if (index == 12)
                    {
                        index = 16;
                        NextLine();
                    } else if (index == 16)
                    {
                        unread = false;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                    } else if (index == 20)
                    {
                        unread = false;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                    }
                } else if (Input.GetKeyDown(threeKey))
                {
                    if (index == 5 || index == 7 || index == 12)
                    {
                        ResetEncounter();
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
}
