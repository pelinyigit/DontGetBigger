using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{ 
    [Space]
    [SerializeField] 
    float scaleFactor;

    [Space]
    [SerializeField]
    float scaleGraceTime = 1f;
    
    public enum SnowBallState {Small, Mid, Large};
    public SnowBallState snowBallState;

    private void OnEnable()
    {
        EventManager.OnSnowmanCollision.AddListener(ScaleUp);
        EventManager.OnFireCollision.AddListener(ScaleDown);
    }
    private void Start()
    {        
        snowBallState = SnowBallState.Small;
    }
    private void OnDisable()
    {
        EventManager.OnSnowmanCollision.RemoveListener(ScaleUp);
        EventManager.OnFireCollision.RemoveListener(ScaleDown);
    }
    private void ScaleUp()
    {
        // TODO : lose condition will be edited 
        if (snowBallState != SnowBallState.Large)
        {
            snowBallState++;
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * scaleFactor, scaleGraceTime);
            EventManager.OnPlayerScaleUp?.Invoke();
            Debug.Log("State:" + snowBallState);
        }
        else if (snowBallState == SnowBallState.Large)
        {
            EventManager.OnLevelFail?.Invoke();
            Time.timeScale = 0f;
        }
    }
    private void ScaleDown()
    {
        if (snowBallState != SnowBallState.Small)
        {            
            snowBallState--;
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale / scaleFactor, scaleGraceTime);
            EventManager.OnPlayerScaleDown?.Invoke();
            Debug.Log("State:" + snowBallState);
        }
    }
    

}
