using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    //Variables - Basic Movement
    private float moveSpeed;
    public float timeBetweenMove;
    private float timeBetweenMoveCounter;
    private Vector3 moveDirection;
    public Vector2 position1;
    public Vector2 position2;
    private Vector2 posToMove;
    private bool pos1 = true;

    //Variables - Player Pursuit
    private Transform player;
    public float sensingRadius;
    public static float baseRadius = 3;

    //Variables - Player Damage
    private bool reloading;
    private float waitToReload = 1.0f;
    private GameObject thePlayer;

    //Initialises Enemy Movement Characteristics According to Difficulty Chosen
    void Start()
    {
        //Initialising Components
        player = GameObject.FindGameObjectWithTag("Player").transform;

        //Setting Variables
        timeBetweenMoveCounter = timeBetweenMove;
        posToMove = position1;

        //Setting Enemy Characteristics
        if (MainMenu.difficulty == 0)
        {
            moveSpeed = 3;
            sensingRadius = baseRadius-1;
        } 
        if (MainMenu.difficulty == 1)
        {
            moveSpeed = 4;
            sensingRadius = baseRadius;
        }
        if (MainMenu.difficulty == 2)
        {
            moveSpeed = 5;
            sensingRadius = baseRadius;
        }
    }

    //Enemy Movement - Patrol & Pursuit
    void Update()
    {
        //Chases Player if Player is within Sensing Radius
        if (Vector2.Distance(transform.position, player.position) < sensingRadius)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else
        {
            transform.position = Vector2.MoveTowards(transform.position, posToMove, (moveSpeed - 2) * Time.deltaTime);
            if ((Vector2)transform.position == posToMove)
            {
                timeBetweenMoveCounter -= Time.deltaTime;
                if (timeBetweenMoveCounter < 0 && pos1)
                {
                    posToMove = position2;
                    timeBetweenMoveCounter = timeBetweenMove;
                    pos1 = false;
                }
                else if (timeBetweenMoveCounter < 0 && pos1 == false)
                {
                    posToMove = position1;
                    timeBetweenMoveCounter = timeBetweenMove;
                    pos1 = true;
                }
            }
        }

        //Rate of Enemy Attack
        if (reloading)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                SceneManager.LoadScene(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
    }
}
