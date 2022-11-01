using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Light interactableLight;
    public bool isLigth;
    private bool lightOnOff;
    public void changeOnOff()
    {
        lightOnOff = !lightOnOff;

        if (lightOnOff == true)
        {
            interactableLight.enabled = true;
        }
        if (lightOnOff == false)
        {
            interactableLight.enabled = false;
        }
    }

}

