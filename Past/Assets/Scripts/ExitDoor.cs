using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExitDoor : MonoBehaviour
{
    public GameObject doorMessage;
    public GameObject meetMessage;
    public GameObject cam;
    public CameraMovement camMov;
    public Transform camTransform;
    public RaycastHit hit;
    private float rayDistance;

    void Start()
    {
        cam = GameObject.Find("Camera");
        camTransform = cam.GetComponent<Transform>();
        camMov = cam.GetComponent<CameraMovement>();
        hit = camMov.hit;
        rayDistance = camMov.rayDistance;
    }


    void Update()
    {
        ExitMessage();
    }

    void ExitMessage()
    {

        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance) && hit.transform.tag == "Meet")
        {
            meetMessage.SetActive(true);
        }
        else
        {
            meetMessage.SetActive(false);
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorMessage.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            doorMessage.SetActive(false);
        }
    }
}


