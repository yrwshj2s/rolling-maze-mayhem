using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{

    public void EndLevel()
    {
        // Load the next scene by Build Index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is within the valid range
        if (nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more levels to load. End of game.");
            // Optionally, handle what happens at the end of the game, like showing a "You Win" screen.
        }
    }

    public void LevelLoad(int levelNo)
    {
        SceneManager.LoadScene(levelNo);
    }
}
