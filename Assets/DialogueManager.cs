using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueManager : MonoBehaviour
{
    public static DialogueManager Instance;
    public VennaScript vennaScript; 
    public SableScript sableScript;
    public ScarletScript scarletScript;
    public BellatrixScript bellatrixScript;
    public LunaScript lunaScript;
    public RodentText rodentText;
    public RubyScript rubyScript;
    public RWLScript rWLScript;
    public Dialogue dialogue;
    public CharacterNameText characterNameText;
    public EndingScript endingScript;

    public GameObject image;
    public GameObject characterImage;

    // Start is called before the first frame update
    void Awake()
    {
        Instance = this;
        
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
