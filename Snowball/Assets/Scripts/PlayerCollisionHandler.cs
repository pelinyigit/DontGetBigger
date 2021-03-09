using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollisionHandler : MonoBehaviour
{
    [Space]
    [SerializeField]float scaleFactor;

    private void OnEnable()
    {
        EventManager.OnCharacterScaleUp.AddListener(ScaleUp);
        EventManager.OnCharacterScaleDown.AddListener(ScaleDown);
    }

    private void OnDisable()
    {
        EventManager.OnCharacterScaleUp.RemoveListener(ScaleUp);
        EventManager.OnCharacterScaleDown.RemoveListener(ScaleDown);
    }
    private void ScaleUp()
    {
        transform.localScale = transform.localScale * scaleFactor;
    }
    private void ScaleDown()
    {
        transform.localScale = transform.localScale / scaleFactor;
    }
}
