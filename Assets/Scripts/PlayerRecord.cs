using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRecord : Singleton<PlayerRecord>
{
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(KeepLevelData);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(KeepLevelData);
    }
    private void KeepLevelData()
    {        
        int levelNumber = LevelManager.Instance.CurrentSceneIndex;     
        PlayerPrefs.SetInt("LEVEL_DATA", levelNumber);
    }
    public int GetLastLevel()
    {
        if (!PlayerPrefs.HasKey("LEVEL_DATA"))
        {
            PlayerPrefs.SetInt("LEVEL_DATA", 1);
        }
        return PlayerPrefs.GetInt("LEVEL_DATA");
    }
}
