using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndDemoMode : MonoBehaviour
{
    public GameObject endDemo;
    public PlayerMove playerMove;
    public CameraMovement camMov;
    public AudioSource walk;
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            endDemo.SetActive(true);
            playerMove.enabled = false;
            camMov.enabled = false;
            walk.enabled = false;
        }

    }

}
