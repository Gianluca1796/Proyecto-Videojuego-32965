using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCube : MonoBehaviour
{

    public GameObject cubeGreenInHand;
    public Transform hand;
    private GameObject green;

    private void Start()
    {
        green = GameObject.Find("Camera");

    }
    public void grabGreen()
    {
        transform.SetParent(hand);
        cubeGreenInHand.transform.position = hand.position;
        cubeGreenInHand.GetComponent<Rigidbody>().isKinematic = true;
        green.GetComponent<CameraMovement>().cubeGreen = true;
    }


}
