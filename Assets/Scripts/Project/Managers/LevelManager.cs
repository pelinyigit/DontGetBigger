using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    int currentSceneIndex;

    private void Start()
    {
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        EventManager.OnLevelStart?.Invoke();
        Time.timeScale = 1f;
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); //check name of the scene
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(currentSceneIndex);        
    }
}
