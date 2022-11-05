using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleSound : MonoBehaviour
{
    public GameObject objectToFind;
    public AudioSource Sounds;
    public GameObject puzzleMessage;
    public GameObject cubeBox;
    public AudioSource cubeBoxSound;

    public CubesPuzzle cubesPuzzle;

    private void Start()
    {
        objectToFind = GameObject.Find("PuzzleSound");
        Sounds = objectToFind.GetComponent<AudioSource>();
        cubeBox = GameObject.Find("CubesBox");
        cubeBoxSound = cubeBox.GetComponent<AudioSource>();
        cubesPuzzle = cubeBox.GetComponent<CubesPuzzle>();


    }
    private void OnTriggerEnter(Collider other)
    {

        if (other.tag == "Player")
        {
            Sounds.Play();
            puzzleMessage.SetActive(true);

        }

    }
    private void OnTriggerStay(Collider other)
    {
        if (other.tag == "Player")
        {
            Sounds.volume -= 0.001f;
            if (cubesPuzzle.cubes == 3)
            {
                cubeBoxSound.Play();
            }

        }
        if (Sounds.volume == 0)
        {
            gameObject.SetActive(false);
            puzzleMessage.SetActive(false);
        }

    }

    private void OnTriggerExit(Collider other)
    {
        Sounds.Pause();
        puzzleMessage.SetActive(false);
    }
}
