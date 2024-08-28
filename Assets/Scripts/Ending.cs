using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ending : MonoBehaviour
{
    public GameObject levelFinish;

    private void Start() {
        Time.timeScale = 1f;
        levelFinish.SetActive(false);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player")
        {
            Time.timeScale = 0f;
            levelFinish.SetActive(true);
        }
    }
}
