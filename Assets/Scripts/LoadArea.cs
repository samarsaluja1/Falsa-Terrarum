using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadArea : MonoBehaviour
{
    //Variables
    public string levelToLoad;
    public string exitPoint;
    private CharacterController thePlayer;

    void Start()
    {
        //Initialises Components
        thePlayer = FindObjectOfType<CharacterController>(); 
    }

    //Function to Load New Scene at Trigger Points
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            SceneManager.LoadScene(levelToLoad);
            thePlayer.startPoint = exitPoint;
        }
    }
}
