using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public CharacterController controller;
    public float speedMove = 2f;
    public float life = 100;
    public AudioSource walk;
    private bool horActive;
    private bool VerActive;
    void Start()
    {

    }

    void Update()
    {
        MovementPlayer();
        Damage();
        RestoreHealth();
    }

    void MovementPlayer()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 direction = transform.right * x + transform.forward * z;
        controller.Move(direction * speedMove * Time.deltaTime);
        if(Input.GetButtonDown("Horizontal"))
        {
            horActive = true;
            walk.Play();
        }
        if(Input.GetButtonDown("Vertical"))
        {
            VerActive = true;
            walk.Play();
        }
        if(Input.GetButtonUp("Horizontal"))
        {
            horActive = false;
            if(VerActive == false)
            {
            walk.Pause();
            }
        }
        if(Input.GetButtonUp("Vertical"))
        {
            VerActive = false;
            if(horActive == false)
            {
            walk.Pause();
            }
        }
    }

    void Damage()
    {
        if (Input.GetKey(KeyCode.S))
        {
            life-= Time.deltaTime;
            Debug.Log("Mi vida esta bajando");
        }
    }
    void RestoreHealth()
    {
        if (Input.GetKey(KeyCode.W))
        {
            life+= Time.deltaTime;
            Debug.Log("Mi vida esta subiendo");
        }
    }
}
