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
        EventManager.OnLevelStart?.Invoke();
        Time.timeScale = 1f;
        Debug.Log(currentSceneIndex);
    }

    public void LoadNextScene()
    {
        SceneManager.LoadScene(currentSceneIndex + 1);        
    }

    public void LoadMainMenu()
    {
        SceneManager.LoadScene("Main Menu"); //check name of the scene
    }

    public void LoadLastLevel()
    {       
        SceneManager.LoadScene(PlayerRecord.Instance.GetLastLevel());
    }

    public void ResetScene()
    {
        SceneManager.LoadScene(currentSceneIndex);        
    }
}
