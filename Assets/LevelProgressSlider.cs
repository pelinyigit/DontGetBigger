using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelProgressSlider : MonoBehaviour
{
    [SerializeField] Text currentLevelText;
    [SerializeField] Text nextLevelText;
    [SerializeField] Text levelProgressText;

    private void Start()
    {        
        currentLevelText.text = LevelManager.Instance.CurrentSceneIndex.ToString();
        nextLevelText.text = (LevelManager.Instance.CurrentSceneIndex + 1).ToString();
    }

    private void Update()
    {
        levelProgressText.text = (LevelProgressTracker.Instance.PlayerProgress.ToString() + "%");
    }
}
