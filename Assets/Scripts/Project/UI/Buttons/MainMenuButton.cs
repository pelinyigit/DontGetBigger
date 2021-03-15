using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MainMenuButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(LoadMainMenu);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onClick.RemoveListener(LoadMainMenu);
    }

    private void LoadMainMenu()
    {
        LevelManager.Instance.LoadMainMenu();        
    }
}
