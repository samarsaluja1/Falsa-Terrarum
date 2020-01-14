using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerHealthManager : MonoBehaviour
{
    //Variables
    public int playerMaxHealth;
    public int playerCurrentHealth;

    void Start()
    {
        //Initialises Player's Starting Health as Full
        playerCurrentHealth = playerMaxHealth;
    }

    //Destroys Player and Transitions to Game Over Screen if Health Reaches Zero
    void Update()
    {
        if (playerCurrentHealth <= 0)
        {
            gameObject.SetActive(false);
            playerCurrentHealth = 0;
            SceneManager.LoadScene("GameEnd");
        }
    }

    //Function that can be Called to Reduce Health
    public void HurtPlayer(int damage)
    {
        playerCurrentHealth -= damage;
    }

    //Function that can be Called to Restore Player Health
    public void SetMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}
