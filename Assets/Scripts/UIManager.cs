using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    //Variables
    public Slider healthBar;
    public Text HPText;
    public PlayerHealthManager PlayerHealth;
    private static bool UIExists;

    void Start()
    {
        //Transition Between Scenes - Ensure No Duplicates are Created
        if (UIExists == false)
        {
            UIExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else { Destroy(gameObject); }
    }

    //Ensures Player Health is Updated Constantly on the UI - Conveys Information to the Player
    void Update()
    {
        healthBar.maxValue = PlayerHealth.playerMaxHealth;
        healthBar.value = PlayerHealth.playerCurrentHealth;
        HPText.text = "HP: " + PlayerHealth.playerCurrentHealth + " / " + PlayerHealth.playerMaxHealth;
    }
}
