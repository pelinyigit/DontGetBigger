using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class NextLevelButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(Proceed);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onClick.RemoveListener(Proceed);
    }

    private void Proceed()
    {
        LevelManager.Instance.LoadNextScene();
    }
}
