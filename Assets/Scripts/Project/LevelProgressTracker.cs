using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressTracker : Singleton<LevelProgressTracker>
{
    private float playerProgress;
    public float PlayerProgress { get { return playerProgress; } }

    private GameObject finishLine;
    private GameObject player;

    private float totalDistance;
    private float currentDistance;
    private bool isFinished = false;

    private void Awake()
    {
        // TODO type'la dene 
        finishLine = GameObject.FindGameObjectWithTag("FinishLine");
        player = GameObject.FindGameObjectWithTag("Player");
    }
    private void Start()
    {
       totalDistance = Mathf.Abs(finishLine.transform.position.z - player.transform.position.z);
       currentDistance = Mathf.Abs(finishLine.transform.position.z - player.transform.position.z);       
    }
    private void Update()
    {
        CalculateLevelProgress();
    }
    private void CalculateLevelProgress()
    {
        currentDistance = Mathf.Abs(finishLine.transform.position.z - player.transform.position.z);
        playerProgress = Mathf.Round(((totalDistance - currentDistance) / totalDistance) * 100);

        CheckWinCondition();
    }
    private void CheckWinCondition()
    {
        if ((int)playerProgress == 100 && !isFinished)
        {
            isFinished = true;
            EventManager.OnLevelFinish?.Invoke();            
            Time.timeScale = 0f;
        }
    }
}
