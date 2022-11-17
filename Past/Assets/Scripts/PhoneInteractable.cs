using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhoneInteractable : MonoBehaviour
{
    public AudioSource callSound;
    public GameObject cam;
    public CameraMovement camMov;
    public Transform camTransform;
    public RaycastHit hit;
    private float rayDistance;
    public AudioSource noteSlide;
    public GameObject phoneInteractable;

    public GameObject noteAtTheDoor;


    private void Start()
    {

        cam = GameObject.Find("Camera");
        camTransform = cam.GetComponent<Transform>();
        camMov = cam.GetComponent<CameraMovement>();
        hit = camMov.hit;
        rayDistance = camMov.rayDistance;
    }

    private void Update()
    {
        PhoneInter();
    }
    public void call()
    {
        cam.GetComponent<TvInteractable>().phoneRing.Pause();
        callSound.Play();
        StartCoroutine("desactivePhone");
    }

    void PhoneInter()
    {
        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance))
        {
            if (hit.transform.tag == "Phone")
            {
                if (Input.GetMouseButtonDown(0))
                {

                    call();
                }
                Debug.Log("Anda desde phone");
            }
        }
    }
    IEnumerator desactivePhone()
    {
        yield return new WaitForSeconds(17);
        phoneInteractable.SetActive(false);
        noteSlide.Play();
        noteAtTheDoor.SetActive(true);
        
    }
}