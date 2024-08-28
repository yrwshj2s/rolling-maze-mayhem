using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destruction : MonoBehaviour
{
    // The tag used to identify the player objec
    public GameObject objectToDisappear;

    // Reference to the second object (the one that should appear)
    public GameObject objectToAppear;

    public void HandleDestruction()
    {

        objectToDisappear.SetActive(false);
        objectToAppear.SetActive(true);
    }

}