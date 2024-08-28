using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    public float rotationSpeed = 10f; // Adjust the torque amount for desired rotation speed

    private Rigidbody rb;

    void Start()
    {
        // Get the Rigidbody component attached to the wall
        rb = GetComponent<Rigidbody>();
    }

    void FixedUpdate()
    {
        // Apply torque around the y-axis (upwards), which will rotate the wall
        rb.angularVelocity = Vector3.up * rotationSpeed;
    }
}
