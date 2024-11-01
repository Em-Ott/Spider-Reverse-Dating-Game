using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BellatrixScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
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
    private int index = 0;
    public float textSpeed = 0.05f;


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
                }
                if (DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index])
                {
                    NextLine();
                } else 
                {
                    StopAllCoroutines();
                    DialogueManager.Instance.dialogue.dialogueText.text = initialDialogue[index];
                }
                //DialogueManager.Instance.dialogue.dialogueText.text 
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
