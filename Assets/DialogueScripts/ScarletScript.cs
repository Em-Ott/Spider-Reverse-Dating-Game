using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScarletScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
    public KeyCode fourKey = KeyCode.Alpha4;
    public VennaScript vennaScript; 
    public SableScript sableScript;

    private string[] initialDialogue = new string[]
    {
    "In front of you is a beautiful spider with a bow. In the hole in the wall near her is a pile of assorted objects.", 
    "You’re not sure what makes one spider more beautiful than the other. But she's probably beautiful.",
    "All of their pixel arts look the same aside from the accessory they have anyway. Not that you know what pixel art is anyway.",
    "“Hi!” Scarlet greets you cheerfully, and seems to be excited to talk to someone else.",
    "Which isn’t usual for most spiders and puts you slightly on edge.",
    "“Oh!” She perks up and excitedly begins to pull items out one by one.",
    "The first is a block of orange cheese, “These are my knick knacks! I collect them from the humans!”",
    "The second is a stuffed rat that looks similar to the other rodent. It’s about the same size too and would be difficult to drag around.",
    "“Aren’t they just neat?” She continues pulling items out excitedly, displaying them to you. Adding a fork, a lobster leg, and a die to the items in front of you.",
    "She looks off to the side, dreamily, “They’re just… cool.”",
    "“Don’t you think it’d be cool to be a human? To live your whole life without any worries about what insect you’ll have to catch for food, and go to sleep knowing you’ll be safe.”",
    "Although many humans still have to worry about their next meal and whether they’ll wake up the next morning to a spider, their life seems sublime in comparison.",
    "And if you were a human, you wouldn’t be eaten after intercourse for sustenance.",
    "Maybe then you could live a life with someone else but maybe Scarlet could be that someone else.",
    "If she aspired to live like humans, maybe their long-term relationships were also a goal of hers.",
    "Initially Scarlet is surprised by your proposition but seems rather open to it. “Being together,” she ponders aloud, “like humans?”",
    "She takes a moment to think and you run through all of the possibilities of what could go wrong.",
    "“That sounds wonderful,” she eventually says and relief floods through your body.",
    "Maybe, this would be just as good as exploring the world outside.",
    "Yeah, spiders were pretty cool too; they could climb on walls. Humans can’t do that.",
    "Humans want to do spider things so badly they made up a fictional character who’s basically a human-sized spider.",
    "“Oh, yeah I guess,” she replies but seems a bit sad that you don’t share her enthusiasm.",
    "She seems offended at your answer but ends up sighing and not taking it personally, “Most spiders think that way.”",
    "You wouldn’t understand because she’s not like the other spiders. And you are the other spider.",
    "“Was there something you wanted from me?” she asks, seemingly wanting to end this conversation as soon as possible.",
    "“You want my cheese?” She looks down at the orange block and takes it hesitantly in her hands.",
    "She doesn’t seem to want to part with it and will likely need some persuasion.",
    "She perks up at your words, “Really?”",
    "Scarlet doesn’t bother to question if you’re lying or not and immediately gives you the cheese.",
    "“Or else what?” She’s starting to get annoyed with you now and puts the cheese back down and behind her.",
    "“It’s not like you can do anything to me.”",
    "You wouldn’t be able to win in a fight, and there wasn’t really any other way to get her to hand the cheese over than that.",
    "“I wouldn’t know anything about that, sorry!” Scarlet seems genuinely clueless about it despite going into the house a lot to explore and grab items.",
    "She thoughtfully adds, “I hope it feels better soon though.”",
    "You’ve never heard the term pixel art before, as a whole word or separated into two.",
    "You understand it as drawings that are made up of tiny little squares.",
    "But isn’t everything made up of tiny little squares? Every spider you’d met so far had been, and you were made up of them too.",
    "Maybe higher forms of existence could comprehend shapes made up of things other than pixels, or maybe they only saw pixels too but were zoomed out to the point it could resemble actual circles as opposed to the ones in this game.",
    "Game.",
    "Was this all just a game?"
    };

private string[] playerChoices = new string[]
{
    "“Hi, what do you have over there?”",
    "“Could you tell me about why that rodent is crying?”",
    "She’s too scary, leave",
    "Contemplate what pixel art is",
    "“Why do you collect them?”",
    "“Can I have that cheese?”",
    "“Scarlet? Do you maybe want to live together? Like humans?”",
    "“Maybe, being a spider is pretty cool too.”",
    "“Nah, humans suck.”",
    "It doesn’t seem like there’s anything else to talk about right now.",
    "“No.”",
    "“I’ll get you another cool trinket from the human world in return.”",
    "“Give it to me or else.”",
    "“Or else I won’t get you something from the human’s world in return.”",
    "Give up and walk away, hoping that she’ll forget",
    "“What do you have over there?”",
    "Walk away"
};

private bool first = true;
private int index = 0;
public float textSpeed = 0.05f;
public bool hasCheese = false;

    // Start is called before the first frame update
    void Start()
    {
        GameObject vennaObject = GameObject.Find("Venna");
        if (vennaObject != null)
        {
            vennaScript = vennaObject.GetComponent<VennaScript>();
        }
        GameObject sableObject = GameObject.Find("Sable");
        if (sableObject != null)
        {
            sableScript = sableObject.GetComponent<SableScript>();
        }
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
                    DialogueManager.Instance.characterNameText.nameText.text = "Scarlet"; 
                }
                if (DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index])
                {
                    if (index == 4)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[1] + "\n" + playerChoices[2] + "\n" + playerChoices[3];
                    } else if (index == 8)
                    {
                        if (vennaScript.cheeseHint == true)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[4]
                            + "\n" + playerChoices[5];
                        } else 
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[4];
                        }
                    } else if (index == 33)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[15]
                        + "\n" + playerChoices[16];
                    } else if (index == 39)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[1] + "\n" + playerChoices[2];
                        sableScript.exisentialismPoints += 1;
                    } else if (index == 14)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[6]
                        + "\n" + playerChoices[7] + "\n" + playerChoices[8];
                    } else if (index == 26)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[11]
                        + "\n" + playerChoices[12];
                    } else if (index == 18)
                    {
                        ScarletEnding();
                    } else if (index == 21)
                    {
                        if (vennaScript.cheeseHint == true)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[9]
                            + "\n" + playerChoices[5];
                        } else 
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[9];
                        }
                    } else if (index == 24)
                    {
                        if (vennaScript.cheeseHint == true)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[10]
                            + "\n" + playerChoices[5];
                        } else 
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[10];
                        }
                    } else if (index == 28)
                    {
                        hasCheese = true;
                        EndDialogue();
                    } else if (index == 31)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[13]
                        + "\n" + playerChoices[14];
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
                    if (index == 4)
                    {
                        NextLine();
                    } else if (index == 8)
                    {
                        NextLine();
                    } else if (index == 33)
                    {
                        index = 4;
                        NextLine();
                    } else if (index == 39)
                    {
                        index = 4;
                        NextLine();
                    } else if (index == 14)
                    {
                        NextLine();
                    } else if (index == 26)
                    {
                        NextLine();
                    } else if (index == 21)
                    {
                        EndDialogue();
                    } else if (index == 24)
                    {
                        EndDialogue();
                    } else if (index == 31)
                    {
                        index = 26;
                        NextLine();
                    }
                } else if(Input.GetKeyDown(twoKey))
                {
                    if (index == 4)
                    {
                        index = 31;
                        NextLine();
                    } else if (index == 8 && vennaScript.cheeseHint == true)
                    {
                        index = 24;
                        NextLine();
                    } else if (index == 33)
                    {
                        //Walk Away
                        EndDialogue();
                    } else if (index == 39)
                    {
                        index = 31;
                        NextLine();
                    } else if (index == 14)
                    {
                        index = 18; 
                        NextLine();
                    } else if (index == 26)
                    {
                        index = 28;
                        NextLine();
                    } else if (index == 21 && vennaScript.cheeseHint == true)
                    {
                        index = 24;
                        NextLine();
                    } else if (index == 24 && vennaScript.cheeseHint == true)
                    {
                        NextLine();
                    } else if (index == 31)
                    {
                        EndDialogue();
                    }
                } else if(Input.GetKeyDown(threeKey))
                {
                    if (index == 4)
                    {
                        EndDialogue();
                    } else if (index == 39)
                    {
                        EndDialogue();
                    } else if (index == 14)
                    {
                        index = 21;
                        NextLine();
                    } 
                } else if (Input.GetKeyDown(fourKey))
                {
                    if (index == 4)
                    {
                        index = 33;
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
            //this is an intentional first = true
            first = true;
            DialogueManager.Instance.image.SetActive(false);
            DialogueManager.Instance.characterImage.SetActive(false); 
     }
    }

    private void EndDialogue()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
    }

    private void ScarletEnding()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        DialogueManager.Instance.endingScript.endingScreen.SetActive(true);
        DialogueManager.Instance.endingScript.endingText.text = "Ending Three:" + "\n" + "A Long Term Relationship (for spiders)" 
        + "\n" + "On day one you had your one day anniversary, on day two you went on a date, on day three you two got engaged, on day four you got married." +
        "On day five you decided to have kids with Scarlet, and on day five you were eaten alive. You lived a good life though, nothing wrong with that.";
    }
}
