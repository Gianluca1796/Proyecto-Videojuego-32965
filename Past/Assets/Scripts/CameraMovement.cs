using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMovement : MonoBehaviour
{
    public float mouseSensitivity = 80f;
    public Transform player;
    public new Transform camera;
    public GameObject principalCamera;
    public GameObject secondaryCamera;
    public GameObject finalSprite;
    public GameObject finalNote;
    public float rayDistance = 2f;
    float xRotation = 0;
    public RaycastHit hit;
    public bool cubeRed;
    public bool cubeViolet;
    public bool cubeGreen;
    public Texture2D pointer;
    public Texture2D redPointer;
    bool canInteract = false;
    public GameObject dialogueZone;
    public Dialogue dialogueScript;
    public GameObject maskInTheFloor;
    public GameObject maskInCamera;

    private bool final;


    private void Start()
    {
        dialogueZone = GameObject.Find("DialogueZone");
        dialogueScript = dialogueZone.GetComponent<Dialogue>();
        maskInTheFloor = dialogueScript.maskInTheFloor;

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

        SearchObject();

        Interactable();
        GrabMask();

    }

    void SearchObject()
    {
        canInteract = false;
        if (Physics.Raycast(camera.position, camera.forward * rayDistance, out hit, rayDistance, LayerMask.GetMask("Interactable")))
        {
            canInteract = true;
        }

    }

    void Interactable()
    {

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

    void OnGUI()
    {
        Rect rect = new Rect(Screen.width / 2, Screen.height / 2, pointer.width, pointer.height);
        GUI.DrawTexture(rect, pointer);
        if (canInteract)
        {
            GUI.DrawTexture(rect, redPointer);
        }
    }
    void GrabMask()
    {
        if (Physics.Raycast(camera.position, camera.forward * rayDistance, out hit, rayDistance) && hit.transform.tag == "Mask" && Input.GetMouseButtonDown(0))
        {
            Debug.Log("anda desde el click");
            maskInTheFloor.SetActive(false);
            maskInCamera.SetActive(true);
            final = true;
            StartCoroutine(ChageCamera());


        }
    }
    void Final()
    {
        if (final == true)
        {
            principalCamera.SetActive(false);
            secondaryCamera.SetActive(true);
            finalSprite.SetActive(true);
            finalNote.SetActive(true);
            
        }
    }
    private IEnumerator ChageCamera()
    {
        yield return new WaitForSeconds(5);
        Final();

    }



}

