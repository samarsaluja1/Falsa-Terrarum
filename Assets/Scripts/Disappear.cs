using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Disappear : MonoBehaviour
{
    //Funtion that Removes the NPC's When Story is Read to be Progressed
    void Update()
    {
        if (CharacterController.disappear)
        {
            gameObject.SetActive(false);
        }
    }
}
