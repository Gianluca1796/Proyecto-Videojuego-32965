using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    public Animator door;
    private bool isInZone;
    private bool isDoorActive;


    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isInZone = false;
        }
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && isInZone == true)
        {
            isDoorActive = !isDoorActive;
            if (isDoorActive == true)
            {
                door.SetBool("ActiveDoor", true);
            }
            if (isDoorActive == false)
            {
                door.SetBool("ActiveDoor", false);
            }
        }
    }
}
