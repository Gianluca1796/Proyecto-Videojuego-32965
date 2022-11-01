using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GrabCubeViolet : MonoBehaviour
{
    public GameObject cubeVioletInhand;
    public Transform hand;
    private GameObject violet;
    private void Start()
    {
        violet = GameObject.Find("Camera");

    }
    public void grabViolet()
    {
        transform.SetParent(hand);
        cubeVioletInhand.transform.position = hand.position;
        cubeVioletInhand.GetComponent<Rigidbody>().isKinematic = true;
        violet.GetComponent<CameraMovement>().cubeViolet = true;
    }
}
