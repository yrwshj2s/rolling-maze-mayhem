using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed = 10f; // Adjust the torque amount for desired rotation speed

    private Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        if(rb == null)
        {
            rb = GetComponentInChildren<Rigidbody>();
        }
    }

    void FixedUpdate()
    {
        rb.angularVelocity = Vector3.up * rotationSpeed;
    }
}
