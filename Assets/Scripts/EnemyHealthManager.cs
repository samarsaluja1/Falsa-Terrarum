using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealthManager : MonoBehaviour
{
    //Variables
    public int MaxHealth;
    public int CurrentHealth;

    //Initialises Enemy Health Characteristics According to Difficulty Chosen
    void Start()
    {
        //Setting Enemy Characteristics
        if (MainMenu.difficulty == 0)
        {
            if (gameObject.name.Contains("SlimeEnemy")) { MaxHealth = 2; }
            if (gameObject.name.Contains("Hound")) { MaxHealth = 5; }
            if (gameObject.name.Contains("SkullEnemy")) { MaxHealth = 10; }
            if (gameObject.name.Contains("ToughEnemy")) { MaxHealth = 15; }
        }
        if (MainMenu.difficulty == 1)
        {
            if (gameObject.name.Contains("SlimeEnemy")) { MaxHealth = 2; }
            if (gameObject.name.Contains("Hound")) { MaxHealth = 10; }
            if (gameObject.name.Contains("SkullEnemy")) { MaxHealth = 15; }
            if (gameObject.name.Contains("ToughEnemy")) { MaxHealth = 20; }
        }
        if (MainMenu.difficulty == 2)
        {
            if (gameObject.name.Contains("SlimeEnemy")) { MaxHealth = 6; }
            if (gameObject.name.Contains("Hound")) { MaxHealth = 15; }
            if (gameObject.name.Contains("SkullEnemy")) { MaxHealth = 20; }
            if (gameObject.name.Contains("ToughEnemy")) { MaxHealth = 25; }
        }
        //Setting Variables
        CurrentHealth = MaxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        //Destroys Enemies if Health Runs Out
        if (CurrentHealth <= 0)
        {
            gameObject.SetActive(false);
        }
    }

    //Function that is Called When Damaging an Enemy
    public void HurtEnemy(int damage)
    {
        CurrentHealth -= damage;
    }

    //Function to Set Maximum Health
    public void SetMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}
