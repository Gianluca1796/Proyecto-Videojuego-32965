using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    public float movementSpeed = 0.1f;
        
    public Vector3 scale;


    void Start()
    {
        transform.localScale = scale; 

    }

    void Update()
    {
        transform.position += direction * movementSpeed * Time.deltaTime;
    }

}

