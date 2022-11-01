using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TvInteractable : MonoBehaviour
{
    public SpriteRenderer tvStatic;
    public GameObject Static;
    public AudioSource tvSound;
    private bool staticOnOff;
    public GameObject phoneInteractable;
    public AudioSource phoneRing;
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
        tvInter();
    }

    public void staticChangeOnOff()
    {
        StartCoroutine("turnOffTV");

        staticOnOff = !staticOnOff;
        if (staticOnOff == true)
        {
            tvStatic.enabled = true;
            phoneInteractable.SetActive(true);
            tvSound.Play();
        }
        if (staticOnOff == false)
        {
            tvStatic.enabled = false;
            tvSound.Pause();
        }
    }
    void tvInter()
    {

        if (Physics.Raycast(camTransform.position, camTransform.forward, out hit, rayDistance))
        {
            if (hit.transform.tag == "Static")
            {
                if (Input.GetMouseButtonDown(0))
                {
                    staticChangeOnOff();
                }
            }

        }
    }
        IEnumerator turnOffTV()
        {
            yield return new WaitForSeconds(10);
            tvSound.Pause();
            phoneRing.Play();
            tvStatic.enabled = false;
            Static.SetActive(false);
        }
}
