using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TryAgainButton : Button
{    
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(RestartLevel);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onClick.RemoveListener(RestartLevel);
    }

    private void RestartLevel()
    {
        LevelManager.Instance.ResetScene();
    }
}
