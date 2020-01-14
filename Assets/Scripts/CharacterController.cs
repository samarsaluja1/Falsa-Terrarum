using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Diagnostics;

public class CharacterController : MonoBehaviour
{
    //Variables - Movement
    public float moveSpeed;
    float moveHorizontal;
    float moveVertical;
    public Animator anim;
    public bool playerMoving;
    public Vector2 lastMove;
    private Rigidbody2D playerRigidBody;

    //Variables - Spawning
    private static bool playerExists;
    public string startPoint;

    //Variables - Attacking
    private bool attacking;
    public float attackTime;
    private float attackTimeCounter;
    public static int intAttacking = 0;

    //Variables - Dialogue
    public bool canMove;

    //Variables - Story Progression - The Only Script That Only Has One Instance
    public static bool firstTimeDownStairs = true;
    public static bool firstTimeOutside = true;
    public static bool progressEnabled = false;
    public static bool oldMan = false;
    public static bool Teacher = false;
    public static bool Husband = false;
    public static bool wiseGuy = false;
    public static bool Mother = false;
    public static bool disappear;
    public static bool boss = false;
    public static bool boss2 = false;
    public static bool end = false;

    //Variables - High Scores
    public static Stopwatch stopWatch = new Stopwatch();
    public static float timeElapsed;


    // Start is called before the first frame update
    void Start()
    {
        //Initialises Components Linked to Player GameObject
        anim = GetComponent<Animator>();
        playerRigidBody = GetComponent<Rigidbody2D>();

        //Transition Between Scenes - Ensure No Duplicates are Created
        if (playerExists == false)
        {
            playerExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else { Destroy(gameObject); }

        //Enabling Moveent When the Game is Loaded
        canMove = true;

        //Stopping Any Bugs as this Variable is Required from the Start
        lastMove = new Vector2(0, -1f);

        //Starting Game Timer
        stopWatch.Start();
    }

    // Update is called once per frame
    void Update()
    {
        if (canMove == false)
        {
            playerRigidBody.velocity = Vector2.zero;
            return;
        }

        if (attacking == false)
        {
            if (Input.GetKey(KeyCode.LeftShift)) { moveSpeed = 350; } else { moveSpeed = 200; }

            //Set Moving State to False
            playerMoving = false;

            //Checks if Vertical Movement is Null - Remove Diagonal Movement
            if (moveVertical == 0f)
            {
                //Stores Horizontal Movement of Character Ignoring Effect of Frame Rate
                moveHorizontal = Input.GetAxisRaw("Horizontal") * moveSpeed * Time.deltaTime;

                //Checks if Input is Received and Stores Previous Movements and Sets Moving State to True
                if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
                {
                    lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
                    playerMoving = true;
                }
            }

            //Checks if Horizontal Movement is Null - Remove Diagonal Movement
            if (moveHorizontal == 0f)
            {
                //Stores Vesrtical Movement of Character Ignoring Effect of Frame Rate
                moveVertical = Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime;

                //Checks if Input is Received and Stores Previous Movements and Sets Moving State to True
                if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
                {
                    lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
                    playerMoving = true;
                }
            }

            //Moves Character the Required Amount per Frame - Will Not Move Diagonal due to Checks Above
            playerRigidBody.velocity = new Vector2(moveHorizontal, moveVertical);
        }

        //Attack Control
        if (disappear)
        {
            if (Input.GetKeyDown(KeyCode.A))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                intAttacking = 1;
                playerRigidBody.velocity = Vector2.zero;
                anim.SetBool("Attack", true);
            }

            if (attackTimeCounter > 0)
            {
                attackTimeCounter -= Time.deltaTime;
            }
            else
            {
                attacking = false;
                intAttacking = 0;
                anim.SetBool("Attack", false);
            }
        }

        //---------------------------------------------------------Animation Controller Start
        //Variables Responsible for Direction of Movement in Animator
        if (moveVertical == 0f)
        {
            anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
            anim.SetFloat("MoveY", 0);
        }

        if (moveHorizontal == 0f)
        {
            anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
            anim.SetFloat("MoveX", 0);
        }

        //Variables Responsible for Direction of Idle Animation in Animator
        anim.SetBool("PlayerMoving", playerMoving);
        anim.SetFloat("LastMoveX", lastMove.x);
        anim.SetFloat("LastMoveY", lastMove.y);
        //---------------------------------------------------------Animation Controller End
    }
}
