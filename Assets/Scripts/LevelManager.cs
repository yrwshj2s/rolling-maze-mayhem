using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public MusicManager musicManager;

    public void EndLevel()
    {
        // Load the next scene by Build Index
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;

        // Check if the next scene index is within the valid range
        if (musicManager!=null && nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            musicManager.FadeOutAndSwitchScene(nextSceneIndex);
        }
        else if(nextSceneIndex < SceneManager.sceneCountInBuildSettings)
        {
            SceneManager.LoadScene(nextSceneIndex);
        }
        else
        {
            Debug.LogWarning("No more levels to load. End of game.");
        }
    }

    public void LevelLoad(int levelNo)
    {
        if(musicManager != null)
        {
            musicManager.FadeOutAndSwitchScene(levelNo);
        }
        else 
        {
            SceneManager.LoadScene(levelNo);
        }
    }
}
