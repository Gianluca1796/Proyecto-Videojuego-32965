using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public Light interactableLight;
    public bool isLigth;
    private bool lightOnOff;
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



    private void Update()
    {
        interactableLights();
    }


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
    public void interactableLights()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance))
        {
            if (hit.collider.GetComponent<Interactable>() == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (hit.collider.GetComponent<Interactable>().isLigth == true)
                    {
                        hit.collider.GetComponent<Interactable>().changeOnOff();
                    }
                }
            }
        }
    }
}

