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
        if (snowBallState != SnowBallState.Large)
        {
            snowBallState++;
            EventManager.OnPlayerScaleUp?.Invoke();
            //transform.localScale = Vector3.Lerp(transform.localScale, transform.localScale * scaleFactor, scaleGraceTime);
            StartCoroutine(ScaleUpSmooth());
        }

        else if (snowBallState == SnowBallState.Large)
        {
            EventManager.OnLevelFail?.Invoke();
            Time.timeScale = 0f;
        }
        
    }

    private IEnumerator ScaleUpSmooth()
    {
        float progress = 0;
        Vector3 maxScale = transform.localScale * scaleFactor;
        while (progress <= 1)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, progress);
            progress += Time.deltaTime * scaleGraceTime;
            yield return null;
        }
    }

    private void ScaleDown()
    {
        if(snowBallState != SnowBallState.Small)
        {
            snowBallState++;
            EventManager.OnPlayerScaleDown?.Invoke();
            //transform.localScale = Vector3.Slerp(transform.localScale, transform.localScale / scaleFactor, scaleGraceTime * Time.deltaTime);
            StartCoroutine(ScaleDownSmooth());
        }

        else if(snowBallState == SnowBallState.Large)
        {
            EventManager.OnLevelFail?.Invoke();
            Time.timeScale = 0f;
        }        
    }

    private IEnumerator ScaleDownSmooth()
    {
        float progress = 0;
        Vector3 maxScale = transform.localScale / scaleFactor;
        while (progress <= 1)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, maxScale, progress);
            progress += Time.deltaTime * scaleGraceTime;
            yield return null;
        }
    }


}
