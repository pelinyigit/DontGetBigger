using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class PlayerController : MonoBehaviour
{
    [Space]
    [SerializeField] DynamicJoystick dynamicJoystick;

    [Space]
    [SerializeField] float playerSpeed = 10f;

    Vector3 playerSpeedVector;

    private bool isPlaying;

    Rigidbody rb;
    CharacterController characterController;

    private void OnEnable()
    {
        EventManager.OnLevelStart.AddListener(StartPlaying);
        EventManager.OnLevelFinish.AddListener(StopPlaying);
    }
    private void OnDisable()
    {
        EventManager.OnLevelStart.RemoveListener(StartPlaying);
        EventManager.OnLevelFinish.RemoveListener(StopPlaying);        
    }

    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        HandlePlayerMovement();        
    }

    void HandlePlayerMovement()
    {
        if (isPlaying)
        {
            //rb.velocity = new Vector3(dynamicJoystick.Horizontal * playerSpeed * 0.5f, 0f, playerSpeed);
            playerSpeedVector = rb.velocity;
            playerSpeedVector.x = dynamicJoystick.Horizontal * playerSpeed * 0.5f;
            playerSpeedVector.z = playerSpeed;
            rb.velocity = playerSpeedVector;
        }
        else
        {
            DOTween.To(() => rb.velocity, x => rb.velocity = x, Vector3.zero, 1.5f);
        }
    } 

    void StartPlaying()
    {
        isPlaying = true;
    }

    void StopPlaying()
    {
        isPlaying = false;
    }
  
}
