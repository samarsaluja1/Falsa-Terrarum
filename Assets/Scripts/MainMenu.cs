using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    //Variables
    public static int difficulty;
    public MusicController musicController;

    public void Start()
    {
        //Initialises Music Controller
        musicController = FindObjectOfType<MusicController>();
    }

    //Changes Game Properties According to Chosen Difficulty and Starts Game
    public void PlayGame_Easy()
    {
        difficulty = 0;
        Debug.Log("Easy");
        SceneManager.LoadScene("House1Room");
        musicController.SwitchTrack(1);
    }

    public void PlayGame_Normal()
    {
        difficulty = 1;
        Debug.Log("Normal");
        SceneManager.LoadScene("House1Room");
        musicController.SwitchTrack(1);
    }

    public void PlayGame_Hard()
    {
        difficulty = 2;
        Debug.Log("Hard");
        SceneManager.LoadScene("House1Room");
        musicController.SwitchTrack(1);
    }

    //Function to Quit Game - Gives Quit Button Functionality
    public void QuitGame()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
