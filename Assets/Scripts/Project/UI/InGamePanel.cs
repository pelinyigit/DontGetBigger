using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : Panel
{
    [SerializeField] Slider levelProgressSlider;
    [SerializeField] Slider scaleSlider;

    float levelProgressPercentage;
    int scaleValue = 1; // todo daha iyi bir yol bul

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(ShowPanel);
        EventManager.OnLevelFail.AddListener(HidePanel);
        EventManager.OnLevelFinish.AddListener(HidePanel);

        EventManager.OnPlayerScaleUp.AddListener(ScaleUpTrack);
        EventManager.OnPlayerScaleDown.AddListener(ScaleDownTrack);        
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(ShowPanel);
        EventManager.OnLevelFail.RemoveListener(HidePanel);
        EventManager.OnLevelFinish.RemoveListener(HidePanel);

        EventManager.OnPlayerScaleUp.RemoveListener(ScaleUpTrack);
        EventManager.OnPlayerScaleDown.RemoveListener(ScaleDownTrack);
    }
    private void Update()
    {
        levelProgressPercentage = LevelProgressTracker.Instance.PlayerProgress;
        levelProgressSlider.value = levelProgressPercentage;                
    }

    private void ScaleUpTrack()
    {
        scaleValue++;
        scaleSlider.value = scaleValue;
    }

    private void ScaleDownTrack()
    {
        scaleValue--;
        scaleSlider.value = scaleValue;
    }
}
