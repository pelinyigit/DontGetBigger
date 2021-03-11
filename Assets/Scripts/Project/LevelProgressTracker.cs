using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelProgressTracker : MonoBehaviour
{
    public float playerProgress;
    
    private float totalDistance;

    private float currentDistance;

    private bool isFinished = false;

    Player playa;

    [Space]
    [SerializeField] private Transform finishPosition;
    
    [Space]
    [SerializeField] private Transform player;

    private void Start()
    {
       totalDistance = Mathf.Abs(finishPosition.position.z - player.position.z);
       currentDistance = Mathf.Abs(finishPosition.position.z - player.position.z);

       Debug.Log(playa.PlayerPosZ);
    }

    private void Update()
    {
        CalculateLevelProgress();

    }

    private void CalculateLevelProgress()
    {
        currentDistance = Mathf.Abs(finishPosition.position.z - player.position.z);
        playerProgress = Mathf.Round(((totalDistance - currentDistance) / totalDistance) * 100);

        CheckWinCondition();
    }

    private void CheckWinCondition()
    {
        if ((int)playerProgress == 100 && !isFinished)
        {
            isFinished = true;
            EventManager.OnLevelFinish?.Invoke();
            Debug.Log("Level Completed");
            
        }
    }
}
