using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Space]
    [SerializeField] DynamicJoystick dynamicJoystick;

    [Space]
    [SerializeField] float playerSpeed = 10f;

    Vector3 playerSpeedVector;

    Rigidbody rb;
    CharacterController characterController;

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

        //rb.velocity = new Vector3(dynamicJoystick.Horizontal * playerSpeed * 0.5f, 0f, playerSpeed);
        playerSpeedVector = rb.velocity;
        playerSpeedVector.x = dynamicJoystick.Horizontal * playerSpeed * 0.5f;
        playerSpeedVector.z = playerSpeed;
        rb.velocity = playerSpeedVector;

    }   

  
}
