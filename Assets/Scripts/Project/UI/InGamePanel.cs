using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InGamePanel : Panel
{
    [SerializeField] Slider levelProgressSlider;
    [SerializeField] Slider scaleSlider;
    [SerializeField] Text scoreText;
    [SerializeField] Canvas instructionsCanvas;

    float levelProgressPercentage;
    int scaleValue = 1; // todo daha iyi bir yol bul
    int totalScore;

    private void OnEnable()
    {
        EventManager.OnFirstLevelStart.AddListener(ShowInstructions);
        EventManager.OnLevelStart.AddListener(ShowPanel);
        EventManager.OnLevelFail.AddListener(HidePanel);
        EventManager.OnLevelFinish.AddListener(HidePanel);

        EventManager.OnPlayerScaleUp.AddListener(ScaleUpTrack);
        EventManager.OnPlayerScaleDown.AddListener(ScaleDownTrack);

        EventManager.OnCollectibleGathered.AddListener(ScoreTrack);
    }
    private void OnDisable()
    {
        EventManager.OnFirstLevelStart.RemoveListener(ShowInstructions);
        EventManager.OnLevelStart.RemoveListener(ShowPanel);
        EventManager.OnLevelFail.RemoveListener(HidePanel);
        EventManager.OnLevelFinish.RemoveListener(HidePanel);

        EventManager.OnPlayerScaleUp.RemoveListener(ScaleUpTrack);
        EventManager.OnPlayerScaleDown.RemoveListener(ScaleDownTrack);

        EventManager.OnCollectibleGathered.RemoveListener(ScoreTrack);
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

    private void ScoreTrack(int score)
    {
        totalScore += score;
        scoreText.text = totalScore.ToString();
    }

    private void ShowInstructions()
    {
        StartCoroutine(ShowInstructionsCoroutine());
    }

    private IEnumerator ShowInstructionsCoroutine()
    {
        Time.timeScale = 0f;
        instructionsCanvas.gameObject.SetActive(true);
        yield return new WaitForSecondsRealtime(5f);
        instructionsCanvas.gameObject.SetActive(false);
        Time.timeScale = 1f;
    }
}
