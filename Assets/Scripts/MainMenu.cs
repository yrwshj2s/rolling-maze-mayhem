using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Function to load the gameplay scene
    public void PlayGame()
    {
        SceneManager.LoadScene("LevelSelect"); // Replace with the actual scene name
    }

    // Function to load the controls tutorial or information
    public void LearnControls()
    {
        // Load a new scene or display a panel with controls information
        SceneManager.LoadScene("Controls"); // Replace with the actual scene name or show a panel
    }

    // Function to quit the game
    public void QuitGame()
    {
        Debug.Log("Quit Game");
        Application.Quit();
    }
}

