using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class MoveBall : MonoBehaviour
{
    public Rigidbody rb;
    public float movementSpeed;
    public float factor;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        Time.timeScale = 1f;
    }

    void FixedUpdate()
    {
        if(Input.GetKey("w"))
        {
            rb.AddForce(0,0,movementSpeed);
        }
        if(Input.GetKey("s"))
        {
            rb.AddForce(0,0,-movementSpeed);
        }
    
        if(Input.GetKey("d"))
        {
            rb.AddForce(movementSpeed, 0,0);
        }
        if(Input.GetKey("a"))
        {
            rb.AddForce(-movementSpeed, 0,0);
        }
    }
}
