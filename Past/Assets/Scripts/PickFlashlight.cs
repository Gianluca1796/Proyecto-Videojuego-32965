using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickFlashlight : MonoBehaviour
{
    public GameObject FlashlightInHand;


    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            FlashlightInHand.SetActive(true);
            FlashlightInHand.GetComponent<Flashlight>().flashLigthInHand = true;;
            Destroy(gameObject);

        }
    }
}
