using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelFailPanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(HidePanel);
        EventManager.OnLevelFail.AddListener(ShowPanel);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(HidePanel);
        EventManager.OnLevelFail.RemoveListener(ShowPanel);
    }
}
