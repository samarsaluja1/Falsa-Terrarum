using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CameraController : MonoBehaviour
{
    //Variables
    public GameObject followTarget;
    public float moveSpeed;
    private Vector3 targetPos;
    private float xPos;
    private float yPos;
    private static bool cameraExists;

    void Start()
    {
        //Transition Between Scenes - Ensure No Duplicates are Created
        if (cameraExists == false)
        {
            cameraExists = true;
            DontDestroyOnLoad(transform.gameObject);
        }
        else { Destroy(gameObject); }
    }
    
    // Update is called once per frame
    void Update()
    {
        //Checks if Constraints are Appropriate for Scene
        if (SceneManager.GetActiveScene().name == "Main")
        {
            //Ensures Camera Doesn't Exit Frame of Map in the X-Direction
            if (followTarget.transform.position.x >= 12 && followTarget.transform.position.x <= 63)
            {
                xPos = followTarget.transform.position.x;
            }

            //Ensures Camera Doesn't Exit Frame of Map in the Y-Direction
            if (followTarget.transform.position.y <= -5 && followTarget.transform.position.y >= -66)
            {
                yPos = followTarget.transform.position.y;
            }
        }
        else
        {
            yPos = followTarget.transform.position.y;
            xPos = followTarget.transform.position.x;
        }


        //Gets X and Y Coordinates of Target while Maintaining Camera's Z Coordinate
        targetPos = new Vector3(xPos, yPos, transform.position.z);
        
        //Sets Camera's Position to Required Coordinates at a Given Speed
        transform.position = Vector3.Lerp(transform.position, targetPos, moveSpeed * Time.deltaTime);
    }
}
