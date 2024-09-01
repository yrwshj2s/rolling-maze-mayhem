using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class SpeedMonitor : MonoBehaviour
{
    public float speedThreshold = 10f;
    private bool isPlayerInside = false;
    private Rigidbody playerRb;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            playerRb = other.GetComponent<Rigidbody>();
            isPlayerInside = true;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInside = false;
            playerRb = null;
        }
    }

    private void FixedUpdate()
    {
        if (isPlayerInside && playerRb != null)
        {
            // Calculate the speed (magnitude of the velocity vector)
            float speed = playerRb.velocity.magnitude;

            Debug.Log("Magnitude is " + speed);

            // Check if the speed exceeds the threshold
            if (speed > speedThreshold)
            {
                // Find the sibling object called "Fixed Wall"
                Transform fixedWallTransform = transform.parent.Find("Fixedwall");

                if (fixedWallTransform != null)
                {
                    // Get the Destruction script from the sibling object
                    Destruction destructionScript = fixedWallTransform.GetComponent<Destruction>();

                    if (destructionScript != null)
                    {
                        // Call the method to handle destruction
                        destructionScript.HandleDestruction();
                    }
                    else
                    {
                        Debug.LogWarning("Destruction script not found on Fixed Wall.");
                    }
                }
                else
                {
                    Debug.LogWarning("Fixed Wall sibling not found.");
                }
            }
        }
    }
}
