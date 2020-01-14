using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStartPoint : MonoBehaviour
{
    //Variables
    private CharacterController thePlayer;
    private CameraController theCamera;
    public Vector2 startDirection;
    private float tempMoveSpeed;
    public string pointName;

    void Start()
    {
        //Ensures the Player Enters New Scene at Desired Position
        thePlayer = FindObjectOfType<CharacterController>();

        //Makes Sure Player Spawns in the Correct Direction with the Correct Animation State when Transitioning Between Scenes
        if (thePlayer.startPoint == pointName)
        {
            thePlayer.transform.position = transform.position;
            thePlayer.lastMove = startDirection;

            //Ensures Camera Enters New Scene at Desired Position
            theCamera = FindObjectOfType<CameraController>();
            tempMoveSpeed = theCamera.moveSpeed;
            theCamera.moveSpeed = 50;
            theCamera.transform.position = new Vector3(transform.position.x, transform.position.y, theCamera.transform.position.z);
            theCamera.moveSpeed = tempMoveSpeed;
        }
    }
}
