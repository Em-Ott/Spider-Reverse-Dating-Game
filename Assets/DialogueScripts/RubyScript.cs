using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
    public KeyCode fourKey = KeyCode.Alpha4;
    public LunaScript lunaScript; 
    public SableScript sableScript;
    private string[] initialDialogue = new string[]
    {
    "This spider is playing a violin quietly so as to not disturb anyone.", 
    "You didn’t know that spiders could play violin, or where a violin, so small that a spider could play it, could be found.", 
    "You’ve never seen a violin before either, or heard it but you’re sure that they’re very hard to play.", 
    "Even though spiders can’t blush, Ruby blushes at your compliment and pauses in her playing.", 
    "“Thank you…” She whispers out, averting four of her eight eyes.", 
    "“No one’s ever told me that before.”", 
    "It makes sense that no one’s told her that before, spiders mainly live solitary lives outside of eating each other and reproducing with each other.", 
    "Spiders also can’t talk normally.", 
    "She seems excited at your praise and plays louder at your request to the point it can probably be heard from outside the walls.", 
    "The sound distresses you.", 
    "“No.”", 
    "There’s a moment of long silence between the two of you, you don’t know what to say to such a quick refusal.", 
    "Thankfully, she awkwardly follows up, “I mean, not really, do you?”", 
    "“Oh.” She replies and then stares straight at her violin, refusing to look at you.", 
    "You’re not sure if you’re going to be able to make any conversation with her not awkward going forward.", 
    "She brightens up, happy to have something in common, “Oh, really?” She sounds too excited.", 
    "You nod hesitantly at her question.", 
    "“That’s wonderful! We have so much in common!”", 
    "You really only have one thing in common but before you can say anything she tentatively adds on,", 
    "“Maybe we’re soulmates?”", 
    "You have a feeling that if you reject her now things will get messy.", 
    "Ruby seems to take that as you agreeing with her and at this point it’s too late to back out.", 
    "She comes closer and closer, until it’s all over.", 
    "Every musician wants someone to listen to them, and you can’t just kill that audience.", 
    "Ruby looks at you, tearing up at your words, “That…” she pauses, to let out a quiet sob, “would be perfect.”", 
    "Even the world’s smallest violin really needs an audience because if she doesn’t find one soon–", 
    "She’ll probably just eat you.", 
    "And that wouldn’t be a good ending to your life.", 
    "You don’t know what you want your death to be like but you at least want to explore the world outside of this wall first.", 
    "It’s the things you do before your death that matter.", 
    "Ruby freezes at your words.", 
    "“So you were just playing with me?” Her voice is accusatory and she doesn’t even give you a chance to respond before focusing on her violin.", 
    "She plays it quickly and furiously yet it remains quiet out of her mindfulness.", 
    "You have a feeling she won’t be talking to you again but, on the bright side you didn’t get eaten.", 
    "Ruby looks at you for a moment before focusing back on her violin, ignoring your critiques.", 
    "Despite her lack of reaction you get the feeling that she probably won’t want to talk to you now.", 
    "You are quite sure that a violin is what’s in front of you.", 
    "But you’re not sure how you know that.", 
    "You’ve noticed that recently you understand a lot of things you shouldn’t.", 
    "That, alongside the strange voice in your head, is making you suspicious of your own existence.",
    "Ruby ignores you, playing her violin furiously.", 
    "Ruby perks up as you crawl over to her, “My adoring fan! Is there anything I can do for you?”", 
    "The hairs on your legs bristle from the vibrations from the violin, allowing you to listen.",
    "You doubt the noise is anything the human ear can hear.",
    "She waves at you with one appendage and then goes back to playing.",
    "Ruby is playing the violin."
    }; 

    private string[] playerChoices = new string[]
    {
    "“You sound wonderful.”",
    "“So you’re the cause behind that infernal racket.”",
	"Walk away, violins scare you",
	"Contemplate what a violin is",
    "“Can you play that loudly so everyone can hear? It’s really wonderful.”",
    "Walk away, the conversation died out",
    "“So, ya like jazz?”",
    "“Yeah, I like jazz.”",
    "“I don’t like it either.”",
    "“Maybe!”",
    "“Actually, I think I’m meant to be your perfect audience.”",
    "“Please no.”",
    "“I’m just here to listen to your music!”",
	"“Nope, just wanted to say hi!”",
    "You listen for a moment and then walk away."
    };
        private bool first = true;
       private bool unread = true;
        private int index = 0;
        public float textSpeed = 0.05f;
        private int inProgress = 0;
        public bool violinPlayed = false;
        private bool stuck = false;
        private bool[] futureEncounter = new bool[] {false, false};



    // Start is called before the first frame update
    void Start()
    {
        GameObject lunaObject = GameObject.Find("Luna");
        if (lunaObject != null)
        {
            lunaScript = lunaObject.GetComponent<LunaScript>();
        }

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
                    DialogueManager.Instance.characterNameText.nameText.text = "Ruby"; 
                } else if (futureEncounter[0] == true)
                {
                    index = 40;
                    StartDialog();
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Ruby"; 
                } else if (futureEncounter[1] == true && stuck == false)
                {
                    index = 41;
                    StartDialog();
                    stuck = true;
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Ruby"; 
                } else if (unread == false)
                {
                    index = 45;
                    StartDialog();
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Ruby"; 
                    unread = true;
                }
                if (DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index])
                {
                    /*
                    Dialogue Management:
                    Dialogue 0-2: Choice 0, 1, 2, 3
                    Choice 2 -> ResetEncounter()
                    Choice 0 -> Dialogue 3-7: Choice 5, 6, 4 (if violinHint)
                    Choice 4 -> Dialogue 8-9 violinPlayed = true
                    Choice 6 -> Dialogue 10-12: Choice 7, 8
                    Choice 7 -> Dialogue 13-14
                    Choice 8 -> Dialogue 15-20: Choice 9, 10, 11
                    Choice 9 -> Dialogue 21-22 Ya Like Jazz? Ending
                    Choice 10 -> Dialogue 23-29 (+1 Exisentialism Point choice 10) futureEncounter[1] = true
                    Choice 11 -> Dialogue 30-33 futureEncounter[0] = true
                    Choice 1 -> Dialogue 34-35 futureEncounter[0] = true
                    Choice 3 -> Dialogue 36-39: Choice 0, 1, 2 (+1 Exisentialism Point from Choice 3)
                    futureEncounter[0] = true -> Dialogue 40
                    futureEncounter[1] = true -> Dialogue 41: Choice 12, Choice 13, Choice 4
                    Choice 12 -> Dialogue 42-43
                    Choice 13 -> Dialogue 44
                    else unread = false Dialogue 47: Choice 14, Choice 4
                    */
                    if (index == 2)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[1] + "\n" + playerChoices[2] + "\n" + playerChoices[3];
                    } else if (index == 7)
                    {
                        inProgress = 1;
                        if (lunaScript.violinHint == true)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[5]
                            + "\n" + playerChoices[6] + "\n" + playerChoices[4];
                        } else 
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[5]
                            + "\n" + playerChoices[6]; 
                        }
                    } else if (index == 12)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[7]
                        + "\n" + playerChoices[8];
                    } else if (index == 20)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[9]
                        + "\n" + playerChoices[10] + "\n" + playerChoices[11];
                    } else if (index == 39)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[1] + "\n" + playerChoices[2];
                    } else if (index == 41)
                    {
                        inProgress = 1;
                        if (lunaScript.violinHint == true)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[12]
                            + "\n" + playerChoices[13] + "\n" + playerChoices[4];
                        } else 
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[12]
                            + "\n" + playerChoices[13]; 
                        }
                    } else if (index == 45)
                    {
                        Debug.Log("text?");
                        inProgress = 1;
                        if (lunaScript.violinHint == true)
                        {
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[14]
                            + "\n" + playerChoices[4];
                        } else 
                        {
                            unread = false; 
                            DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[14];
                        }
                    } else if (index == 9)
                    {
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                        unread = false;
                        violinPlayed = true;
                        stuck = false;
                    } else if (index == 29)
                    {
                        sableScript.exisentialismPoints += 1;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                        unread = false;
                        futureEncounter[1] = true;
                    } else if (index == 39)
                    {
                        sableScript.exisentialismPoints += 1;
                    } else if (index == 33)
                    {
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                        unread = false;
                        futureEncounter[0] = true;                    
                    } else if (index == 14)
                    {
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                        unread = false;
                    } else if (index == 43)
                    {
                        stuck = false;
                    } else if (index == 44)
                    {
                        stuck = false;
                    } else if (index == 22)
                    {
                        YaLikeJazz();
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
                    if (index == 2)
                    {
                        NextLine();
                    } else if (index == 7)
                    {
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                        unread = false;
                        futureEncounter[1] = true;
                    } else if (index == 12)
                    {
                        NextLine();
                    } else if (index == 20)
                    {
                        NextLine();
                    } else if (index == 39)
                    {
                        index = 2;
                        NextLine();
                    } else if (index == 41)
                    {
                        NextLine();
                    } else if (index == 45)
                    {
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
                        unread = false;
                    }

                } else if (Input.GetKeyDown(twoKey))
                {
                    if (index == 2)
                    {
                        index = 33;
                        futureEncounter[0] = true;
                        NextLine();
                    } else if (index == 7)
                    {
                        index = 9;
                        NextLine();
                    } else if (index == 12)
                    {
                        index = 14;
                        NextLine();
                    } else if (index == 20)
                    {
                        index = 22;
                        NextLine();
                    } else if (index == 39)
                    {
                        index = 33;
                        NextLine(); 
                    } else if (index == 41)
                    {
                        index = 43;
                        NextLine();
                    } else if (index == 45 && lunaScript.violinHint == true)
                    {
                        index = 7;
                        NextLine();
                    }
                } else if (Input.GetKeyDown(threeKey))
                {
                    if (index == 2)
                    {
                        ResetEncounter();
                    } else if (index == 7 && lunaScript.violinHint == true)
                    {
                        NextLine();
                    } else if (index == 20)
                    {
                        index = 29;
                        NextLine();
                    } else if (index == 39)
                    {
                        ResetEncounter();
                    } else if (index == 41 && lunaScript.violinHint == true)
                    {
                        index = 7;
                        NextLine();
                    } 
                } else if (Input.GetKeyDown(fourKey) && index == 2)
                {
                    index = 35;
                    NextLine();
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

    private void ResetEncounter()
    {
        index = 0;
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        inProgress = 0;
        first = true;
    }

        private void YaLikeJazz()
    {
        DialogueManager.Instance.image.SetActive(false);
        DialogueManager.Instance.characterImage.SetActive(false); 
        DialogueManager.Instance.endingScript.endingScreen.SetActive(true);
        DialogueManager.Instance.endingScript.endingText.text = "Ending Four:" + "\n" + "DEATH" 
        + "\n" + "You don't like jazz :(";
    }
}
