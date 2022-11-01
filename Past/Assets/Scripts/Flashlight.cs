using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Flashlight : MonoBehaviour
{
    public bool flashLigthInHand;
    private bool activLight;
    public Light flashlightLight;

    void Update()
    {
        TurnOnOff();
    }
    void TurnOnOff()
    {
        if (Input.GetKeyDown(KeyCode.F) && flashLigthInHand == true)
        {
            activLight = !activLight;

            if (activLight == true)
            {
                flashlightLight.enabled = true;
            }

            if (activLight == false)
            {
                flashlightLight.enabled = false;
            }
        }
    }
}
