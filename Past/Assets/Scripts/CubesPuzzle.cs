using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubesPuzzle : MonoBehaviour
{
    private bool puzzleDone;
    public int cubes = 0;
    private GameObject cam;

    [SerializeField]
    private GameObject newCubeRed;
    [SerializeField]
    private GameObject newCubeGreen;
    [SerializeField]
    private GameObject newCubeViolet;
    public GameObject cubeRedInHand;
    public GameObject cubeGreenInHand;
    public GameObject cubeVioletInHand;
    public GameObject closetToDestroy;
    public GameObject closetToActivate;
    


    private void Start()
    {
        cam = GameObject.Find("Camera");
    }
    void Update()
    {
        cubePuzzleDone();
    }

    public void cubeRed()
    {
        cubes += 1;
        newCubeRed.SetActive(true);
        Debug.Log(cubes);
        Debug.Log("Puse el rojo");
        Destroy(cubeRedInHand);
        cam.GetComponent<CameraMovement>().cubeRed = false;
    }
    public void cubeGreen()
    {
        cubes += 1;
        newCubeGreen.SetActive(true);
        Debug.Log(cubes);
        Debug.Log("Puse el verde");
        Destroy(cubeGreenInHand);
        cam.GetComponent<CameraMovement>().cubeGreen = false;
    }
    public void cubeViolet()
    {
        cubes += 1;
        newCubeViolet.SetActive(true);
        Debug.Log(cubes);
        Debug.Log("Puse el violeta");
        Destroy(cubeVioletInHand);
        cam.GetComponent<CameraMovement>().cubeViolet = false;

    }
    void cubePuzzleDone()
    {
        if (cubes == 3)
        {
            puzzleDone = true;

        }
        actions();
    }
    void actions()
    {
        if (puzzleDone == true)
        {
            closetToDestroy.SetActive(false);
            closetToActivate.SetActive(true);        
        }
    }


}
