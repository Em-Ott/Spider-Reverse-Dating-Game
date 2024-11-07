using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LunaScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
    public KeyCode oneKey = KeyCode.Alpha1;
    public KeyCode twoKey = KeyCode.Alpha2;
    public KeyCode threeKey = KeyCode.Alpha3;
    public bool violinHint; 
    public SableScript sableScript;
    private string[] initialDialogue = new string[]
    {
    "The spider in front of you was sleeping until you landed on her web.", 
    "Now, Luna, looks at you, still clearly half-asleep and waits for you to either explain your purpose or leave.", 
    "She nods and points to the right with one of her appendages.", 
    "“That other spider with the violin,” she pauses to yawn before continuing, “can play very loudly, to the point it can wake me up.”", 
    "“It has a very high pitch to the point it may hurt the thing’s ears,” She explains further before covering her eyes with her leg again.", 
    "She nods again.", 
    "She doesn’t uncover her eyes and only simply responds, “There’s no point in that.”",
    "She remains silent too and after a moment falls back asleep.",
    "You’re not much of a threat even if you attacked her while she was sleeping.",
    "It’s not much of a competition at all, the female Australian Redback is both larger and more venomous than the male.",
    "Luna remains asleep. It wouldn’t be nice to bother her."
    };

    private string[] playerChoices = new string[]{
        "“Excuse me? Can you help me get the rodent to move?”",
	    "Remain there silently, until she talks first.",
	    "Leave",
        "“Thank you!”",
	    "“Is that it? You aren’t going to try and date me or kill me or anything?”",
        "Fight her for no particular reason other than wanting to fight"
    };
        private bool first = true;
       private bool unread = true;
        private int index = 0;
        public float textSpeed = 0.05f;
        private int inProgress = 0;



    // Start is called before the first frame update
    void Start()
    {
        GameObject sableObject = GameObject.Find("Sable");
        if (sableObject != null)
        {
            sableScript = sableObject.GetComponent<SableScript>();
        }
        violinHint = false;
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
                    DialogueManager.Instance.characterNameText.nameText.text = "Luna"; 
                } else if (unread == false)
                {
                    index = 10;
                    StartDialog();
                    DialogueManager.Instance.characterImage.SetActive(true);
                    DialogueManager.Instance.characterNameText.nameText.text = "Luna"; 
                }
                if (DialogueManager.Instance.dialogue.dialogueText.text == initialDialogue[index])
                {
                    /*
                    Dialogue 1 -> Choice 0, 1, 2
                    Choice 0 -> Dialogue 2-4 -> Choice 3, 4, 2
                    Choice 3 -> Dialogue 5
                    Choice 4 -> Dialogue 6
                    Choice 1 -> Dialogue 7-8 -> Choice 0, 5
                    Choice 5 -> Dialogue 9 
                    */
                    if (index == 1)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[1] + "\n" + playerChoices[2];
                    } else if (index == 4)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[3]
                        + "\n" + playerChoices[4] + "\n" + playerChoices[2];
                    } else if (index == 8)
                    {
                        inProgress = 1;
                        DialogueManager.Instance.dialogue.dialogueText.text = playerChoices[0]
                        + "\n" + playerChoices[5] + "\n" + playerChoices[2];
                    } else if (index == 5 || index == 6)
                    {
                        unread = false;
                        DialogueManager.Instance.image.SetActive(false);
                        DialogueManager.Instance.characterImage.SetActive(false); 
                        inProgress = 0;
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
                    if (index == 1)
                    {
                        NextLine();
                    } else if (index == 4)
                    {
                        NextLine();
                    } else if (index == 8)
                    {
                        index = 1;
                        NextLine();
                    }
                } else if (Input.GetKeyDown(twoKey))
                {
                    if (index == 1)
                    {
                        index = 6;
                        NextLine();
                    } else if (index == 4)
                    {
                        index = 5;
                        NextLine();
                    } else if (index == 8)
                    {
                        NextLine();
                        //Ending
                    }
                } else if (Input.GetKeyDown(threeKey))
                {
                    ResetEncounter();
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
