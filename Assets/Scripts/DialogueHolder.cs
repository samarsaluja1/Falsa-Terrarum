using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueHolder : MonoBehaviour
{
    //Variables - Dialogue
    private DialogueManager dMan;
    public string[] dialogueLines;

    // Start is called before the first frame update
    void Start()
    {
        //Initialises Components
        dMan = FindObjectOfType<DialogueManager>();
    }

    //Dialogue - Sends Dialogue Being Held by Different Objects to the Dialogue Manager
    void OnTriggerStay2D(Collider2D other)
    {
        //Checks if Player Enters the Dialogue Zone
        if (other.gameObject.name == "Player")
        {
            //Player Input Check
            if (Input.GetKeyUp(KeyCode.S))
            {
                //Story Progression Flags
                if (transform.parent.name == "OldMan") { CharacterController.oldMan = true; }
                if (transform.parent.name == "Teacher") { CharacterController.Teacher = true; }
                if (transform.parent.name == "Husband") { CharacterController.Husband = true; }
                if (transform.parent.name == "WiseGuy") { CharacterController.wiseGuy = true; }
                if (transform.parent.name == "Mother") { CharacterController.Mother = true; }
                if (transform.parent.name == "Boss") { CharacterController.boss = true; }
                if (transform.parent.name == "Boss2") { CharacterController.boss2 = true; }
                if (transform.parent.name == "EndTrigger") { CharacterController.end = true; }

                //Ignore One Case - Cutscene when Progress is Enables
                if (transform.parent.name == "Teacher" && CharacterController.progressEnabled) { return; }

                //Activates Dialogue Box
                if (DialogueManager.dActive == false)
                {
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = -1;
                    dMan.ShowDialogue();
                }

                //Prevents NPC Movement
                if (transform.parent.GetComponent<NPCMovement>() != null)
                {
                    transform.parent.GetComponent<NPCMovement>().canMove = false;
                }
            }
        }
    }

    //Prevents Player to Going to Enemy Territory without a Weapon
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (gameObject.name == "RestrictionDialogueZone")
            {
                CharacterController.wiseGuy = true;
                if (DialogueManager.dActive == false)
                {
                    dMan.dialogueLines = dialogueLines;
                    dMan.currentLine = 0;
                    dMan.ShowDialogue();
                }
            }
        }  
    }
}

