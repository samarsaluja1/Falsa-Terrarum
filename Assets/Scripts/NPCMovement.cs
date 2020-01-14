using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCMovement : MonoBehaviour
{
    //Variables
    private Rigidbody2D myRigidBody;

    //Variables - Movement Characteristics
    public float moveSpeed;
    public bool isWalking;
    public float walkTime;
    private float walkCounter;
    public float waitTime;
    private float waitCounter;
    public int walkDirection;

    //Variables - Restrict Movement
    public Collider2D walkArea;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    private bool hasWalkZone;
    private int prevWalkDirection;
    private bool endReached = false;

    //Variables - NPC Animation
    public  Animator anim;

    //Variables - Motion During Dialogue
    public bool canMove;

    // Start is called before the first frame update
    void Start()
    {
        //Initialises Animator
        anim = GetComponent<Animator>();

        //Load the RigidBody
        myRigidBody = GetComponent<Rigidbody2D>();

        //Sets Starting Time Values
        waitCounter = waitTime;
        walkCounter = walkTime;

        //Sets Starting Direction
        ChooseDirection();

        //Checks Bounds of Restricted Walk Area
        if (walkArea != null)
        {
            minWalkPoint = walkArea.bounds.min;
            maxWalkPoint = walkArea.bounds.max;
            hasWalkZone = true;
        }

        //Movement is Defaulted to True
        canMove = true;
    }

    // Update is called once per frame
    void Update()
    {
        //Sets Movement to False if Dialogue is Active
        if (DialogueManager.dActive == false) { canMove = true; }

        //Sets Movement to False if Needed as Such
        if (canMove == false)
        {
            myRigidBody.velocity = Vector2.zero;
            return;
        }

        //Checks if Object is Currently Moving
        if (isWalking)
        {
            //Times How Long the Player will Walk
            walkCounter -= Time.deltaTime;

            //Change Variable for Animations
            anim.SetInteger("MoveDir", walkDirection);

            //Varies Commands According to Different Directions
            switch (walkDirection)
            {
                case 0:
                    myRigidBody.velocity = new Vector2(0, moveSpeed);
                    if (hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        endReached = true;
                    }
                    break;

                case 1:
                    myRigidBody.velocity = new Vector2(moveSpeed, 0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        endReached = true;
                    }
                    break;

                case 2:
                    myRigidBody.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        endReached = true;
                    }
                    break;

                case 3:
                    myRigidBody.velocity = new Vector2(-moveSpeed,0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        waitCounter = waitTime;
                        endReached = true;
                    }
                    break;
            }

            //Stores Previous Vector for Animation Purposes
            prevWalkDirection = walkDirection;

            //Stops Walking and Resets Timer When it Runs Out
            if (walkCounter < 0)
            {
                //Revert Variable for Animations
                anim.SetInteger("MoveDir", 4);
                isWalking = false;
                waitCounter = waitTime;
            }
        }
        else
        {
            //Times How Long the Player will Wait
            waitCounter -= Time.deltaTime;

            myRigidBody.velocity = Vector2.zero;

            //Initialises Walking When the Timer Runs Out
            if (waitCounter < 0)
            {
                //Makes Sure if NPC Has Reached a Bound, it Changes Direction
                if (endReached)
                {
                    do
                    {
                        ChooseDirection();
                    } while (walkDirection == prevWalkDirection);
                }
                else { ChooseDirection(); }
            }
        }
    }

    //Function to Decide Random Direction
    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkCounter = walkTime;
    }
}
