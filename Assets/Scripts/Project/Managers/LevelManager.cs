using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : Singleton<LevelManager>
{
    private int currentSceneIndex;
    public int CurrentSceneIndex { get { return currentSceneIndex; } }

    private void Awake()
    {        
        currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
    }

    private void Start()
    {
        if (currentSceneIndex == 1)
        {
            EventManager.OnFirstLevelStart?.Invoke();
        }    
        
        EventManager.OnLevelStart?.Invoke();        
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("MainMenu");
    }

    public void LoadLastLevel()
    {
        int maxLevelReached = PlayerLevelRecord.Instance.GetLastLevel();        
        SceneManager.LoadScene(maxLevelReached);
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(currentSceneIndex);        
    }
}
