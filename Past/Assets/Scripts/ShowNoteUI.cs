using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShowNoteUI : MonoBehaviour
{
    public GameObject UINote;
    private bool active;
    void Update()
    {
        if (Input.GetMouseButtonDown(0) && active == true)
        {
            UINote.SetActive(true);
            
            
        }

    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Player")
        {
            active = true;
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Player")
        {
            active = false;
            UINote.SetActive(false);
            
        }
    }
}
