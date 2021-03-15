using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLevelRecord : Singleton<PlayerLevelRecord>
{  
    private void OnEnable()
    {
        EventManager.OnLevelFinish.AddListener(KeepLevelData);
    }

    private void OnDisable()
    {
        EventManager.OnLevelFinish.RemoveListener(KeepLevelData);
    }

    private void KeepLevelData()
    {        
        int levelNumber = LevelManager.Instance.CurrentSceneIndex;     
        PlayerPrefs.SetInt("LEVEL_DATA", levelNumber + 1);
        PlayerPrefs.Save();
        Debug.Log(PlayerPrefs.GetInt("LEVEL_DATA"));
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
