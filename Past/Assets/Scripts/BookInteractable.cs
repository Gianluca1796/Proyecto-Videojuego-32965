using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BookInteractable : MonoBehaviour
{
    public GameObject cam;
    public CameraMovement camMov;
    public Transform camTransform;
    public RaycastHit hit;
    private float rayDistance;

    public GameObject openBook;
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
        bookInter();
    }

    void bookInter()
    {

        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance))
        {
            if (hit.transform.tag == "Book")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    openBook.SetActive(true);
                }
            }
        }
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            openBook.SetActive(false);
        }

    }
}
