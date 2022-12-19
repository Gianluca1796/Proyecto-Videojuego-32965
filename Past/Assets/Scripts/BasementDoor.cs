using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoor : MonoBehaviour
{
    public int key;
    public GameObject activeZone;
    public GameObject isClosedZoned;
    private GameObject keyObject;
    public GameObject keyUI;
    public GameObject cam;
    public CameraMovement camMov;
    public Transform camTransform;
    public RaycastHit hit;
    private float rayDistance;


    private void Start()
    {
        keyObject = GameObject.Find("Key");
        cam = GameObject.Find("Camera");
        camTransform = cam.GetComponent<Transform>();
        camMov = cam.GetComponent<CameraMovement>();
        hit = camMov.hit;
        rayDistance = camMov.rayDistance;
    }
    void Update()
    {
        TakeKey();
        KeyUI();
    }

    void KeyUI()
    {
        if (key == 1)
        {
            Debug.Log("anda desde BasementDoor");
            keyUI.SetActive(true);
            activeZone.SetActive(true);
            isClosedZoned.SetActive(false);
            Destroy(keyObject);
        }
    }
    public void TakeKey()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward * rayDistance, out hit, rayDistance))
        {
            if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance) && hit.transform.tag == "Key" && Input.GetMouseButtonDown(0))
            {

                key = 1;
            }

        }
    }
}
