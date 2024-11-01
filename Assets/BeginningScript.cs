using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class BeginningScript : MonoBehaviour
{
    public TextMeshProUGUI beginningText;
    public KeyCode interactKey = KeyCode.E;
    // Start is called before the first frame update
    private string[] onboarding = new string[]
    {
    "The life of a male Latrodectus hasselti spider is simple.\n" +
    "You are born, grow up, and then reproduce.\n" +
    "Shortly after reproduction you volunteer yourself to be eaten by the female and die.\n"+
    "That's your life. Sounds pretty rough, right?", 
    "PLAYER:" +
    "\n“But today I decided I want to live.”" + 
    "\n“I will leave the inside of this wall and spend the rest of my days exploring the world!”"
    };
    public float textSpeed;

    private int index;
    private bool first = true;
    void Start()
    {
        beginningText.text = "Controls: WASD or Arrows to move.\nE to interact with characters, and go to next dialogue.";
    }

    // Update is called once per frame
    void Update()
    {
        if (first)
        {
            if (Input.GetKeyDown(interactKey))
             {
                beginningText.text = string.Empty;
                 StartDialog();
                 first = false;
             }
        } else if (Input.GetKeyDown(interactKey))
        {
            if (beginningText.text == onboarding[index])
            {
                NextLine();
            } else 
            {
                StopAllCoroutines();
                beginningText.text = onboarding[index];
            }
        }
    }
    void StartDialog()
    {
        index = 0;
        StartCoroutine(TypeLine());
    }

    IEnumerator TypeLine()
    {
        //Type each character 1 by 1
        foreach(char c in onboarding[index].ToCharArray())
        {
            beginningText.text += c;
            yield return new WaitForSeconds(textSpeed);
        }
    }

    void NextLine()
    {
        if (index < onboarding.Length - 1)
        {
            index++;
            beginningText.text = string.Empty;
            StartCoroutine(TypeLine());
        } else 
        {
            Debug.Log("Should disappear");
            gameObject.SetActive(false);
        }
    }
}

