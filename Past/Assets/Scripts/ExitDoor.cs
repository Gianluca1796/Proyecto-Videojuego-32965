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

    // Update is called once per frame
    void Update()
    {
        ExitMessage();
    }

    void ExitMessage()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward * rayDistance, out hit, rayDistance))
        {
            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance) && hit.transform.tag == "Door")
            {
                doorMessage.SetActive(true);
            }else{
                 doorMessage.SetActive(false);
            };
            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance) && hit.transform.tag == "Meet")
            {
                meetMessage.SetActive(true);
            }else{
                 meetMessage.SetActive(false);
            }            
        }
    }
}
