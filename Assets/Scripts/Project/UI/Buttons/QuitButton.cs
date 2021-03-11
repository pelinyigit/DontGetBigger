using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuitButton : Button
{    
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(QuitGame);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onClick.RemoveListener(QuitGame);
    }

    private void QuitGame()
    {
        Application.Quit();
    }
}
