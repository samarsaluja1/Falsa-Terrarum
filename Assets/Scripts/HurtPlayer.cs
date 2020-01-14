using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    //Variables
    public int damageToPlayer;
    private float counter;

    //Initialises Enemy Health Characteristics According to Difficulty Chosen
    void Start()
    {
        if (MainMenu.difficulty == 0)
        {
            if (gameObject.name.Contains("SlimeEnemy")) { damageToPlayer = 1; }
            if (gameObject.name.Contains("Hound")) { damageToPlayer = 1; }
            if (gameObject.name.Contains("SkullEnemy")) { damageToPlayer = 2; }
            if (gameObject.name.Contains("ToughEnemy")) { damageToPlayer = 3; }
        }
        if (MainMenu.difficulty == 1)
        {
            if (gameObject.name.Contains("SlimeEnemy")) { damageToPlayer = 2; }
            if (gameObject.name.Contains("Hound")) { damageToPlayer = 3; }
            if (gameObject.name.Contains("SkullEnemy")) { damageToPlayer = 4; }
            if (gameObject.name.Contains("ToughEnemy")) { damageToPlayer = 5; }

        }
        if (MainMenu.difficulty == 2)
        {
            if (gameObject.name.Contains("SlimeEnemy")) { damageToPlayer = 4; }
            if (gameObject.name.Contains("Hound")) { damageToPlayer = 5; }
            if (gameObject.name.Contains("SkullEnemy")) { damageToPlayer = 6; }
            if (gameObject.name.Contains("ToughEnemy")) { damageToPlayer = 7; }
        }
    }

    //Checks if Collider has Been Triggered - Allows Enemies to Damage the Player at their Specific Damage Levels
    void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.name == "Player" && counter < 0)
        {
            other.gameObject.GetComponent<PlayerHealthManager>().HurtPlayer(damageToPlayer);
            counter = 1f;
        }

        if (counter >= 0) { counter -= Time.deltaTime; }
    }
}
