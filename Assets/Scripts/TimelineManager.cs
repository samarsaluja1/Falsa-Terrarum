using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class TimelineManager : MonoBehaviour
{
    //Variables
    public bool fix = false;
    public Animator playerAnimator;
    public RuntimeAnimatorController playerAnim;
    public PlayableDirector director;

    //The Entire Purpose of this Script is because of a Glitch in Unity - Essentially Turning the Animator Off and On to Fix it
    //Called When Object is First Made Active
    void OnEnable()
    {
        //Destroys Animator
        playerAnim = playerAnimator.runtimeAnimatorController;
        playerAnimator.runtimeAnimatorController = null;
    }

    //Recreates Animator
    void Update()
    {
        if (director.state != PlayState.Playing && !fix)
        {
            fix = true;
            playerAnimator.runtimeAnimatorController = playerAnim;
        }
    }
}
