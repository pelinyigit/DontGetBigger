using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InGamePanel : Panel
{
    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(ShowPanel);
        EventManager.OnLevelFail.AddListener(HidePanel);
        EventManager.OnLevelFinish.AddListener(HidePanel);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(ShowPanel);
        EventManager.OnLevelFail.RemoveListener(HidePanel);
        EventManager.OnLevelFinish.RemoveListener(HidePanel);
    }
}
