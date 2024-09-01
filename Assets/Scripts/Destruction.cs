using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    // The tag used to identify the player objec
    public GameObject objectToDisappear;

    // Reference to the second object (the one that should appear)
    public GameObject objectToAppear;

    public AudioClip shatterSound;
    private AudioSource audioSource;
    private Collider wallCollider;
    private MeshRenderer wallRenderer;
    private bool wallBroke;
    private void Start()
    {
        // Get the AudioSource component from the object
        audioSource = GetComponent<AudioSource>();
        wallCollider = objectToDisappear.GetComponent<Collider>();
        wallRenderer = objectToDisappear.GetComponent<MeshRenderer>();
        wallBroke=false;
    }

    public void HandleDestruction()
    {
        wallCollider.enabled = false;
        wallRenderer.enabled = false;
        if(!wallBroke)
        {
            audioSource.PlayOneShot(shatterSound);
        }
        wallBroke=true;
        objectToAppear.SetActive(true);
    }

}