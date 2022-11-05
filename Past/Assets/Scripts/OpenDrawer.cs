using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDrawer : MonoBehaviour
{
    public GameObject cam;
    public CameraMovement camMov;
    public Transform camTransform;
    public RaycastHit hit;
    public Animator drawer;
    public Animator drawer2;
    private bool isOpen;
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
        raycastDrawer();

    }
    void raycastDrawer()
    {

        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance) && hit.transform.tag == "Drawer" && Input.GetMouseButtonDown(0))
        {
            isOpen = !isOpen;
            Debug.Log(hit.transform.name);
            if (isOpen == true)
            {
                drawer.SetBool("OpenDrawer", true);
            }
            if (isOpen == false)
            {
                drawer.SetBool("OpenDrawer", false);
            }


        }

    }
    // if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance, LayerMask.GetMask("Interactable3")))
    // {
    //     if (Input.GetMouseButtonDown(0))
    //     {
    //         isOpen = !isOpen;
    //         Debug.Log(hit.transform.name);
    //         if (isOpen == true)
    //         {
    //             drawer2.SetBool("openDrawer2", true);
    //         }
    //         if (isOpen == false)
    //         {
    //             drawer2.SetBool("openDrawer2", false);
    //         }
    //     }
    // }
}

