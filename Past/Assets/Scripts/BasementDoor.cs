using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasementDoor : MonoBehaviour
{
    public int key;
    private GameObject basementDoor;
    private GameObject keyObject;
    public GameObject keyUI;


    private void Start()
    {
        basementDoor = GameObject.Find("BasementDoor");
        keyObject = GameObject.Find("Key");
    }
    void Update()
    {
        KeyUI();
    }

    void KeyUI()
    {
        if (key == 1)
        {
            Debug.Log("anda desde BasementDoor");
            keyUI.SetActive(true);
            basementDoor.SetActive(false);
            Destroy(keyObject);
        }
    }
}
