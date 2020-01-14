using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KidMovement : MonoBehaviour
{
    //Variables
    public float moveSpeed;
    public bool isWalking;
    private Transform player;
    public Animator anim;
    private CharacterController character;
    public bool Move = true;


    void Start()
    {
        //Initialising Components
        player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        character = FindObjectOfType<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        //Resets Move to True Every Cycle
        Move = true;

        //Animator Changes Direction when Dialogue is Active
        if (DialogueManager.dActive == true) { anim.SetInteger("MoveDir", 4); return; }

        //Movement of Kid - Special NPC - To Follow Player
        if (Vector2.Distance(transform.position, player.position) > 3)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeed * Time.deltaTime);
        }
        else { if (!character.playerMoving) { Move = false; anim.SetInteger("MoveDir", 4); } }


        /* OLD CODE WHICH WAS SO BAD
        if (character.lastMove.y > 0) { movement = new Vector2(player.position.x, player.position.y - 2); }
        else if (character.lastMove.y < 0) { movement = new Vector2(player.position.x, player.position.y + 2); }
        else if (character.lastMove.x > 0) { movement = new Vector2(player.position.x - 2, player.position.y); }
        else if (character.lastMove.x < 0) { movement = new Vector2(player.position.x + 2, player.position.y); }

        transform.position = Vector2.MoveTowards(transform.position, movement, moveSpeed * Time.deltaTime);
        */

        //Animator Controls
        if (Move)
        {
            if (player.position.x > transform.position.x) { anim.SetInteger("MoveDir", 1); }
            else if (player.position.x < transform.position.x) { anim.SetInteger("MoveDir", 3); }
            else if (player.position.y > transform.position.y - 2) { anim.SetInteger("MoveDir", 0); }
            else if (player.position.y < transform.position.y - 2) { anim.SetInteger("MoveDir", 2); }
            else if (player.position.y == transform.position.y - 2 && player.position.x == transform.position.x) { anim.SetInteger("MoveDir", 4); }
        }
        
    }
}
