using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RubyScript : MonoBehaviour
{
    private bool inRange;
    public KeyCode interactKey = KeyCode.E;
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
    "In the past you didn’t really communicate with your siblings.", 
    "In fact you stayed far away from them.", 
    "But you remember that when you did have to communicate with them you used vibrations through the cob webs, or pheromones were used.", 
    "It was strange how you could suddenly communicate so clearly with them but you don’t question it much more, at least for now.", 
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
    "That, alongside the strange voice in your head, is making you suspicious of your own existence."
    }; 

    private string[] futureDialogue = new string[]
    {
    "Ruby ignores you, playing her violin furiously.", 
    "Ruby perks up as you crawl over to her, “My adoring fan! Is there anything I can do for you?”", 
    "She seems excited at your praise and plays louder at your request to the point it can probably be heard from outside the walls.",
    "The sound distresses you.",
    "The hairs on your legs bristle from the vibrations from the violin, allowing you to listen.",
    "You doubt the noise is anything the human ear can hear.",
    "She waves at you with one appendage and then goes back to playing."
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
    "“Please no.”"
    };

    // Start is called before the first frame update
    void Start()
    {
        GameObject lunaObject = GameObject.Find("Luna");
        if (lunaObject != null)
        {
            lunaScript = lunaObject.GetComponent<LunaScript>();
            //READS SUCCESSFULLY YAYYYY
        }

        GameObject sableObject = GameObject.Find("Sable");
        if (sableObject != null)
        {
            sableScript = sableObject.GetComponent<SableScript>();
            //READS SUCCESSFULLY YAYYYY
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (inRange)
        {
            if(Input.GetKeyDown(interactKey))
            {
            }
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
     }
    }
}
