using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RWLScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
    public KeyCode fourKey = KeyCode.Alpha4;
    public KeyCode fiveKey = KeyCode.Alpha5;
    public SableScript sableScript;

    private string[] initialDialogue = new string[]
    {
    "“Please, please save me!”",
    "It’s a Rough Woodlouse, trapped inside of some cobweb. For some reason it’s begging you, a spider, to save it.",
    "“Because it’s the right thing to do!” It sputters out.",
    "At your lack of reaction it continues blabbering for no reason, “I can help you! Is there anything you need?”",
    "It’s tightly wrapped in the cobweb you won’t be able to help it escape.",
    "“If you continue going to the right and then go up you’ll see them!” It says frantically waiting to be set free.",
    "“How am I supposed to know how to get them? I don’t know! Maybe you just need to take a leap of faith!” It's taking a leap of faith by putting its trust in you.",
    "“I think the spider with a bow may’ve dragged some in earlier this week, I saw them do it!” This Woodlouse must’ve lived here for a while, it’s a surprise it only got caught recently.",
    "“The loud one? I think they call her Ruby!” You’re not sure how the Woodlouse knows all of your names.",
    "The Woodlouse quiets and stills.",
    "The Woodlouse continues to cry out pathetically. Its noise is nothing compared to the rodent though.",
    "It pauses, contemplating the question before hurriedly responding, “Well, I just do. I don’t want to die like this at the very least.”",
    "It’s tightly wrapped in the cobweb you won’t be able to help it escape.",
    "But maybe you could make its death a bit easier.",
    "The Woodlouse is, at first, upset at your words. Of course it is, it wants to live, just like you. But just as you can’t help, it can’t force you to help.",
    "“That sounds alright,” it eventually replies.",
    "It isn’t an ideal outcome but what can you expect when the only guarantee is death?",
    "When you get past the rodent maybe the only thing that waits for you will be death.",
    "Will everything still be worth it then?",
    "You have to hope so, or else this is all for nothing.",
    "You stay by the Woodlouses’ side until it stills completely.",
    "The Woodlouse is taken aback and panics further at your words, tangling itself further into the cobweb.",
    "“No! No! Absolutely not!” It’s resolute in its desires.",
    "The Woodlouse replies without missing a beat, “Soon is not now though!”",
    "Even though every moment it exists from here unto death will be spent trapped and in suffering it still wants to live.",
    "What a stubborn, annoying, bug. But it’s only natural for most bugs.",
    "Not for the male Black Widow though, spiders which voluntarily sacrifice themselves for the survival of future generations.",
    "Even though you’re walking away from the death where you sacrifice yourself, you may still be walking toward your own death.",
    "Maybe when you get past the rodent maybe the only thing that waits for you will be death.",
    "Will everything still be worth it then?",
    "You have to hope so, or else this is all for nothing.",
    "The Rough Woodlouse shrieks out annoyed, “You spiders are all the same! Beasts! Absolute beasts that eat their own kind!”",
    "It continues to call spiders every vile word in the dictionary it can think of.",
    "The Rough Woodlouse is quiet, it seems to be coming to terms with its death.",
    "For some reason that makes you think, maybe it’ll be okay.",
    "The Rough Woodlouse is dead. At least it isn’t crying anymore."
    };

    private string[] playerChoices = new string[]
    {
    "“Why should I?”",
    "“Be quiet unless you want to get eaten right now.”",
    "Walk away, there’s no reason to bother yourself with this small fry.",
    "“Why do you want to live?”",
    "“I can’t find Venna or Ruby.”",
    "“I can’t get to Venna or Ruby.”",
    "“Do you know anyone who might have cheese?”",
    "“Who is the spider with the violin?”",
    "“No.”",
    "“I can’t help you escape, but I can stay by your side until you die.”",
    "“I can’t help you escape, but I can kill you faster if you’d rather die quickly.”",
    "Leave the Woodlouse alone, you can’t help it. Whatever you do will be meaningless.",
    "“Why not? You’re going to die soon anyways.”",
    "“I understand.”"
    };

    private bool first = true;
    private int index = 0;
    public float textSpeed = 0.05f;
    //dT = dialogueTick checks times players interacted (there is a reason it's a bool and not int)
    private bool[] dT = new bool[] {false, false};
    private bool hatred = false;
    private bool deathConsolation = false;
    private string questions = "";


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
                    DialogueManager.Instance.characterNameText.nameText.text = "Woodlouse"; 
                } else if (dT[1] == true)
                {
                    index = 35;
                    StartDialog();
                    first = false;
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Woodlouse"; 
                } else if (dT[0] == true && hatred == true)
                {
                    index = 31;
                    StartDialog();
                    first = false;
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Woodlouse"; 
                    dT[0] = false;
                } else if (dT[0] == true && deathConsolation == true)
                {
                    index = 33;
                    StartDialog();
                    first = false;
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Woodlouse"; 
                    dT[0] = false;
                } 
                if (DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index])
                {
                    if (index == 1)
                    {
                        if (sableScript.exisentialismPoints >= 2)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                            + "\n" + playerChoices[1] + "\n" + playerChoices[2] + "\n" + playerChoices[3];
                        } else 
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                            + "\n" + playerChoices[1] + "\n" + playerChoices[2];
                        }
                    } else if (index == 9 || index == 10)
                    {
                        dT[0] = true;
                        hatred = true;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                    } else if (index == 13)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[9]
                        + "\n" + playerChoices[10] + "\n" + playerChoices[11];
                    } else if (index >= 4 && index <= 8)
                    {
                        //for loop if index = to number don't print else print
                        //questions = temp var
                        for (int i = 0; i < 4; ++i)
                        {
                            if (index == (i+5))
                            {
                                //do nothing questions stays the same
                            } else 
                            {
                                questions = questions + playerChoices[i+5] + "\n";
                            }
                            DialogueManager.Instance.dialogue.dialogueText.text = questions;
                        }
                    } else if (index == 20)
                    {
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        sableScript.exisentialismPoints += 1;
                        dT[1] = true;
                    } else if (index == 22)
                    {
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[9]
                        + "\n" + playerChoices[11] + "\n" + playerChoices[12];
                    } else if (index == 30)
                    {
                        sableScript.exisentialismPoints += 1;
                        dT[0] = true;
                        deathConsolation = true;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                    } else if (index == 31)
                    {
                        dT[0] = false;
                        NextLine();
                    } else if (index == 32)
                    {
                        dT[1] = true;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
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
                    if (index == 1)
                    {
                        NextLine();
                    } else if (index == 13)
                    {
                        NextLine();
                    } else if (index == 5)
                    {
                        
                    } else if ((index >= 6 && index <= 8) || index == 4)
                    {
                        
                    } else if (index == 22)
                    {
                        
                    }
                } else if(Input.GetKeyDown(twoKey))
                {
                    if (index == 1)
                    {
                        index = 8;
                        NextLine();
                    } else if (index == 13)
                    {
                        index = 20;
                        NextLine();
                    } else if (index == 5 || index == 6)
                    {
                        
                    } else if ((index > 6 && index <= 8) || index == 4)
                    {
                        
                    } else if (index == 22)
                    {
                        
                    }

                } else if(Input.GetKeyDown(threeKey))
                {
                    if (index == 1)
                    {
                        index = 9;
                        NextLine();
                    } else if (index == 13)
                    {
                        dT[0] = true;
                        deathConsolation = true;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false);
                    } else if (index == 8 || index == 4)
                    {
                        
                    } else if ((index >= 5 && index <= 7))
                    {
                        
                    } else if (index == 22)
                    {
                        
                    }
                } else if(Input.GetKeyDown(fourKey))
                {
                    if (index == 1 && sableScript.exisentialismPoints >= 1)
                    {
                        index = 10;
                        NextLine();
                    } else if ((index >= 5 && index <= 8))
                    {
                        ChoiceEight();
                    } else if (index == 4)
                    {

                    }
                } else if (Input.GetKeyDown(fiveKey))
                {
                    if (index == 4)
                    {
                        ChoiceEight();
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
            index = 0;
     }
    }
    
    private void ChoiceEight()
    {
        if (dT[0] == true)
        {
            dT[0] = false;
            dT[1] = true;
        } else
        {
            dT[0] = true;
        }
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        first = true;
        index = 0;
    }
}
