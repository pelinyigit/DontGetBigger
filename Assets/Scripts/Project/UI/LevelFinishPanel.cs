using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelFinishPanel : Panel
{      
    public Text finalScoreText;
    public int totalScore;    

    public GameObject winCanvas;
    public GameObject[] stars;    

    private void Start()
    {
        finalScoreText.text = totalScore.ToString();
    }

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(HidePanel);
        EventManager.OnLevelFinish.AddListener(ShowPanel);
        EventManager.OnLevelFinish.AddListener(WinCanvasTrigger);

        EventManager.OnCollectibleGathered.AddListener(ScoreTrack);
    }

    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(HidePanel);
        EventManager.OnLevelFinish.RemoveListener(ShowPanel);
        EventManager.OnLevelFinish.RemoveListener(WinCanvasTrigger);

        EventManager.OnCollectibleGathered.RemoveListener(ScoreTrack);
        StopAllCoroutines();
    }

    IEnumerator ShowStarsCo()
    {
        winCanvas.SetActive(true);

        if (totalScore < 30)
        {
            stars[0].SetActive(true);//SHOW first star
            yield return new WaitForSeconds(1.0f);//MARKER After one second, you can press the restart button to play again            
        }
        else if (totalScore < 60)
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);//Show Second star
            yield return new WaitForSeconds(1.0f);           
        }
        else
        {
            stars[0].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[1].SetActive(true);
            yield return new WaitForSeconds(1.0f);
            stars[2].SetActive(true);//SHOW FULL STARS
            yield return new WaitForSeconds(1.0f);            
        }
    }
    private void ScoreTrack(int score)
    {
        totalScore += score;
        finalScoreText.text = totalScore.ToString();
    }

    private void WinCanvasTrigger()
    {
        StartCoroutine(ShowStarsCo());
    }
}
