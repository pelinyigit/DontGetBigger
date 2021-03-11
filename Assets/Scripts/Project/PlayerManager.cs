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
        EventManager.OnCharacterToScaleUp.AddListener(ScaleUp);
        EventManager.OnCharacterToScaleDown.AddListener(ScaleDown);
    }
    private void Start()
    {        
        snowBallState = SnowBallState.Small;
    }
    private void OnDisable()
    {
        EventManager.OnCharacterToScaleUp.RemoveListener(ScaleUp);
        EventManager.OnCharacterToScaleDown.RemoveListener(ScaleDown);
    }
    private void ScaleUp()
    {
        // TODO : lose condition will be edited 
        if (snowBallState != SnowBallState.Large)
        {
            snowBallState++;
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * scaleFactor, scaleGraceTime);
            Debug.Log("State:" + snowBallState);
        }
        else if (snowBallState == SnowBallState.Large)
        {
            EventManager.OnLevelFail?.Invoke();
        }
    }
    private void ScaleDown()
    {
        if (snowBallState != SnowBallState.Small)
        {            
            snowBallState--;
            transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale / scaleFactor, scaleGraceTime);
            Debug.Log("State:" + snowBallState);
        }
    }
    

}
