using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCubeRed : MonoBehaviour
{
    public GameObject cubeRedInHand;
    public Transform hand;
    private GameObject red;
    private void Start()
    {
        red = GameObject.Find("Camera");

    }
    public void grabRed()
    {
        transform.SetParent(hand);
        cubeRedInHand.transform.position = hand.position;
        cubeRedInHand.GetComponent<Rigidbody>().isKinematic = true;
        red.GetComponent<CameraMovement>().cubeRed = true;
    }
}
