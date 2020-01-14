using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class DialogueManager : MonoBehaviour
{
    //Variables
    public GameObject dBox;
    public Text dText;
    public static bool dActive;

    //Variables - MultipleLineDialogue
    public string[] dialogueLines;
    public int currentLine;

    //Variables - Motion Restriction During Dialogue
    private CharacterController thePlayer;
    private EnemyController theEnemy;

    //Variables - Music
    public MusicController musicController;


    void Start()
    {
        //Initialises Components
        thePlayer = FindObjectOfType<CharacterController>();
        theEnemy = FindObjectOfType<EnemyController>();
        musicController = FindObjectOfType<MusicController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Checks for Input - Goes to the Next Line of Dialogue
        if (dActive && Input.GetKeyUp(KeyCode.S))
        {
            currentLine++;
        }

        //Closes Dialogeu Box when the Last Line is Reached
        if (currentLine >= dialogueLines.Length)
        {
            //Closes Dialogue Box
            dBox.SetActive(false);
            dActive = false;
            currentLine = -1;
            thePlayer.canMove = true;

            //Special Cases - Use Story Progression Flahs
            if (CharacterController.boss)
            {
                SceneManager.LoadScene("EvilHouse1Room");
                thePlayer.startPoint = "Reload";
                EnemyController.baseRadius += 5;
                CharacterController.boss = false;
                musicController.SwitchTrack(3);
            }

            if (CharacterController.boss2)
            {
                SceneManager.LoadScene("FinalMain");
                thePlayer.startPoint = "EndStretch";
                CharacterController.boss2 = false;
                musicController.SwitchTrack(2);
            }

            if (CharacterController.end)
            {
                CharacterController.stopWatch.Stop();
                SceneManager.LoadScene("GameEnd");
                Debug.Log(CharacterController.stopWatch.ElapsedMilliseconds.ToString());
                CharacterController.timeElapsed = CharacterController.stopWatch.ElapsedMilliseconds / 1000;
            }
        }

        //Updates the Line of Dialogue Being Shown
        if (currentLine >= 0)
        {
            dText.text = dialogueLines[currentLine];
        }
    }

    //Function to Show Dialogue Box
    public void ShowBox(string dialogue)
    {
        dActive = true;
        dBox.SetActive(true);
        dText.text = dialogue;
    }

    //Function to Show Dialogue
    public void ShowDialogue()
    {
        dActive = true;
        dBox.SetActive(true);
        thePlayer.canMove = false;
    }
}
