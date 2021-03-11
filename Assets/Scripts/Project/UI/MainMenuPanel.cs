using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainMenuPanel : Panel
{
    private void OnEnable()
    {   
        EventManager.OnGameStart.AddListener(HidePanel);
        EventManager.OnGameOver.AddListener(ShowPanel);
    }

    private void OnDisable()
    {      
        EventManager.OnGameStart.RemoveListener(HidePanel);
        EventManager.OnGameOver.RemoveListener(ShowPanel);
    }
}
