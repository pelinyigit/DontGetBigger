using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFinishPanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(HidePanel);
        EventManager.OnLevelFinish.AddListener(ShowPanel);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(HidePanel);
        EventManager.OnLevelFinish.RemoveListener(ShowPanel);
    }
}
