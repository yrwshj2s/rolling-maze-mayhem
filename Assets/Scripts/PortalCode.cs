using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class PortalCode : MonoBehaviour
{
    private PortalHandler portalHandler;
    public AudioClip teleportationSound;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the PortalHandler from the parent object
        audioSource = GetComponent<AudioSource>();
        portalHandler = FindObjectOfType<PortalHandler>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            // Notify the PortalHandler that this portal has been activated
            portalHandler.ActivatePortal(transform);
            audioSource.PlayOneShot(teleportationSound);
        }
    }
}
