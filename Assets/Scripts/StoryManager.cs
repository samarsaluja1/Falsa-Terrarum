using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Playables;

public class StoryManager : MonoBehaviour
{
    //Variables - Other Scripts
    private NPCMovement NPC;
    private DialogueManager dMan;
    private KidMovement Kid;
    private CharacterController Character;
    private DialogueHolder dHolder;

    //Variables - Time Delay
    private float counter = 1;
    private bool ready = false;


    // Start is called before the first frame update
    void Start()
    {
        //Initialises Objects
        dMan = FindObjectOfType<DialogueManager>();
        NPC = FindObjectOfType<NPCMovement>();
        Kid = FindObjectOfType<KidMovement>();
        Character = FindObjectOfType<CharacterController>();
        dHolder = FindObjectOfType<DialogueHolder>();
    }

    // Update is called once per frame
    void Update()
    {
        //Cutscene 1 - Mother Greets the Player
        if (SceneManager.GetActiveScene().name == "House1" && CharacterController.firstTimeDownStairs)
        {
            counter -= Time.deltaTime;
            if (counter < -1)
            {
                Character.anim.SetBool("PlayerMoving", false);
                NPC.anim.SetInteger("MoveDir", 4);
                NPC.canMove = false;
                CharacterController.firstTimeDownStairs = false;
                for (int i = 0; i < dMan.dialogueLines.Length; i++)
                {
                    dMan.dialogueLines[i] = null;
                }
                dMan.dialogueLines[dMan.dialogueLines.Length - 1] = "Mom: Hi Son! Are you feeling okay? Today is our first day in town. Go talk to some people. Be safe!";
                dMan.currentLine = dMan.dialogueLines.Length - 1;
                dMan.ShowDialogue();
                counter = 1;
            }
        }

        //Cutscene 2 - Child Greeds the Player
        if (SceneManager.GetActiveScene().name == "Main" && CharacterController.firstTimeOutside)
        {
            counter -= Time.deltaTime;
            if (counter < 0)
            {
                Character.anim.SetBool("PlayerMoving", false);
                Kid.anim.SetInteger("MoveDir", 4);
                CharacterController.firstTimeOutside = false;
                for (int i = 0; i < dMan.dialogueLines.Length; i++)
                {
                    dMan.dialogueLines[i] = null;
                }
                dMan.dialogueLines[dMan.dialogueLines.Length - 1] = "Kid: Hiii friend!! Huh, what? No, I totally don't have my SDD major work due tomorrow. I'm just going to follow you. I'm bored.";
                dMan.currentLine = dMan.dialogueLines.Length - 1;
                dMan.ShowDialogue();
                counter = 1;
            }
        }

        //Checks if the Player Has Talked to Every Character
        if (CharacterController.oldMan && CharacterController.wiseGuy && CharacterController.Husband && CharacterController.Teacher && CharacterController.Mother)
        {
            CharacterController.progressEnabled = true;
        }

        //Allows for Player to Receive Weapon and Progress - Variable Referred to Elsewhere
        if (ready && dMan.dBox.active == false)
        {
            counter -= Time.deltaTime;
            if (counter < -1)
            {
                CharacterController.disappear = true;
                counter = 1;
            }
        }
    }

    //Indicates Progress When Player Goes Back to Teacher - Allows Teacher to Give Player Weapon and Leave
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player" && CharacterController.progressEnabled)
        {
            
            if (transform.parent.name == "Teacher")
            {
                transform.parent.GetComponent<NPCMovement>().canMove = false;
                NPC.anim.SetInteger("MoveDir", 4);
            }
            Character.anim.SetBool("PlayerMoving", false);

            if (CharacterController.progressEnabled && transform.parent.name == "Teacher")
            {
                for (int i = 0; i < dMan.dialogueLines.Length; i++)
                {
                    dMan.dialogueLines[i] = null;
                }
                dMan.dialogueLines[dMan.dialogueLines.Length - 1] = "Teacher: So you're back. Nuisances! I'm not looking forward to teaching you tomorrow. Anyways, all the adults are going to the funeral. Here's a stick. It shall keep you safe from the crea... Huh. What? You aren't in danger. This is just precautionary. Ok. I'm running late. Bye, now!";
                dMan.currentLine = dMan.dialogueLines.Length - 1;
                dMan.ShowDialogue();
                ready = true;
            }
        }
    }
}
