using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponAppear : MonoBehaviour
{

    //Initialises Weapon when Story Flag Has Been Reached
    void Update()
    {
        if (CharacterController.disappear && CharacterController.progressEnabled)
        {
            gameObject.transform.GetChild(0).gameObject.SetActive(true);
            CharacterController.progressEnabled = false;
        }
    }
}
