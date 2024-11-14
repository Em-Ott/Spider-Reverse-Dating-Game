using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VennaScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
    public KeyCode fourKey = KeyCode.Alpha4;
    public bool cheeseHint; 
    public bool sableDialogue;
    public SableScript sableScript;

    public float textSpeed;

    private string[] initialDialogue = new string[]
    {
    "The spider tilts her head at you with an inviting smile.",
    "It doesn’t matter that Venna doesn’t have a mouth, you can just feel the smile.",
    "“Well, hello there, don’t you look like a little snack?”",
    "Venna’s smile widens and she crawls closer.",
    "“Don’t mind if I do.”",
    "On the bright side you helped to carry on your species still, you can’t help but feel like your life could’ve been so much more.",
    "You’re not sure if you’re malnourished, or what that even means but it seemed like a safe response.",
    "Venna seems almost disappointed at your words.",
    "“Well, why are you here?”",
    "“That,” the spider puts an appendage to her torso sympathetically, where her heart would be if she had a human’s anatomy.",
    "The spider’s heart is actually located on the top of their non-torso big circle, the more you know!",
    "“I saw his little friend trapped and dead, such a shame really, a tragedy.” Her voice is filled with mock sadness.",
    "She reminisces and runs an appendage over her eight eyes, “They used to run around in circles near the kitchen. Stealing cheese, and…” she pauses, trying to think of it, “other things.”",
    "“I don’t really care about them enough to remember.” She drops whatever act she was putting on and looks at you tiredly.",
    "“Look, if you really are malnourished I don’t really want to eat you. How about you tell that other fellow to come on up here? And, in return, if you have any other questions I’m happy to answer.”",
    "“Well, isn’t that sweet of you?” She coos out, blinking coyly.",
    "Spiders can’t blink though, in fact you’re not even sure what blinking is.",
    "You’re pretty sure blinking is what a human, and some other animals, do.",
    "But you’ve never actually seen a human.",
    "You’ve stayed inside this wall the entire ninety something days you’ve been alive, eating the few insects that foolishly wander inside.",
    "So how would you know that they blink? That the flesh they have moves up and down to cover their eyes?",
    "Now that you think about it, there was a voice in your head narrating everything you do.",
    "This voice.",
    "And it only appeared when you started to be able to communicate with the spiders through words.",
    "It only appeared when you decided you wanted to live.",
    "Venna pouts, “You’re ravishing though, how can you expect me to resist?”",
    "Despite her words she doesn’t move closer, “Well, why’d you come up here then? You just wanted to say hi?”",
    "Then her eyes become earnest again, you’re not quite sure how spider eyes can show any emotion, “But I care enough about you.”",
    "She looks disappointed that you don’t say anything else.",
    "“Feel free to come back if you change your mind.”",
    "She takes a step forward, “You’re so cruel.”",
    "“All I’ve done is help you, and you act like this?” She freezes, opting to cross her arms. “Leave, before I change my mind.”",
    "You don’t have to ask what she’s going to change her mind on.",
    "You should probably leave, and not talk to her again.",
    "Spiders’ eyes can’t show emotions.",
    "As a matter of fact spiders can’t really even feel emotions, much less think.",
    "So what is this voice you’re hearing right now, if not your thoughts?",
    "It only appeared when you started to be able to communicate with the spiders through words.",
    "It only appeared when you decided you wanted to live.",
    "Can spiders even want to live? Or do they just live by instinct? Is there a difference?",
    "“Hi,” she replies, copying your words, with a small smile. “Let me know if you ever change your mind.”",
    "The spider seems angry at that, “Fine! If that’s what you want!”",
    "“Don’t come crawling back then!”",
    "She’s clearly offended by your words and probably won’t take kindly if you talk to her again.",
    "You should probably find a different way to get the rodent to move.",
    "“You’re back, did you change your mind?” Venna asks, the smile on her face is very sweet and almost tempting enough for you to say that you did change your mind.",
    "But, at the same time, you don't really want to be eaten.",
    "Venna seems pleased with herself at your sudden change of heart and reaches out an appendage which you take with your own.",
    "At the very least your death won’t be in vain.",
    "“Hi,” She says back. It doesn’t seem like she’s taking you very seriously and is just waiting for the inevitable moment you change your mind.",
    "“I haven’t seen that other fellow up here, have you talked to him yet?” Venna asks, referring to the spider below the two of you, Sable.",
    "“Well, go bring him up here then.” She seems impatient.",
    "“And he didn’t want to come, did he?” She lets out a wistful sigh, “Figures.”",
    "“Well, what can you do right?” You’re a bit surprised she doesn’t go down to talk to him herself but she seems relatively content to just stay up here.",
    "With that she turns to you, and you’re half-afraid you’ll be her new target.",
    "Instead, she holds up her end of the bargain despite you not holding up yours, “What did you want to ask then?”",
    "She expresses gratitude toward you with a polite, “Thank you,” and by not killing you before you leave."
    };

    private string[] playerChoices = new string[]
    {
    "“Do you want a bite?”", 
    "“Sorry, but I'm malnourished.”",
    "“Please don’t eat me.”", 
    "“Stay away from me.”",
    "“Could you tell me about why that rodent is crying?”", 
    "“I just wanted to say hi.”",
    "Contemplate what blinking is", 
    "Walk Away",
    "“Thanks, that’s nice.”", 
    "“I don’t want you to care about me.”", 
    "Contemplate how spider eyes can show any emotion.", 
    "“Yeah I did.”",
    "“No, I was wondering if you could tell me why the rodent is crying?”",
    "“No, I just wanted to say hi.”",
    "No",
    "Yes",
    "“Nothing, I just wanted to let you know he declined.”"
    };

    private int index = 0;
    private bool first = true;
    public bool askForVenna = false;
    private bool[] futureInteractions = new bool[] {false, false};

    private bool choiceTwo = false;


    // Start is called before the first frame update
    void Start()
    {
        GameObject sableObject = GameObject.Find("Sable");
        if (sableObject != null)
        {
            sableScript = sableObject.GetComponent<SableScript>();
        }
        cheeseHint = false;
        sableDialogue = false;
        index = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
                if (first == true && askForVenna == false)
                {
                    StartDialog();
                    first = false;
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Venna"; 
                } else if (futureInteractions[0] == true)
                {
                    index = 45;
                    StartDialog();
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Venna"; 
                    futureInteractions[0] = false;
                } else if (futureInteractions[1] == true)
                {
                    VennaKills();
                } else if (askForVenna == true && first == true)
                {
                    index = 50;
                    StartDialog();
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Venna"; 
                    first = false;
                }
                if (DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index])
                {
                    if (index == 2)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[1] + "\n" + playerChoices[2] + "\n" + playerChoices[3];
                    } else if (index == 5)
                    {
                        VennaRomance();
                    } else if (index == 8)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[4]
                        + "\n" + playerChoices[5];
                    } else if (index == 26)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[4]
                        + "\n" + playerChoices[5];
                    } else if (index == 44)
                    {
                        EndDialogue();
                        futureInteractions[1] = true;
                    } else if (index == 40)
                    {
                        EndDialogue();
                        futureInteractions[0] = true;
                    } else if (index == 13)
                    {
                        cheeseHint = true;
                        if (askForVenna == true)
                        {
                            EndDialogue();
                            first = true;
                        } else if (askForVenna == false && choiceTwo == false)
                        {
                            NextLine();
                        } else if (askForVenna == false && choiceTwo == true)
                        {
                            index = 26;
                            NextLine();
                        } 
                    } else if (index == 16)
                    {
                        index = 13;
                        NextLine();
                    } else if (index == 24)
                    {
                        EndDialogue();
                        askForVenna = true;
                        first = true;
                        sableScript.exisentialismPoints += 1;
                    } else if (index == 14)
                    {
                        EndDialogue();
                        askForVenna = true;
                        first = true;
                    } else if (index == 27)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[8]
                        + "\n" + playerChoices[9] + "\n" + playerChoices[10];
                    } else if (index == 29)
                    {
                        futureInteractions[0] = true;
                        EndDialogue();
                    } else if (index == 33)
                    {
                        futureInteractions[1] = true;
                        EndDialogue();
                    } else if (index == 39)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[8]
                        + "\n" + playerChoices[9];
                    } else if (index == 48)
                    {
                        VennaRomance();
                    } else if (index == 49)
                    {
                        futureInteractions[0] = true;
                        EndDialogue();
                    } else if (index == 51)
                    {
                        askForVenna = true;
                        first = true;
                        EndDialogue();
                    } else if (index == 55)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[4]
                        + "\n" + playerChoices[16];
                    } else if (index == 56)
                    {
                        EndDialogue();
                        first = true;
                    } else if (index == 50)
                    {
                        if (sableScript.talkedToSable == true)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[14]
                            + "\n" + playerChoices[15];
                        } else 
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[14];
                        }
                    } else if (index == 46)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[11]
                        + "\n" + playerChoices[12] + "\n" + playerChoices[13];
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
                    } else if (index == 8)
                    {
                        index = 8;
                        NextLine();
                    } else if (index == 26)
                    {
                        index = 8;
                        NextLine();
                    } else if (index == 14)
                    {
                        index = 16;
                        NextLine();
                    } else if (index == 39)
                    {
                        index = 27;
                        NextLine();
                    } else if (index == 27)
                    {
                        NextLine();
                    } else if (index == 55)
                    {
                        index = 8;
                        NextLine();
                    } else if (index == 50)
                    {  
                        NextLine();
                    } else if (index == 46)
                    {
                        NextLine();
                    }
                } else if(Input.GetKeyDown(twoKey))
                {
                    if (index == 2)
                    {
                        index = 5;
                        NextLine();
                    } else if (index == 8)
                    {
                        index = 39;
                        NextLine();
                    } else if (index == 26)
                    {
                        choiceTwo = true;
                        index = 14;
                        NextLine();
                    } else if (index == 14)
                    {
                        EndDialogue();
                        askForVenna = true;
                    } else if (index == 39)
                    {
                        index = 29;
                        NextLine();
                    } else if (index == 27)
                    {
                        index = 29;
                        NextLine();
                    } else if (index == 55)
                    {
                        index = 55;
                        NextLine();
                    } else if (index == 50 && sableScript.talkedToSable == true)
                    {
                        index = 51;
                        NextLine();
                    } else if (index == 46)
                    {
                        index = 8;
                        NextLine();
                    }
                } else if(Input.GetKeyDown(threeKey))
                {
                    if (index == 2)
                    {
                        index = 24;
                        NextLine();
                    } else if (index == 27)
                    {
                        index = 33;
                        NextLine();
                    } else if (index == 46)
                    {
                        index = 48;
                        futureInteractions[0] = true;
                        NextLine();
                    }
                } else if(Input.GetKeyDown(fourKey))
                {
                    if (index == 2)
                    {
                        index = 40;
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
            DialogueManager.Instance.image.SetActive(false);
            DialogueManager.Instance.characterImage.SetActive(false);
     }
    }

    private void VennaKills()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        DialogueManager.Instance.endingScript.endingScreen.SetActive(true);
        DialogueManager.Instance.endingScript.endingText.text = "Ending Three:" + "\n" + "DEATH" 
        + "\n" + "Romance is dead and so are you.";
    }

    private void VennaRomance()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        DialogueManager.Instance.endingScript.endingScreen.SetActive(true);
        DialogueManager.Instance.endingScript.endingText.text = "Ending Two:" + "\n" + "DEATH" 
        + "\n" + "Romance isn't dead but you are.";
    } 

    private void EndDialogue()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
    }
}
