﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSizeHandler : MonoBehaviour
{
    private enum SnowBallState { XSmall, Small, Mid, Large, XLarge };
    private SnowBallState snowBallState;

    [Space]
    [SerializeField] 
    float scaleFactor;

    [Space]
    [SerializeField]
    float scaleGraceTime = 1f; 

    private void OnEnable()
    {
        EventManager.OnSnowmanCollision.AddListener(ScaleUp);
        EventManager.OnFireCollision.AddListener(ScaleDown);
    }  

    private void OnDisable()
    {
        EventManager.OnSnowmanCollision.RemoveListener(ScaleUp);
        EventManager.OnFireCollision.RemoveListener(ScaleDown);
    }

    private void Start()
    {
        snowBallState = SnowBallState.XSmall;
    }

    private void ScaleUp()
    {
        if (snowBallState != SnowBallState.XLarge)
        {
            snowBallState++;
            EventManager.OnPlayerScaleUp?.Invoke();         
            StartCoroutine(ScaleUpSmooth()); 
        }
        else if (snowBallState == SnowBallState.XLarge)
        {
            EventManager.OnLevelFail?.Invoke();
            Time.timeScale = 1f;
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
        if(snowBallState != SnowBallState.XSmall)
        {
            snowBallState--;
            EventManager.OnPlayerScaleDown?.Invoke();            
            StartCoroutine(ScaleDownSmooth());
        }

        else if(snowBallState == SnowBallState.XSmall)
        {
            return;
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
