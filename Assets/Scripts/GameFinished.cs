using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameFinished : MonoBehaviour
{
    //Variables
    public Text myText;

    //Displays End Game Screen
    void Start()
    {
        //Checks if Player has Won or Lost
        if (CharacterController.end == true)
        {
            myText.text = "Congratulations. You have finished the game. You took " + CharacterController.timeElapsed + " seconds.";
        }
        else
        {
            myText.text = "Game Over. You failed.";
        }
    }

    //Waits for Input to Quit
    void Update()
    {
        if (Input.anyKey) { Application.Quit(); }
    }
}
