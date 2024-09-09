using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalHandler : MonoBehaviour
{
    public Transform orangePortalTransform;
    public Transform bluePortalTransform;
    private bool isTeleporting = false;
    public Transform player;
    public GameObject orangePortalPrefab;
    public GameObject bluePortalPrefab;
    private GameObject orangePortal;
    private GameObject bluePortal;

    public AudioClip portalPlacementSound;
    private AudioSource audioSource;

    private void Start()
    {
        // Get the AudioSource component from the object
        audioSource = GetComponent<AudioSource>();
    }

    // This method will be called by the portal that the player enters
    public void ActivatePortal(Transform enteredPortal)
    {
        if (isTeleporting)
            return;

        Transform destinationPortal = null;

        if (enteredPortal == orangePortalTransform)
        {
            destinationPortal = bluePortalTransform;
        }
        else if (enteredPortal == bluePortalTransform)
        {
            destinationPortal = orangePortalTransform;
        }

        if (destinationPortal != null)
        {
            StartCoroutine(TeleportPlayer(enteredPortal, destinationPortal));
        }
    }

    private IEnumerator TeleportPlayer(Transform enteredPortal, Transform destinationPortal)
    {
        isTeleporting = true;
        Rigidbody rb = player.GetComponent<Rigidbody>();
        Vector3 preservedVelocity = rb.velocity;
        
        // Teleport the player
        player.transform.position = new Vector3(destinationPortal.position.x, player.position.y, destinationPortal.position.z);

        rb.velocity = preservedVelocity;
        // Wait for a short time to prevent immediate re-trigger
        yield return new WaitForSeconds(0.05f);

        isTeleporting = false;
    }

    void Update()
    {
        HandlePortalPlacement();
    }

    void HandlePortalPlacement()
    {
        if (Input.GetMouseButtonDown(1))
        {
            PlacePortal(ref orangePortal, orangePortalPrefab, ref orangePortalTransform);
        }

        if (Input.GetMouseButtonDown(0))
        {
            PlacePortal(ref bluePortal, bluePortalPrefab, ref bluePortalTransform);
        }
    }

    void PlacePortal(ref GameObject portal, GameObject portalPrefab, ref Transform portalTransform)
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        // Check if the ray hits a surface that is allowed to have portals
        if (Physics.Raycast(ray, out hit))
        {
            if(!hit.transform.CompareTag("YesPortal"))
                return;
            Vector3 portalPosition = hit.point;
            portalPosition.y = 1.8f; // Assuming ground level is at y=0, adjust if necessary

            // Orient the portal to face upwards, making it horizontal on the ground
            Quaternion portalRotation = Quaternion.Euler(0, 0, 0);

            // If the portal already exists, move it to the new position
            if (portal != null)
            {
                portal.transform.position = portalPosition;
                portal.transform.rotation = portalRotation;
            }
            else
            {
                // Instantiate the portal at the hit point and orient it to face away from the surface
                portal = Instantiate(portalPrefab, portalPosition, portalRotation);
                
            }
            portalTransform = portal.transform;
            audioSource.PlayOneShot(portalPlacementSound);
            
        }
    }
}
