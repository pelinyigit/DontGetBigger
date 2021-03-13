using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayButton : Button
{
    protected override void OnEnable()
    {
        base.OnEnable();
        onClick.AddListener(PlayGame);
    }

    protected override void OnDisable()
    {
        base.OnDisable();
        onClick.RemoveListener(PlayGame);
    }

    private void PlayGame()
    {
        //LevelManager.Instance.LoadLastLevel();
        LevelManager.Instance.LoadNextScene();
    }
}
