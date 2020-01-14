using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackEnemy : MonoBehaviour
{
    //Variables
    public int damageToEnemy;
    public GameObject damageBurst;
    public Transform hitPoint;

    //Function That Attacks Enemies when the Player Gives Input
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Enemy" && CharacterController.intAttacking == 1)
        {
            Debug.Log("Attacked");
            other.gameObject.GetComponent<EnemyHealthManager>().HurtEnemy(damageToEnemy);
            Instantiate(damageBurst, hitPoint.position, hitPoint.rotation);
        }
    }
}
