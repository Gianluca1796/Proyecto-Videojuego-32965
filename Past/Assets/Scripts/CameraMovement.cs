using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public Transform player;
    public new Transform camera;
    public float rayDistance = 2f;
    float xRotation = 0;
    public RaycastHit hit;
    public bool cubeRed;
    public bool cubeViolet;
    public bool cubeGreen;


    private void Start()
    {
        

    }
    void Update()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
        xRotation -= mouseY;

        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);

        player.Rotate(Vector3.up * mouseX);
        
        Debug.DrawRay(camera.position, camera.forward * rayDistance, Color.blue);

        Interactable();

    }

    void Interactable()
    {
        RaycastHit hit;
        if (Physics.Raycast(camera.position, camera.forward * rayDistance, out hit, rayDistance))
        {
            if (hit.collider.GetComponent<CubesPuzzle>() == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    if (cubeRed == true)
                    {
                        hit.collider.GetComponent<CubesPuzzle>().cubeRed();
                    }
                    if (cubeViolet == true)
                    {
                        hit.collider.GetComponent<CubesPuzzle>().cubeViolet();
                    }
                    if (cubeGreen == true)
                    {
                        hit.collider.GetComponent<CubesPuzzle>().cubeGreen();
                    }
                }
            }
            if (hit.collider.GetComponent<GrabCube>() == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<GrabCube>().grabGreen();
                }
            }
            if (hit.collider.GetComponent<GrabCubeRed>() == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<GrabCubeRed>().grabRed();
                }
            }
            if (hit.collider.GetComponent<GrabCubeViolet>() == true)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    hit.collider.GetComponent<GrabCubeViolet>().grabViolet();
                }
            }
        }

    }

}

