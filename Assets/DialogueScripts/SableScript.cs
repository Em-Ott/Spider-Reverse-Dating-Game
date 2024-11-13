using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SableScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
    public VennaScript vennaScript; 
    public int exisentialismPoints = 0;

    private string[] initialDialogue = new string[]
    {
    "There is a spider, Sable, standing near the edge of the floor.",
    "You’re not sure what’s past it, or even if there is anything past it.",
    "On the bright side, you can let down your guard around him since this spider won’t eat you.",
    "“I’m enjoying the view,” He replies, continuing to gaze at the wooden wall over the ledge across from you.",
    "It’s a really bad view.",
    "“Yeah, they’re just above us.” He acts as if those words are enough of an explanation.",
    "But then a sudden realization crosses his mind, “Oh! You don’t know how to get up, right, I forgot about that.”",
    "The spider turns to you and then points further out to the right, “Just keep going to the right and if you can’t keep going anymore then go up.” He’s implying that you simply walk over the ledge.",
    "“I wouldn’t recommend going up there though.” He doesn’t seem to have positive opinions of either of the two spiders you just mentioned.",
    "You didn’t know spiders could form opinions of each other.",
    "“No you won’t.” His words are dismissive and realizing how they come off quickly follows up with more words, “I understand why you’d think that, but you won’t die.”",
    "Then slightly changing the topic he goes on to ask you, “Are you scared of dying?” It’s a very simple question.",
    "“Most animals are,” he says, after all the animals that weren’t scared of dying probably already died off so their genes weren’t in this world unless it was beneficial to evolution.",
    "The male Australian Redback probably had a smaller fear than most of dying given how they offer themselves up to be cannibalized for the betterment of their offspring.",
    "“Yeah, I don’t think our kind is meant to be,” he says referring to the male Australian Redback spider.",
    "After all, sacrificing yourself to be cannibalized isn’t something most species would do, even if it was for the betterment of their offspring.",
    "“Sometimes I’m scared about it,” he admits, “I mean, what will happen to me when I’m dead? I don’t know and it’s not like I can experience death before I experience it forever.”",
    "You’re not sure what happens after everything.",
    "Humans come up with many different ways to console themselves with the notion of existing.",
    "But you’re just a spider.",
    "You couldn’t come up with anything.",
    "“Yeah, I guess.” He nods and the two of you remain silent for a bit, and eventually the conversation naturally ends.",
    "The voice in your head, was the narrator of a game.",
    "Most humans claim to have inner monologues but, you’re a spider, and who’s to say those humans aren’t just characters in a game as well?",
    "There had been too many discrepancies from the beginning.",
    "This was probably just a solution the person writing this thought up so they didn’t have to fix all the biological inaccuracies which spiders have here from blushing to talking.",
    "It was just another ending to the game and it’s not like you could think out anything that wasn’t already predetermined.",
    "You were only self aware because you were told you could become self aware.",
    "Sable was worried about the wrong thing, his existence wouldn’t come to an end because of death but rather because of this game’s ending.",
    "“Yeah, let me know if you need anything else,” He replies and focuses back on the wall that’s across the ledge.",
    "You really don’t understand why he’d be so fixated on it.",
    "But it doesn’t matter.",
    "“If you ever want to come back and talk I’m always open, even if it’s about the same old things.”",
    "“Right, that,” Sable nods at your words as if he was expecting them.",
    "Rather than turning to face you he just continues looking outward, “I don’t think I’ll be doing that anymore, sorry.”",
    "“If you ever want to come back and talk I’m always open, even if it’s about the same old things.”",
    "You can’t really change his opinion or force him to do anything."
    };

    private string[] playerChoices = new string[]
    {
    "“What are you doing?”",
    "“Do you know how to get to Venna or the spider with the violin?”",
    "“Venna wants to see you.”",
    "“If I do that I’ll die.”",
    "“Okay, thank you.”",
    "“Yes.”",
    "“No.”",
    "“I don’t know either.”",
    "“Does it matter? What we do right now is the only thing we can change.”",
    "“Does it matter? This is all just a video game.”"
    };
    private bool first = true;
    private int index = 0;
    public float textSpeed = 0.05f;
    public bool talkedToSable = false;


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
                if (first == true)
                {
                    StartDialog();
                    first = false;
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Sable"; 
                }
                if (DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index])
                {
                    if (index == 2)
                    {
                        if (vennaScript.askForVenna == true)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                            + "\n" + playerChoices[1] + "\n" + playerChoices[2];
                        } else
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                            + "\n" + playerChoices[1];
                        }
                    } else if (index == 4)
                    {
                        endDialogue();
                    }else if (index == 9)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[3]
                        + "\n" + playerChoices[4];
                    } else if (index == 36)
                    {
                        talkedToSable = true;
                        endDialogue();
                    } else if (index == 11)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[5]
                        + "\n" + playerChoices[6];
                    } else if (index == 32)
                    {
                        endDialogue();
                    } else if (index == 16)
                    {
                        if (exisentialismPoints >= 6)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[7]
                            + "\n" + playerChoices[8] + "\n" + playerChoices[9];
                        } else
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[7]
                            + "\n" + playerChoices[8];
                        }
                    } else if (index == 13)
                    {
                        index = 15;
                        NextLine();
                    } else if (index == 20)
                    {
                        exisentialismPoints += 1;
                        endDialogue();
                    } else if (index == 21)
                    {
                        endDialogue();
                    } else if (index == 28)
                    {
                        SelfAwareEnding();
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
            } else 
            {
                if(Input.GetKeyDown(oneKey))
                {
                    if (index == 2)
                    {
                        NextLine();
                    } else if (index == 9)
                    {
                        NextLine();
                    } else if (index == 11)
                    {
                        NextLine();
                    } else if (index == 16)
                    {
                        index = 16;
                        NextLine();
                    }
                } else if(Input.GetKeyDown(twoKey))
                {
                    if (index == 2)
                    {
                        index = 4;
                        NextLine();
                    } else if (index == 9)
                    {  
                        index = 28;
                        NextLine();
                    } else if (index == 11)
                    {
                        index = 13;
                        NextLine();
                    } else if (index == 16)
                    {
                        index = 20;
                        NextLine();
                    }
                } else if(Input.GetKeyDown(threeKey))
                {
                    if (index == 2 && vennaScript.askForVenna == true)
                    {
                        index = 32;
                        NextLine();
                    } else if (index == 16 && exisentialismPoints >= 6)
                    {
                        index = 21;
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
            //setting index to 0 is intentional here don't remove
            index = 0;
     }
    }

    private void SelfAwareEnding()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        DialogueManager.Instance.endingScript.endingScreen.SetActive(true);
        DialogueManager.Instance.endingScript.endingText.text = "Ending Nine:" + "\n" + "Self Aware" 
        + "\n" + "Even self aware video game characters aren't actually self aware. \n Thanks for Playing!";
    }

    private void endDialogue()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
    }
}
