using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PortalCode : MonoBehaviour
{
    private PortalHandler portalHandler;

    private void Start()
    {
        // Get the PortalHandler from the parent object
        portalHandler = FindObjectOfType<PortalHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify the PortalHandler that this portal has been activated
            portalHandler.ActivatePortal(transform);
        }
    }
}
